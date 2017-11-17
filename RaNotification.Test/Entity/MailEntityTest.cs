using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaNotification.Entity.Mail;

namespace RaNotification.Test.Entity
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
            var transferData = entity.Serialize();

            Assert.IsFalse(string.IsNullOrWhiteSpace(transferData));

            var dsEntity = entity.Deserialize(transferData) as MailEntity;

            Assert.AreEqual(dsEntity.From, "tester@163.com");
            Assert.AreEqual(dsEntity.To[0], "tester2@163.com");
            Assert.AreEqual(dsEntity.Cc[0], "tester3@163.com");
            Assert.AreEqual(dsEntity.Subject, "This is test subject");
            Assert.AreEqual(dsEntity.Body, "This is test body");
            Assert.IsTrue(dsEntity.Bcc.Count == 0);
        }
    }
}
