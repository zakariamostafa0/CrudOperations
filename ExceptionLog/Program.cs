// See https://aka.ms/new-console-template for more information
using ExceptionLog;

try
{
    throw new NullReferenceException("A null reference occurred.");
}
catch (Exception ex)
{
    var factory = new ExceptionLogFactory(LogType.File, "exceptions.txt");
    string userMessage = factory.LogException(ex); // Calls FileExceptionLog.LogException
    Console.WriteLine(userMessage); // Prints: "An error occurred. Please check the log file for details."
}

