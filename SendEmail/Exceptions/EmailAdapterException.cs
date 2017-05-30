using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendEmail.Exceptions
{
    /// <summary>
    /// General email adapter exception
    /// </summary>
    public class EmailAdapterException : Exception
    {
        public EmailAdapterException()
            :
            base()
        {
        }

        public EmailAdapterException(string message)
            :
            base(message)
        {
        }
        
        public EmailAdapterException(string message, Exception innerException)
            :
            base(message, innerException)
        {
        }
    }
}