//-----------------------------------------------------------------------
// <copyright file="EmailAddressOverrideTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.EmailAddressTests
{
    /// <summary>
    /// Unit Tests for the Email Address type
    /// </summary>
    public partial class EmailAddressTests
    {
        /// <summary>
        /// Tests the base override to string.
        /// </summary>
        [TestCase]
        public void Test_BaseOverrideToString()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
            {
                Object emailAddressObject = new EmailAddress(originalEmailAddressString);
                Assert.That(emailAddressObject, Is.Not.EqualTo(null));
                Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());

                String? emailAddressObjectString = emailAddressObject.ToString();
                Assert.That(emailAddressObjectString, Is.EqualTo(originalEmailAddressString), $"Email Address '{originalEmailAddressString}' did not work");
            }
        }

        /// <summary>
        /// Tests the base override get hash code.
        /// </summary>
        [TestCase]
        public void Test_BaseOverrideGetHashCode()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
            {
                Object emailAddressObject = new EmailAddress(originalEmailAddressString);
                Assert.That(emailAddressObject, Is.Not.EqualTo(null));
                Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());

                Int32 expectedHasCode = originalEmailAddressString.GetHashCode();
                Int32 actualHasCode = emailAddressObject.GetHashCode();
                Assert.That(actualHasCode, Is.EqualTo(expectedHasCode));
            }
        }

        /// <summary>
        /// Tests the base override equals.
        /// </summary>
        [TestCase]
        public void Test_BaseOverrideEquals()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
            {
                Object emailAddressObject = new EmailAddress(originalEmailAddressString);
                Assert.That(emailAddressObject, Is.Not.EqualTo(null));
                Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());

                Boolean equalsString = emailAddressObject.Equals(originalEmailAddressString);
                Assert.That(equalsString, Is.EqualTo(true));

                EmailAddress secondEmailAddress = new EmailAddress(originalEmailAddressString);
                Boolean equalsObject = emailAddressObject.Equals(secondEmailAddress);
                Assert.That(equalsObject, Is.EqualTo(true));
            }
        }
    }
}
