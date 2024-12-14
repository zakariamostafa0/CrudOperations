using ExceptionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLogTests
{
    [TestClass]
    public class EmailExceptionLogTests
    {
        [TestMethod]
        public void LogException_ReturnsFriendlyMessage()
        {
            // Arrange
            var logger = new EmailExceptionLog("admin@example.com");
            var exception = new DivideByZeroException("Test email exception");

            // Act
            string userMessage = logger.LogException(exception);

            // Assert
            Assert.AreEqual("Unfortunately An error occurred. Please check your email for details.", userMessage);
        }

        [TestMethod]
        public void LogException_InvalidEmail()
        {
            var logger = new EmailExceptionLog("sdds");
            var exception = new ArgumentNullException("Test the exception");

            try
            {
                logger.LogException(exception);
                Assert.Fail("expected an exeption");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Failed to send the exception email:"));
            }
        }
    }
}
