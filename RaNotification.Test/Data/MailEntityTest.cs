using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RaNotification.Data;
using RaNotification.Data.Mail;

namespace RaNotification.Test.Data
{
    [TestClass]
    public class MailEntityTest
    {
        [TestMethod]
        public void MailEntity_SerializeAndDeserialize_Test()
        {
            var entity = new MailEntity();
            entity.From = "tester@163.com";
            entity.To.Add("tester2@163.com");
            entity.Cc.Add("tester3@163.com");
            entity.Subject = "This is test subject";
            entity.Body = "This is test body";
            entity.Attachments.Add(MailAttachment.FromString("1.txt", "this is attachment data"));

            var notifyData = new NotifyData
            {
                Type = NotifyType.Email,
                Data = entity,
            };
            var srData = notifyData.Serialize();
            Assert.IsFalse(string.IsNullOrWhiteSpace(srData));

            notifyData.Deserialize(srData);
            var dsEntity = JsonConvert.DeserializeObject<MailEntity>(notifyData.Data.ToString());

            Assert.AreEqual(dsEntity.From, "tester@163.com");
            Assert.AreEqual(dsEntity.To[0], "tester2@163.com");
            Assert.AreEqual(dsEntity.Cc[0], "tester3@163.com");
            Assert.AreEqual(dsEntity.Subject, "This is test subject");
            Assert.AreEqual(dsEntity.Body, "This is test body");
            Assert.IsTrue(dsEntity.Bcc.Count == 0);
        }
    }
}
