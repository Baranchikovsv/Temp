using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendEmail.Model;

namespace SendEmail.Util
{
    public static class ChilkatEmailAdapterHelper
    {
        public static SendEmailConfiguration GetSendEmailConfiguration()
        {
            return new SendEmailConfiguration()
            {
                CryptoProtocol = ParseInt(System.Configuration.ConfigurationManager.AppSettings["CryptoProtocol"]),
                SmtpHost = System.Configuration.ConfigurationManager.AppSettings["SmtpHost"],
                SmtpPort = ParseInt(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]),
                SmtpPassword = System.Configuration.ConfigurationManager.AppSettings["SmtpPassword"],
                SmtpUsername = System.Configuration.ConfigurationManager.AppSettings["SmtpUsername"]
            };
        }

        public static string GetUnlockKey()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ChilkatUnlockKey"];
        }

        public static int ParseInt(string val)
        {
            int i;
            if(int.TryParse(val, out i))
            {
                return i;
            }
            return 0;
        }
    }
}
