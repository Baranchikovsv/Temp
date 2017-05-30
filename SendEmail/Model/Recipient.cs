using System;

namespace SendEmail.Model
{

    public class Recipient
    {
        /// <summary>
        /// Client name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Client email address
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Recipient()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public Recipient(string name, string email)
        {
            Name = name;
            Email = email;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email"></param>
        public Recipient(string email)
        {
            Email = email;
        }
    }
}