using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaNotification.Data;
using RaNotification.Data.Mail;
using RaNotification.Way.Mail;

namespace RaNotification.Sample
{
    public class EmailSample
    {
        private string uri = "http://localhost:6606/";

        private bool isStarted;

        public void ClientPost()
        {
            Task.Delay(500).Wait();
            var client = new HttpClient();
            var entity = new MailEntity();
            entity.From = "tester@*.com";
            entity.To.Add("tester2@*.com");
            entity.Subject = "This is test subject";
            entity.Body = "This is test body";
            entity.Attachments.Add(MailAttachment.FromString("1.txt", "this is attachment data"));
            var data = new NotifyData
            {
                Type = NotifyType.Email,
                Data = entity
            };
            var content = new StringContent(data.Serialize());

            while (!isStarted)
            {
                Task.Delay(1000).Wait();
            }
            client.PostAsync(uri, content);
        }

        public void StartServer()
        {
            Task.Run((Action)DoStartServer);
        }

        public void DoStartServer()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(uri);
            isStarted = true;
            listener.Start();

            var context = listener.GetContext();
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                var body = reader.ReadToEnd();
                var notifyData = new NotifyData();
                notifyData.Deserialize(body);
                if (notifyData.Type == NotifyType.Email)
                {
                    var json = notifyData.Data.ToString();
                    var entity = JsonConvert.DeserializeObject<MailEntity>(json);
                    var agent = new MailAgent();
                    agent.Send(entity);
                }
            }

            var output = context.Response.OutputStream;
            output.Flush();
            output.Close();
        }
    }
}
