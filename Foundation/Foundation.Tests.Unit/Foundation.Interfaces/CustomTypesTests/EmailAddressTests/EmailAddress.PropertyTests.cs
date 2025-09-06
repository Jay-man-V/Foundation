//-----------------------------------------------------------------------
// <copyright file="EmailAddressPropertyTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Common.CustomTypesTests.EmailAddressTests
{
    /// <summary>
    /// Unit Tests for the Email Address type
    /// </summary>
    public partial class EmailAddressTests
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

                Assert.That(emailAddress.IsValid, Is.EqualTo(true));
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(false));

                String[] emailAddressParts = originalEmailAddressString.Split('@');
                Assert.That(emailAddress.LocalPart, Is.EqualTo(emailAddressParts[0]));
                Assert.That(emailAddress.DomainName, Is.EqualTo(emailAddressParts[1]));
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

                Assert.That(emailAddress.IsValid, Is.EqualTo(true));
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(true));

                String[] emailAddressParts = originalEmailAddressString.Split('@');
                Assert.That(emailAddress.LocalPart, Is.EqualTo(emailAddressParts[0]));
                Assert.That(emailAddress.DomainName, Is.EqualTo(emailAddressParts[1]));
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

                Assert.That(emailAddress.IsValid, Is.EqualTo(false));
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(false));

                Assert.That(String.IsNullOrEmpty(emailAddress.LocalPart));
                Assert.That(String.IsNullOrEmpty(emailAddress.DomainName));
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

                Assert.That(emailAddress.IsValid, Is.EqualTo(false));
                Assert.That(emailAddress.HasPotentialTypo, Is.EqualTo(false));

                Assert.That(String.IsNullOrEmpty(emailAddress.LocalPart));
                Assert.That(String.IsNullOrEmpty(emailAddress.DomainName));
            }
        }
    }
}
