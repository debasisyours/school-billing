using System;
using System.IO;
using System.Reflection;

namespace SchoolBilling.Common
{
    /// <summary>
    /// Type of logging (Enumeration)
    /// </summary>
    public enum LogType
    {
        None = 0,
        Information,
        Warning,
        Error
    }

    /// <summary>
    /// Sealed class for logging information / error / warning
    /// </summary>
    public sealed class Logger
    {

        #region Constructor
        
        private Logger()
        {
            // Left blank intentionally
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Writes log based on logType
        /// </summary>
        /// <param name="details"></param>
        /// <param name="logType"></param>
        private static void WriteLogInternal(string details, LogType logType)
        {
            string applicationName = Assembly.GetExecutingAssembly().GetName().Name;
            string fileName = "LogFile.txt";
            string applicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string applicationNameWithVersion = $"{applicationName} Ver {applicationVersion}";
            string logTime = $"{DateTime.Now.Year}-{DateTime.Now.Month.ToString().PadLeft(2, '0')}-{DateTime.Now.Day.ToString().PadLeft(2, '0')} {DateTime.Now.Hour.ToString().PadLeft(2, '0')}:{DateTime.Now.Minute.ToString().PadLeft(2, '0')}:{DateTime.Now.Second.ToString().PadLeft(2, '0')}.{DateTime.Now.Millisecond.ToString().PadLeft(3, '0')}";
            string folderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), applicationName);

            if(!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            using (FileStream stream = new FileStream(Path.Combine(folderName, fileName), FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine($"{applicationNameWithVersion} - {logTime}");
                    writer.WriteLine(logType.ToString());
                    writer.WriteLine(details);
                }
            }
        }

        #endregion

        #region Public methods
        
        /// <summary>
        /// Logs Exception
        /// </summary>
        /// <param name="exception"></param>
        public static void LogException(Exception exception)
        {
            WriteLogInternal(exception.ToString(), LogType.Error);
        }

        /// <summary>
        /// Logs stack trace when an exception occurs
        /// </summary>
        /// <param name="exception"></param>
        public static void LogStackTrace(Exception exception)
        {
            WriteLogInternal(exception.StackTrace, LogType.Error);
        }

        /// <summary>
        /// Logs information
        /// </summary>
        /// <param name="information"></param>
        public static void LogInformation(string information)
        {
            WriteLogInternal(information, LogType.Information);
        }

        #endregion
    }
}
