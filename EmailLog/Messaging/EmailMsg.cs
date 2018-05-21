using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailLog.Messaging
{
    public class EmailMsg
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string Recipient { get; set; }
        public string Body { get; set; }
        public string Response { get; set; }
    }
}