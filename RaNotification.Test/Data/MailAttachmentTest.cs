﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaNotification.Data.Mail;

namespace RaNotification.Test.Data
{
    [TestClass]
    public class MailAttachmentTest
    {
        [TestMethod]
        public void MailAttachmentTest_FromFilePath_Success()
        {
            var attachment = MailAttachment.FromFilePath("TestData\\AttachmentFileData.txt");
            Assert.IsNotNull(attachment);
        }

        [TestMethod]
        public void MailAttachmentTest_FromString_Success()
        {
            var attachment = MailAttachment.FromString("test.txt", "hello");
            Assert.IsNotNull(attachment);
        }
    }
}
