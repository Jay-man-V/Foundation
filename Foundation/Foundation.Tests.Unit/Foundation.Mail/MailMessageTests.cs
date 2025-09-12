//-----------------------------------------------------------------------
// <copyright file="MailMessageTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Services.Mail;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Mail
{
    /// <summary>
    /// Summary description for MailMessageTests
    /// </summary>
    [TestFixture]
    public class MailMessageTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            IMailMessage mailMessage = CoreInstance.IoC.Get<IMailMessage>();

            Type[] allInterfaces = mailMessage.GetType().GetInterfaces();

            Assert.That(allInterfaces.Length, Is.EqualTo(2));
            Assert.That(mailMessage, Is.InstanceOf<IMailMessage>());
            Assert.That(mailMessage, Is.InstanceOf<ICloneable>());
        }

        [TestCase]
        public void Test_Clone()
        {
            IMailMessage mailMessage = CoreInstance.IoC.Get<IMailMessage>();

            mailMessage.Body = "Mail Body";
            mailMessage.IsBodyHtml = true;
            mailMessage.FromAddress = "From Address";
            mailMessage.FromAddressDisplayName = "From Address Display Name";
            mailMessage.Subject = "Mail Subject";

            mailMessage.Attachments.Add(new MailAttachment { Filename = "Attachment 1", Content = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0] });
            mailMessage.Attachments.Add(new MailAttachment { Filename = "Attachment 2", Content = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0] });
            mailMessage.Attachments.Add(new MailAttachment { Filename = "Attachment 3", Content = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0] });
            mailMessage.ToAddress.Add("Address 1");
            mailMessage.ToAddress.Add("Address 2");
            mailMessage.ToAddress.Add("Address 3");

            IMailMessage clonedMailMessage = (IMailMessage)mailMessage.Clone();

            Assert.That(clonedMailMessage.Body, Is.EqualTo(mailMessage.Body));
            Assert.That(clonedMailMessage.IsBodyHtml, Is.EqualTo(mailMessage.IsBodyHtml));
            Assert.That(clonedMailMessage.FromAddress, Is.EqualTo(mailMessage.FromAddress));
            Assert.That(clonedMailMessage.FromAddressDisplayName, Is.EqualTo(mailMessage.FromAddressDisplayName));
            Assert.That(clonedMailMessage.Subject, Is.EqualTo(mailMessage.Subject));

            Assert.That(clonedMailMessage.Attachments.Count, Is.EqualTo(mailMessage.Attachments.Count));
            Assert.That(clonedMailMessage.ToAddress.Count, Is.EqualTo(mailMessage.ToAddress.Count));

            Assert.That(clonedMailMessage.Attachments, Is.Not.EqualTo(mailMessage.Attachments));
            Assert.That(clonedMailMessage.ToAddress, Is.Not.SameAs(mailMessage.ToAddress));

            Assert.That(clonedMailMessage.Body, Is.Not.SameAs(mailMessage.Body));
            Assert.That(clonedMailMessage.IsBodyHtml, Is.Not.SameAs(mailMessage.IsBodyHtml));
            Assert.That(clonedMailMessage.FromAddress, Is.EquivalentTo(mailMessage.FromAddress));
            Assert.That(clonedMailMessage.FromAddressDisplayName, Is.EquivalentTo(mailMessage.FromAddressDisplayName));
        }
    }
}
