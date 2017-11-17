using System.Collections.Generic;

namespace RaNotification.Data.Mail
{
    public class MailEntity
    {
        public MailEntity()
        {
            To = new List<string>();
            Cc = new List<string>();
            Bcc = new List<string>();
            Attachments = new List<MailAttachment>();
        }

        public string From { get; set; }

        public List<string> To { get; set; }

        public List<string> Cc { get; set; }

        public List<string> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<MailAttachment> Attachments { get; set; }
    }
}
