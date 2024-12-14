using ExceptionLog;

namespace ExceptionLogTests
{
    [TestClass]
    public class FileExceptionLogTests  
    {
        private const string LogFilePath = "test_exceptions.txt";

        [TestInitialize]
        public void TestInitialize()
        {
            // Ensure the log file is clean before each test
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Clean up the log file after each test
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
        }

        [TestMethod]
        public void LogException_WritesExceptionToFile()
        {
            // Arrange
            var logger = new FileExceptionLog(LogFilePath);
            var exception = new InvalidOperationException("Test exception");

            // Act
            string userMessage = logger.LogException(exception);

            // Assert
            Assert.IsTrue(File.Exists(LogFilePath));
            Assert.AreEqual("Unfortunately An error occurred. Please check the log file for details.", userMessage);
            
            string logContent = File.ReadAllText(LogFilePath);
            Assert.IsTrue(logContent.Contains("Test exception"));
        }

        [TestMethod]
        public void Factory_CreatesEmailLogger()
        {
            // Arrange
            var factory = new ExceptionLogFactory(LogType.Email, "ss@example.com");
            var exception = new IndexOutOfRangeException("email test exception");

            // Act
            string userMessage = factory.LogException(exception);

            // Assert
            Assert.AreEqual("An error occurred. Details have been sent to the administrator.", userMessage);
        }

    }
}