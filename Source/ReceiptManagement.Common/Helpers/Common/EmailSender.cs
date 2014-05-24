using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace ReceiptManagement.Common.Helpers.Common
{
    /// <summary>
    /// The class is used to generates the email.
    /// </summary>
    public class EmailSender
    {
        #region Properties

        public int SmtpPort { get; set; }

        public string SmtpHost { get; set; }

        public string SmtpPassword { get; set; }

        public string RecepientAddress { get; set; }

        public string SenderAddress { get;set; }

        public string SenderName { get; set; } 

        public string Subject { get; set; }

        public string HtmlBody { get; set; } 

        #endregion

        #region Methods

        /// <summary>
        /// SendEmail
        /// </summary>
        /// <returns></returns>
        internal Helpers.ActionResult SendEmail()
        {
            ActionResult actionResult = ActionResult.Factory(true);

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(this.RecepientAddress);

            MailAddress mailAddress = new MailAddress(this.SenderAddress, this.SenderName, System.Text.Encoding.UTF8);
            mailMessage.From = mailAddress;

            mailMessage.Subject = this.Subject;
            mailMessage.Body = this.HtmlBody;

            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential networkCredential = new NetworkCredential(this.SenderAddress, this.SmtpPassword);
            smtpClient.Credentials = networkCredential;
            smtpClient.Host = this.SmtpHost;
            smtpClient.Port = this.SmtpPort;

            try
            {
                smtpClient.Send(mailMessage);
                return actionResult;
            }
            catch (Exception)
            {
                actionResult.WasSuccessful = false;
                return actionResult;
            }
        }

        #endregion
    }
}
