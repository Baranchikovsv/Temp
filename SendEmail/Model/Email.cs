using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Model
{
    public class Email
    {
        #region Properties

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// From
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Bounce address
        /// </summary>
        public string BounceAddress { get; set; }

        /// <summary>
        /// Charset
        /// </summary>
        public string Charset { get; set; }

        /// <summary>
        /// Mailer
        /// </summary>
        public string Mailer { get; set; }

        /// <summary>
        /// Reply to
        /// </summary>
        public string ReplyTo { get; set; }

        /// <summary>
        /// Is Body Html
        /// </summary>
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// To
        /// </summary>
        RecipientCollection toRecipientsField;
        internal RecipientCollection ToRecipients
        {
            get
            {
                if (toRecipientsField == null)
                {
                    toRecipientsField = new RecipientCollection();
                }

                return toRecipientsField;
            }
            set
            {
                toRecipientsField = value;
            }
        }

        /// <summary>
        /// Attachements
        /// </summary>
        AttachementCollection attachements;
        internal AttachementCollection Attachements
        {
            get
            {
                if (attachements == null)
                {
                    attachements = new AttachementCollection();
                }

                return attachements;
            }
            set
            {
                attachements = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get to recipients
        /// </summary>
        /// <returns></returns>
        public Recipient[] GetToRecipients()
        {
            return ToRecipients.ToArray();
        }

        /// <summary>
        /// Get attachements
        /// </summary>
        /// <returns></returns>
        public Attachement[] GetAttachements()
        {
            return Attachements.ToArray();
        }

        /// <summary>
        /// Add TO recipient
        /// </summary>
        public Email AddToRecipient(Recipient recipient)
        {
            ToRecipients.Add(recipient);

            return this;
        }

        /// <summary>
        /// Add TO recipient
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public Email AddToRecipient(string name, string email)
        {
            ToRecipients.Add(new Recipient(name, email));

            return this;
        }

        /// <summary>
        /// Add TO recipient
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public Email AddToRecipient(string email)
        {

            ToRecipients.Add(new Recipient(email));

            return this;
        }

      
        /// <summary>
        /// Add attachement
        /// </summary>
        /// <param name="attachement"></param>
        public Email AddAttachement(Attachement attachement)
        {

            Attachements.Add(attachement);

            return this;
        }

        #endregion
    }
}
