using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaNotification.Way.Mail;
using RaNotification.Data.Mail;

namespace RaNotification.Test.Way.Mail
{
    [TestClass]
    public class MailAgentTest
    {
        [TestMethod]
        [Ignore]
        public void MailAgent_Send_Success()
        {
            var entity = new MailEntity();
            entity.From = "tester@***.com";
            entity.To.Add("tester@***.com");
            entity.Subject = "This is test subject";
            entity.Body = "This is test body";
            entity.Attachments.Add(MailAttachment.FromString("1.txt", "this is attachment data"));

            var agent = new MailAgent();
            agent.Send(entity);
        }
    }
}
