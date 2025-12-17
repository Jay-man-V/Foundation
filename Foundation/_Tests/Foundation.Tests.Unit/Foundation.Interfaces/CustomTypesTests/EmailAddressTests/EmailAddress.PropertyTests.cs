//-----------------------------------------------------------------------
// <copyright file="EmailAddress.PropertyTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.EmailAddressTests
{
    /// <summary>
    /// Unit Tests for the Email Address type
    /// </summary>
    public partial class EmailAddressTests : UnitTestBase
    {
        /// <summary>
        /// Tests all properties valid email address.
        /// </summary>
        [TestCase]
        public void Test_AllPropertiesValidEmailAddress()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.ValidEmailAddresses)
            {
                EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);

                Assert.That(emailAddress.IsValid, Is.EqualTo(true), originalEmailAddressString);
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(false), originalEmailAddressString);

                String[] emailAddressParts = originalEmailAddressString.Split('@');
                Assert.That(emailAddress.LocalPart, Is.EqualTo(emailAddressParts[0]), originalEmailAddressString);
                Assert.That(emailAddress.DomainName, Is.EqualTo(emailAddressParts[1]), originalEmailAddressString);
            }
        }

        /// <summary>
        /// Tests all properties valid potential typo email address.
        /// </summary>
        [TestCase]
        public void Test_AllPropertiesValidPotentialTypoEmailAddress()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.ValidPotentialTypoEmailAddresses)
            {
                EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);

                Assert.That(emailAddress.IsValid, Is.EqualTo(true), originalEmailAddressString);
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(true), originalEmailAddressString);

                String[] parts = originalEmailAddressString.Split('@');
                String[] workingParts = ["", ""];
                if (parts.Length > 2)
                {
                    workingParts[0] = String.Join("@", parts.Take(parts.Length - 1));
                }
                else
                {
                    workingParts[0] = parts[0];
                }
                workingParts[1] = parts[1];

                Assert.That(emailAddress.LocalPart, Is.EqualTo(workingParts[0]), originalEmailAddressString);
                Assert.That(emailAddress.DomainName, Is.EqualTo(workingParts[1]), originalEmailAddressString);
            }
        }

        /// <summary>
        /// Tests all properties in valid email address.
        /// </summary>
        [TestCase]
        public void Test_AllPropertiesInValidEmailAddress()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.InvalidEmailAddresses)
            {
                EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);

                Assert.That(emailAddress.IsValid, Is.EqualTo(false), originalEmailAddressString);
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(false), originalEmailAddressString);

                Assert.That(String.IsNullOrEmpty(emailAddress.LocalPart), originalEmailAddressString);
                Assert.That(String.IsNullOrEmpty(emailAddress.DomainName), originalEmailAddressString);
            }
        }

        /// <summary>
        /// Tests all properties in valid potential typo email address.
        /// </summary>
        [TestCase]
        public void Test_AllPropertiesInValidPotentialTypoEmailAddress()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.InvalidEmailAddresses)
            {
                EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);

                Assert.That(emailAddress.IsValid, Is.EqualTo(false), originalEmailAddressString);
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(false), originalEmailAddressString);

                Assert.That(String.IsNullOrEmpty(emailAddress.LocalPart), originalEmailAddressString);
                Assert.That(String.IsNullOrEmpty(emailAddress.DomainName), originalEmailAddressString);
            }
        }
    }
}
