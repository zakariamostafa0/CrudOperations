using Encryption;
using Encryption.EmailSender;

class Program
{
    static void Main(string[] args)
    {
        #region Encrypt & Decrypt
        //string result = null;
        //string name = "Ahmed";
        //GenericDataHandler<string> genericDataHandler = new GenericDataHandler<string>();
        //result = genericDataHandler.Encrypt(name);
        //Console.WriteLine(result);
        //result = genericDataHandler.Decrypt(result);
        //Console.WriteLine(result);
        #endregion

        #region Send Email 
        //SMTPSender smtpSender = new SMTPSender();
        //string configFilePath = "EmailConfig";

        //EmailSettings emailSettings = new EmailSettings
        //{
        //    ServerName = "smtp.example.com",
        //    PortNumber = 587,
        //    EmailAddress = "my-email@example.com",
        //    Password = "EFF5Cxxz",
        //    UseSSL = true,
        //    BodyIsHtml = true
        //};

        //smtpSender.SaveConfiguration(configFilePath,emailSettings);
        
        //smtpSender.GetConfiguration(configFilePath);

        //MessageData messageData = new MessageData
        //{
        //    Subject = "Test Email",
        //    Content = "<h1>This is a test email</h1>",
        //    ToEmailAddresses = new List<string> { "email1@example.com", "email2@example.com" },
        //    CcEmailAddresses = new List<string> { "ccemail@example.com" }
        //};
        //smtpSender.SendEmail(messageData);

        #endregion
        
    }
}