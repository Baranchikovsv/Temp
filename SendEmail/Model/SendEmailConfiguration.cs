

namespace SendEmail.Model
{
    /// <summary>
    /// Send email configuration
    /// </summary>
    public class SendEmailConfiguration
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public int CryptoProtocol { get; set; }

        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}
