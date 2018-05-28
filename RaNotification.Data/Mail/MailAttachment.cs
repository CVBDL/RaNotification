using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
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
            var mediaType = this.determineMediaType(Name);
            return new Attachment(ms, Name, mediaType);
        }

        private string determineMediaType(string filename) {
            string fileExtension = string.Empty;
            try {
                string[] parts = filename.Split('.');
                fileExtension = parts[parts.Length - 1];
            }
            catch (Exception) { }

            string mediaType = string.Empty;
            switch (fileExtension) {
                case "txt":
                    mediaType = MediaTypeNames.Text.Plain;
                    break;
                case "xml":
                    mediaType = MediaTypeNames.Text.Xml;
                    break;
                case "pdf":
                    mediaType = MediaTypeNames.Application.Pdf;
                    break;
                case "zip":
                    mediaType = MediaTypeNames.Application.Zip;
                    break;
                case "gif":
                    mediaType = MediaTypeNames.Image.Gif;
                    break;
                case "jpeg":
                case "jpg":
                    mediaType = MediaTypeNames.Image.Jpeg;
                    break;
                case "png":
                    mediaType = "image/png";
                    break;
                case "xls":
                    mediaType= "application/vnd.ms-excel";
                    break;
                case "xlsx":
                    mediaType= "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                default:
                    mediaType = MediaTypeNames.Text.Plain;
                    break;
            }

            return mediaType;
        }
    }
}
