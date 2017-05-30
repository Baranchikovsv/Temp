using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chilkat;
using SendEmail.Model;
using SendEmail.Exceptions;

namespace SendEmail.Adapters
{
    internal class ChilkatEmailAdapter 
    {
        internal string Key { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        public ChilkatEmailAdapter(string key)
        {
           
            Key = key;
        }

        /// <summary>
        /// Send emails
        /// </summary>
        /// <param name="message"></param>
        public void SendEmail(SendEmailConfiguration sendEmailConfiguration, SendEmail.Model.Email message)
        {
           
            try
            {
                // Create a mailman object for sending email.
                var mailman = new MailMan();
                bool success = mailman.UnlockComponent(Key);
                if (success != true)
                {
                    throw new ArgumentException("Unable to unlock mailman component");
                }

                mailman.SmtpHost = sendEmailConfiguration.SmtpHost;
                mailman.SmtpPort = sendEmailConfiguration.SmtpPort;

                //nothing
                if (sendEmailConfiguration.CryptoProtocol == 0)
                {
                }

                //ssl
                if (sendEmailConfiguration.CryptoProtocol == 1)
                {
                    mailman.SmtpSsl = true;
                }

                //tls
                if (sendEmailConfiguration.CryptoProtocol == 2)
                {
                    mailman.StartTLS = true;
                }

                mailman.SmtpUsername = sendEmailConfiguration.SmtpUsername;
                mailman.SmtpPassword = sendEmailConfiguration.SmtpPassword;

                // Create an email object
                var email = new Chilkat.Email();

                email.Subject = message.Subject;
                //set html or text body
                if (message.IsBodyHtml)
                {
                    email.SetHtmlBody(message.Body);
                }
                else
                {
                    email.Body = message.Body;
                }

                email.From = message.From;

                var toRecipients = message.GetToRecipients();


                if (toRecipients.Length == 0 )
                {
                    throw new ArgumentException("Recipient Not Found");
                }

                foreach (var r in toRecipients)
                {
                    email.AddTo(r.Name, r.Email);
                }

                foreach (Attachement attachement in message.GetAttachements())
                {
                    if (attachement.DataType == DataType.File)
                    {
                        attachement.ContentType = email.AddFileAttachment(attachement.FileName);
                        if (attachement.ContentType == null)
                        {
                            throw new Exception("Invalid content type");
                        }
                    }
                    else
                    {
                        bool result = email.AddDataAttachment(attachement.Name, attachement.FileData);
                        if (!result)
                        {
                            throw new Exception($"Invalid content type: {email.LastErrorText}");
                        }
                    }
                }

                // Send email 
                bool successSend = mailman.SendEmail(email);
                if (!successSend)
                {
                    throw new Exception(mailman.LastErrorText);
                }
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        /// <summary>
        /// Handle exception
        /// </summary>
        /// <param name="e"></param>
        protected virtual void HandleException(Exception e)
        {

            throw new EmailAdapterException(e.Message, e);
        }
    }
}
