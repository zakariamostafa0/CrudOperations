using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLog
{
    public class FileExceptionLog : IExceptionLog
    {
        private readonly string _filePath;

        public FileExceptionLog(string filePath) 
        {
            _filePath = filePath;
        }
        public string LogException(Exception exception)
        {
            try
            {
                string logMessage = $"Date: [{DateTime.Now}]  Exception Type {exception.GetType().Name}\n"+
                    $"Message: {exception.Message}\n"+
                    $"Stack Trace {exception.StackTrace}\n";
                File.AppendAllText(_filePath, logMessage);

                return "Unfortunately An error occurred. Please check the log file for details.";
            }
            catch (Exception ex)
            {
                return $"Failed to log exception in the file: {ex.Message}";
            }
        }
    }
}
