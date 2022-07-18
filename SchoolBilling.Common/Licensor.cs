using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Globalization;

namespace SchoolBilling.Common
{
    public enum LicenseStatus
    {
        None=0,
        Trial,
        Expired,
        Registered,
        Tampered
    }

    public sealed class Licensor
    {
        private static string secretFileName = "secret.log";

        public static string EncryptString(string plainText)
        {
            string cipher = string.Empty;
            var byteString = Encoding.UTF8.GetBytes(plainText);
            cipher = Convert.ToBase64String(byteString);
            return cipher;
        }

        public static string DecryptString(string cipherText)
        {
            string plainText = string.Empty;
            var byteString = Convert.FromBase64String(cipherText);
            plainText = Encoding.UTF8.GetString(byteString);
            return plainText;
        }

        public static LicenseStatus CheckLicenseStatus()
        {
            LicenseStatus status = LicenseStatus.None;
            string licenseKey = string.Empty;
            string validTill = string.Empty;

            try
            {
                if(!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), secretFileName)))
                {
                    status = LicenseStatus.Tampered;
                }
                else
                {
                    using (FileStream stream = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), secretFileName), FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            validTill = DecryptString(reader.ReadLine());
                            licenseKey = DecryptString(reader.ReadLine());
                            if (validTill.EndsWith("2199"))
                            {
                                status = LicenseStatus.Registered;
                            }
                            else
                            {
                                bool parsedExpiry = DateTime.TryParseExact(validTill, "MM/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime expiryDate);
                                if (parsedExpiry)
                                {
                                    if (DateTime.Today > expiryDate)
                                    {
                                        status = LicenseStatus.Expired;                                        
                                    }
                                    else
                                    {
                                        status = LicenseStatus.Trial;
                                    }
                                }
                                else
                                {
                                    status = LicenseStatus.None;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            return status;
        }

        public static bool CreateSecretFile(string licenstKey)
        {
            bool success = false;            
            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), secretFileName), FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(EncryptString(DateTime.Now.AddDays(5).ToString("MM/dd/yyyy")));
                        writer.WriteLine(EncryptString(licenstKey));
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return success;
        }

        public static bool ActivateLicense(string activationCode)
        {
            bool success = false;
            string licenseKey = string.Empty;
            string validTill = string.Empty;
            bool licenseValid = false;
            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), secretFileName), FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        validTill = reader.ReadLine();
                        licenseKey = DecryptString(reader.ReadLine());
                        licenseValid = string.Compare(licenseKey, activationCode, true, CultureInfo.CurrentCulture) == 0;
                    }
                }

                if (licenseValid)
                {
                    using (FileStream stream = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), secretFileName), FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.WriteLine(EncryptString("12/31/2199"));
                            writer.WriteLine(EncryptString($"Some{activationCode}value"));
                            success = true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            return success;
        }

        public static bool SendActivationRequestMail(string requestEmail)
        {
            bool success = false;
            string licenseKey = string.Empty;
            string validTill = string.Empty;

            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), secretFileName), FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        validTill = reader.ReadLine();
                        licenseKey = DecryptString(reader.ReadLine());
                    }
                }

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("debasis.yours@gmail.com", "L0g1c@2020");
                client.EnableSsl = true;
                //client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                MailMessage message = new MailMessage();
                
                message.From = new MailAddress("debasis.yours@gmail.com");
                message.To.Add(new MailAddress("debasis.yours@gmail.com"));
                message.Subject = "Request for activation";
                message.Body = $"Request for license activation from Email: {requestEmail}, <br /> kindly use License key: <b>{licenseKey}</b>";
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                client.Send(message);
                success = true;
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            return success;
        }
    }
}
