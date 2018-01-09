using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json;
using RaNotification.Data.Mail;

namespace RaNotification.Way.Mail
{
    public class MailAgent
    {
        private MailConfig config;

        public MailAgent(MailConfig cfg = null)
        {
            config = cfg ?? LoadConfig();
        }

        public bool Send(MailEntity entity)
        {
            MailMessage message = null;
            List<Attachment> attachments = null;
            try
            {
                var client = CreateClient(config);
                message = CreateMessage(entity);
                attachments = ConvertAttachments(entity);
                attachments.ForEach(i => message.Attachments.Add(i));
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                // Dispose the stream. 
                // Must dispose the stream after the message send completed.
                if (attachments != null && attachments.Count > 0)
                {
                    attachments.ForEach(i => i.Dispose());
                }

                if (message != null)
                    message.Dispose();
            }
        }

        private MailConfig LoadConfig()
        {
            var content = File.ReadAllText("MailConfig.json");
            return JsonConvert.DeserializeObject<MailConfig>(content);
        }

        private SmtpClient CreateClient(MailConfig config)
        {
            return new SmtpClient
            {
                Host = config.SmtpServer,
                Port = config.Port,
            };
        }

        private MailMessage CreateMessage(MailEntity entity)
        {
            var message = new MailMessage
            {
                From = new MailAddress(entity.From),
                Subject = entity.Subject,
                SubjectEncoding = Encoding.UTF8,
                Body = entity.Body,
                IsBodyHtml = entity.IsHtml,
                BodyEncoding = Encoding.UTF8
            };
            entity.To.ForEach(t => message.To.Add(t));
            entity.Cc.ForEach(c => message.CC.Add(c));
            entity.Bcc.ForEach(b => message.Bcc.Add(b));
            return message;
        }

        private List<Attachment> ConvertAttachments(MailEntity entity)
        {
            var attachments = new List<Attachment>();
            foreach (var item in entity.Attachments)
            {
                attachments.Add(item.ToAttachment());
            }
            return attachments;
        }
    }
}
