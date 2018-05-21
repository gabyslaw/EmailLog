using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailLog.Models
{
    public class EmailMessage
    {

        //constructor
        private EmailMessage() { }

        #region Properties
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        #endregion

        public static EmailMessage CreateMessage(string _recipient, string _subject, string _message)
        {
            EmailMessage msg = new EmailMessage
            {
                Recipient = _recipient,
                Subject = _subject,
                Message = _message
            };
            return msg;
        }
    }
}