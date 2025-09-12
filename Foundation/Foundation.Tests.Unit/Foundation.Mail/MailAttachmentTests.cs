//-----------------------------------------------------------------------
// <copyright file="MailAttachmentTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Services.Mail;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Mail
{
    /// <summary>
    /// Summary description for MailAttachmentTests
    /// </summary>
    [TestFixture]
    public class MailAttachmentTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            IMailAttachment mailAttachment = CoreInstance.IoC.Get<IMailAttachment>();

            Type[] allInterfaces = mailAttachment.GetType().GetInterfaces();

            Assert.That(allInterfaces.Length, Is.EqualTo(2));
            Assert.That(mailAttachment, Is.InstanceOf<IMailAttachment>());
            Assert.That(mailAttachment, Is.InstanceOf<ICloneable>());
        }

        [TestCase]
        public void Test_Clone()
        {
            IMailAttachment mailAttachment = CoreInstance.IoC.Get<IMailAttachment>();

            mailAttachment.Filename = "Filename";
            mailAttachment.Content = [0, 1, 2, 3, 5, 6, 7, 8, 9];

            IMailAttachment clonedMailAttachment = (MailAttachment)mailAttachment.Clone();

            Assert.That(clonedMailAttachment.Filename, Is.EqualTo(mailAttachment.Filename));

            Assert.That(clonedMailAttachment.Content, Is.Not.SameAs(mailAttachment.Content));
            Assert.That(clonedMailAttachment.Content, Is.EquivalentTo(mailAttachment.Content));
        }
    }
}
