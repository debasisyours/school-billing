using SchoolBilling.Common;
using SchoolBilling.Data.Entities;
using System;
using System.Data.OleDb;
using System.Text;
using System.Linq;

namespace SchoolBilling.Data.Repositories
{
    public class CompanyHelper : IDisposable
    {
        private readonly BillingContext? _context = null;
        private readonly string _connectionString = string.Empty;

        public CompanyHelper(BillingContext context)
        {
            _context = context;
        }

        public CompanyHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region For MS Access

        public Company GetCompanyDetail()
        {
            Company? company = null;
            string query = $"SELECT * FROM Company";
            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = query;

                        using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                company = new Company();
                                company.Id = Convert.ToInt32(reader["Id"]);
                                company.Name = Convert.ToString(reader["Name"]);
                                company.Address = Convert.ToString(reader["Address"]);
                                company.City = Convert.ToString(reader["City"]);
                                company.State = Convert.ToString(reader["state"]);
                                company.PostalCode = Convert.ToString(reader["PostalCode"]);
                                company.Country = Convert.ToString(reader["Country"]);
                                company.Phone = Convert.ToString(reader["Phone"]);
                                company.Fax = Convert.ToString(reader["Fax"]);
                                company.CountyName = Convert.ToString(reader["CountyName"]);
                                company.ContactPerson = Convert.ToString(reader["ContactPerson"]);
                                company.ContactInformation = Convert.ToString(reader["ContactInformation"]);
                                company.ContactEmail = Convert.ToString(reader["ContactEmail"]);
                                company.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                company.ModifiedOn = Convert.ToDateTime(reader["ModifiedOn"]);
                                company.StartingInvoiceNumber = Convert.ToInt32(reader["StartingInvoiceNumber"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return company;
        }

        public bool UpdateCompanyDetail(Company company)
        {
            bool success = false;
            bool recordExists = false;
            string selectQuery = $"SELECT COUNT(1) FROM Company";
            string insertQuery = $"INSERT INTO Company(Name, Address, City, State, PostalCode, Country, Phone, Fax, CountyName, ContactPerson, ContactInformation, ContactEmail, CreatedOn, ModifiedOn, StartingInvoiceNumber) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string updateQuery = $"UPDATE Company SET Name = ?, Address = ?, City = ?, State = ?, PostalCode = ?, Country = ?, Phone = ?, Fax = ?, CountyName = ?, ContactPerson = ?, ContactInformation = ?, ContactEmail = ?, ModifiedOn = ?, StartingInvoiceNumber = ?";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                recordExists = Convert.ToInt32(reader[0]) > 0;
                            }
                        }
                    }

                    if (recordExists)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandType = System.Data.CommandType.Text;
                            command.CommandTimeout = 0;
                            command.CommandText = updateQuery;

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Name",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = company.Name
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Address",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = company.Address
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "City",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.City) ? "" : company.City
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "State",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.State) ? "" : company.State
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "PostalCode",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.PostalCode) ? "" : company.PostalCode
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Country",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.Country) ? "" : company.Country
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Phone",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.Phone) ? "" : company.Phone
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Fax",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.Fax) ? "" : company.Fax
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "CountyName",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.CountyName) ? "" : company.CountyName
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ContactPerson",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.ContactPerson) ? "" : company.ContactPerson
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ContactInformation",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.ContactInformation) ? "" : company.ContactInformation
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ContactEmail",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.ContactEmail) ? "" : company.ContactEmail
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ModifiedOn",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.Date,
                                Value = DateTime.Now
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "StartingInvoiceNumber",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.Integer,
                                Value = company.StartingInvoiceNumber
                            });

                            command.ExecuteNonQuery();
                            success = true;
                        }
                    }
                    else
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandType = System.Data.CommandType.Text;
                            command.CommandTimeout = 0;
                            command.CommandText = insertQuery;

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Name",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = company.Name
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Address",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = company.Address
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "City",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.City) ? "" : company.City
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "State",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.State) ? "" : company.State
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "PostalCode",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.PostalCode)? "": company.PostalCode
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Country",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.Country)? "": company.Country
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Phone",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.Phone)? "" : company.Phone
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Fax",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.Fax) ? "" : company.Fax
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "CountyName",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.CountyName) ? "" : company.CountyName
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ContactPerson",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.ContactPerson) ? "" : company.ContactPerson
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ContactInformation",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.ContactInformation) ? "" : company.ContactInformation
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ContactEmail",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.LongVarChar,
                                Value = string.IsNullOrWhiteSpace(company.ContactEmail) ? "" : company.ContactEmail
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "CreatedOn",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.Date,
                                Value = DateTime.Now
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ModifiedOn",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.Date,
                                Value = DateTime.Now
                            });
                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "StartingInvoiceNumber",
                                Direction = System.Data.ParameterDirection.Input,
                                OleDbType = OleDbType.Integer,
                                Value = company.StartingInvoiceNumber
                            });

                            command.ExecuteNonQuery();
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return success;
        }

        public bool IsPasswordSet()
        {
            bool success = false;
            string selectQuery = "SELECT COUNT(1) FROM AdminPassword";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                success = Convert.ToInt32(reader[0]) > 0;
                            }
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

        public string GetPassword()
        {
            string password = string.Empty;
            string selectQuery = "SELECT Password FROM AdminPassword";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandTimeout = 0;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                password = DecodeValue(Convert.ToString(reader["Password"]));
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            return password;
        }

        public bool SetPassword(string password)
        {
            bool success = false;
            bool recordExists = false;
            string selectQuery = "SELECT COUNT(1) FROM AdminPassword";
            string insertQuery = $"INSERT INTO AdminPassword VALUES('{EncodeValue(password)}')";
            string updateQuery = $"UPDATE AdminPassword SET Password = {EncodeValue(password)}";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText= selectQuery;

                        using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                recordExists = Convert.ToInt32(reader[0]) > 0;
                            }
                        }
                    }

                    if (recordExists)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandType = System.Data.CommandType.Text;
                            command.CommandTimeout = 0;
                            command.CommandText = updateQuery;
                            command.ExecuteNonQuery();
                            success = true;
                        }
                    }
                    else
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandType = System.Data.CommandType.Text;
                            command.CommandTimeout = 0;
                            command.CommandText = insertQuery;
                            command.ExecuteNonQuery();
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return success;
        }

        public bool UpdateDatabase()
        {
            bool success = false;
            bool columnExists = false;
            string selectQuery = $"SELECT StartingInvoiceNumber FROM Company";
            string alterQuery = $"ALTER TABLE [Company] ADD COLUMN [StartingInvoiceNumber] Number";
            string alterInvoiceQuery = $"ALTER TABLE [Invoice] ADD COLUMN [InvoiceNumber] Number";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText= selectQuery;

                        using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                        {
                            columnExists = true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                columnExists = false;
            }
            finally
            {
                if (!columnExists)
                {
                    using (var connection = new OleDbConnection(this._connectionString))
                    {
                        connection.Open();
                        using(var command = connection.CreateCommand())
                        {
                            command.CommandTimeout = 0;
                            command.CommandType = System.Data.CommandType.Text;
                            command.CommandText = alterQuery;
                            command.ExecuteNonQuery();

                            command.CommandText = alterInvoiceQuery;
                            command.ExecuteNonQuery();
                            success = true;
                        }
                    }
                }
            }

            return success;
        }

        private string EncodeValue(string input)
        {
            var encoded = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(encoded);
        }

        private string DecodeValue(string input)
        {
            var decoded = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(decoded);
        }

        #endregion

        #region For Entity Framework

        //public Company GetCompanyDetail()
        //{
        //    Company? company = null;
        //    try
        //    {
        //        if (_context.Companies.Count() > 0)
        //        {
        //            company = _context.Companies.FirstOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return company;
        //}

        //public bool UpdateCompanyDetail(Company company)
        //{
        //    bool success = false;

        //    try
        //    {
        //        Company? companyDetail = _context.Companies.FirstOrDefault();

        //        if (companyDetail != null)
        //        {
        //            companyDetail.Address = company.Address;
        //            companyDetail.City = company.City;
        //            companyDetail.ContactEmail = company.ContactEmail;
        //            companyDetail.ContactInformation = company.ContactInformation;
        //            companyDetail.ContactPerson = company.ContactPerson;
        //            companyDetail.Country = company.Country;
        //            companyDetail.CountyName = company.CountyName;
        //            companyDetail.Fax = company.Fax;
        //            companyDetail.Name = company.Name;
        //            companyDetail.Phone = company.Phone;
        //            companyDetail.PostalCode = company.PostalCode;
        //            companyDetail.State = company.State;
        //            companyDetail.ModifiedOn = DateTime.Now;
        //        }
        //        else
        //        {
        //            company.CreatedOn = DateTime.Now;
        //            company.ModifiedOn = DateTime.Now;
        //            _context.Companies.Add(company);
        //        }

        //        _context.SaveChanges();
        //        success = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }
        //    return success;
        //}

        #endregion

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
