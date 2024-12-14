using ExceptionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLogTests
{
    [TestClass]
    public class ExceptionLogFactoryTests
    {
        private const string LogFilePath = "factory_test_exceptions.txt";

        [TestInitialize]
        public void TestInitialize()
        {
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
        }

        [TestMethod]
        public void Factory_CreatesFileLogger()
        {
            // Arrange
            var factory = new ExceptionLogFactory(LogType.File, LogFilePath);
            var exception = new NullReferenceException("test exception");

            // Act
            factory.LogException(exception);

            // Assert
            Assert.IsTrue(File.Exists(LogFilePath));

            string logContent = File.ReadAllText(LogFilePath);
            Assert.IsTrue(logContent.Contains("test exception"));
        }

        [TestMethod]
        public void Factory_CreatesEmailLoggerAndLogsException()
        {
            // Arrange
            var factory = new ExceptionLogFactory(LogType.Email, "admin@example.com");
            var exception = new ArgumentNullException("Test the exception");

            // Act
            string userMessage = factory.LogException(exception);

            // Assert
            Assert.AreEqual("Unfortunately An error occurred. Please check your email for details.", userMessage);
        }
    }
}
