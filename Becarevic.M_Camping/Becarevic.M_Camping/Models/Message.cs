using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Becarevic.M_Camping.Models
{
    public class Message
    {

        public string Header { get; set; }
        public string Additionalheader { get; set; }
        public string MessageText { get; set; }
        public string Solution { get; set; }

        public Message() : this("", "", "", "") { }

        public Message(string header, string messageText) : this(header, "", messageText, "") { }

        public Message(string header, string addHeader, string messageText, string solution)
        {
            this.Header = header;
            this.Additionalheader = addHeader;
            this.MessageText = messageText;
            this.Solution = solution;
        }
    }
}