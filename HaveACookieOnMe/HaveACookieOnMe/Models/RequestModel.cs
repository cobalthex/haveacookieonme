using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaveACookieOnMe.Models
{
    /// <summary>
    /// A single request for a cookie
    /// </summary>
    public class RequestModel
    {
        /// <summary>
        /// The type of cookie to deliver
        /// </summary>
        public string CookieType { get; set; }
        /// <summary>
        /// The recipient, who can be either a physical address or an email address. Email addresses receive an email asking for a physical address
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Is the recipient an email address (To be translated)
        /// </summary>
        public bool IsRecipientAnEmail { get { return (new System.Text.RegularExpressions.Regex("[^\\s]+@[^\\s]+").IsMatch(Recipient)); } }
        /// <summary>
        /// An optional personalized message to go with the cookie
        /// </summary>
        public string Message { get; set; }
    }
}