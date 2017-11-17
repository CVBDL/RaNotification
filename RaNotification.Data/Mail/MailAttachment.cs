using System.IO;
using System.Net.Mail;
using System.Text;

namespace RaNotification.Data.Mail
{
    public class MailAttachment
    {
        /// <summary>
        /// Name must contains the extension name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attachment data.
        /// </summary>
        public byte[] Data { get; set; }


        public static MailAttachment FromFilePath(string fullPath)
        {
            var name = Path.GetFileName(fullPath);
            var data = File.ReadAllBytes(fullPath);
            return new MailAttachment
            {
                Name = name,
                Data = data
            };
        }

        public static MailAttachment FromString(string name, string content)
        {
            var data = Encoding.UTF8.GetBytes(content);
            return new MailAttachment
            {
                Name = name,
                Data = data
            };
        }

        public Attachment ToAttachment()
        {
            var ms = new MemoryStream(Data);
            return new Attachment(ms, Name);
        }
    }
}
