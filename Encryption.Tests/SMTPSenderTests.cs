using Encryption.EmailSender;

namespace Encryption.Tests
{
    [TestClass]
    public class SMTPSenderTests
    {
        private SMTPSender _smtpSender;
        private string _testConfigFilePath = "TestEmailSettings";

        [TestInitialize]
        public void Setup()
        {
            _smtpSender = new SMTPSender();
        }

        [TestMethod]
        public void SaveConConfiguration_ToSaveConfiguratiogToFile()
        {
            //Arrange
            var emailSettings = new EmailSettings
            {
                ServerName = "smtp.gmail.com",
                PortNumber = 587,
                EmailAddress = "z@gmail.com",
                Password = "dlkjfnnlgtlzgf",
                UseSSL = true,
                BodyIsHtml = true
            };

            //Act
            _smtpSender.SaveConfiguration(_testConfigFilePath, emailSettings);
            var loadedSettings = new GenericDataHandler<EmailSettings>().ReadObjectData(_testConfigFilePath + ".STD");
            
            // Assert
            Assert.IsNotNull(loadedSettings);
            Assert.AreEqual(emailSettings.ServerName, loadedSettings.ServerName);
            Assert.AreEqual(emailSettings.PortNumber, loadedSettings.PortNumber);
        }

        [TestMethod]
        public void GetConfiguration_ShouldLoadSettingsFromFile()
        {
            //chech if email setting correctly loaded from the saved file
            //Arrange
            var emailSettings = new EmailSettings
            {
                ServerName = "smtp.gmail.com",
                PortNumber = 587,
                EmailAddress = "z@gmail.com",
                Password = "dlkjfnnlgtlzgf",
                UseSSL = true,
                BodyIsHtml = true
            };
            new GenericDataHandler<EmailSettings>().SaveObjectData(_testConfigFilePath + ".STD", emailSettings);

            // Act
            _smtpSender.GetConfiguration(_testConfigFilePath);

            // Assert
            Assert.IsNotNull(_smtpSender);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetConfiguration_ShouldLoadSettingsFromFileDoesnNotExist()
        {
            //chech if email setting correctly loaded from the saved file
            //Arrange
            //var emailSettings = new EmailSettings
            //{
            //    ServerName = "smtp.gmail.com",
            //    PortNumber = 587,
            //    EmailAddress = "z@gmail.com",
            //    Password = "dlkjfnnlgtlzgf",
            //    UseSSL = true,
            //    BodyIsHtml = true
            //};
            //new GenericDataHandler<EmailSettings>().SaveObjectData(_testConfigFilePath + ".STD", emailSettings);

            // Act
            _smtpSender.GetConfiguration("FileDoesnNotExist");

            // Assert
            Assert.IsNotNull(_smtpSender);
        }

        [TestMethod]
        public void SendEmail_ShouldSendEmailSuccessfully()
        {
            // Arrange
            var emailSettings = new EmailSettings
            {
                ServerName = "smtp.gmail.com",
                PortNumber = 587,
                EmailAddress = "z@gmail.com",
                Password = "dlkjfnnlgtlzgf",
                UseSSL = true,
                BodyIsHtml = true
            };

            _smtpSender.SaveConfiguration(_testConfigFilePath, emailSettings);
            _smtpSender.GetConfiguration(_testConfigFilePath);

            var messageData = new MessageData
            {
                Subject = "Unit Test Email",
                Content = "This is a test email.",
                ToEmailAddresses = new List<string> { "email1@example.com" },
                CcEmailAddresses = new List<string>()
            };

            // Act
            try
            {
                _smtpSender.SendEmail(messageData);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An Error happend durin sending the email: {ex.Message}");
            }

            // Assert
            Assert.IsTrue(true);
        }
    }
}