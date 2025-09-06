//-----------------------------------------------------------------------
// <copyright file="EmailAddressConstructorTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Common.CustomTypesTests.EmailAddressTests
{
    /// <summary>
    /// Unit Tests for the Email Address type
    /// </summary>
    public partial class EmailAddressTests
    {
        [TestCase]
        public void Test_CountConstructors()
        {
            Type thisType = typeof(EmailAddress);
            ConstructorInfo[] constructorInfos = thisType.GetConstructors();
            Assert.That(constructorInfos.Count(), Is.EqualTo(2));
        }

        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestCase]
        public void Test_ConstructorDefault()
        {
            Object emailAddressObject = new EmailAddress();

            Assert.That(emailAddressObject, Is.Not.EqualTo(null));
            Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());
        }

        /// <summary>
        /// Tests the string constructor.
        /// </summary>
        [TestCase]
        public void Test_ConstructorString()
        {
            foreach (String emailAddressString in EmailAddressValues.AllEmailAddresses)
            {
                Object emailAddressObject = new EmailAddress(emailAddressString);

                Assert.That(emailAddressObject, Is.Not.EqualTo(null), $"Failed to create EmailAddress object for '{emailAddressString}'");

                String generatedObjectType = emailAddressObject.GetType().ToString();
                Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>(), $"Generated object '{generatedObjectType}' does not match expected EmailAddress type");

                String emailAddressObjectValue = emailAddressObject.ToString();
                Assert.That(emailAddressObjectValue, Is.EqualTo(emailAddressString), $"Email addresses do not match input: '{emailAddressString}', from object: '{emailAddressObjectValue}'");
            }
        }

        /// <summary>
        /// Tests the constructor with an empty string.
        /// </summary>
        [TestCase]
        public void Test_ConstructorEmptyString()
        {
            Object emailAddressObject = new EmailAddress(String.Empty);

            Assert.That(emailAddressObject, Is.Not.EqualTo(null));
            Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());
            String emailAddressString = emailAddressObject.ToString();
            Assert.That(emailAddressString, Is.EqualTo(String.Empty), "EmailAddress with empty String failed");
        }

        /// <summary>
        /// Tests the constructor null email address.
        /// </summary>
        [TestCase]
        public void Test_ConstructorNullEmailAddress()
        {
            EmailAddress nullEmailAddress = null;
            EmailAddress emailAddressObject = new EmailAddress(nullEmailAddress);
            Assert.That(emailAddressObject, Is.Not.EqualTo(null));
            Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());
            Assert.That(emailAddressObject.ToString(), Is.EqualTo(String.Empty), "EmailAddress with null Email Address failed");
        }

        /// <summary>
        /// Tests the constructor empty email address.
        /// </summary>
        [TestCase]
        public void Test_ConstructorEmptyEmailAddress()
        {
            EmailAddress emptyEmailAddress = new EmailAddress(String.Empty);
            EmailAddress emailAddressObject = new EmailAddress(emptyEmailAddress);
            Assert.That(emailAddressObject, Is.Not.EqualTo(null));
            Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());
            Assert.That(emailAddressObject.ToString(), Is.EqualTo(String.Empty), "EmailAddress with empty Email Address failed");
        }

        /// <summary>
        /// Tests the constructor empty email address2.
        /// </summary>
        [TestCase]
        public void Test_ConstructorEmptyEmailAddress2()
        {
            const String emptyString = "";
            EmailAddress emptyEmailAddress = new EmailAddress(emptyString);
            EmailAddress emailAddressObject = new EmailAddress(emptyEmailAddress);
            Assert.That(emailAddressObject, Is.Not.EqualTo(null));
            Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());
            Assert.That(emailAddressObject.ToString(), Is.EqualTo(String.Empty), "EmailAddress with empty Email Address failed");
        }

        /// <summary>
        /// Tests the constructor email address.
        /// </summary>
        [TestCase]
        public void Test_ConstructorEmailAddress()
        {
            foreach (String originalEmailAddressString in EmailAddressValues.AllEmailAddresses)
            {
                EmailAddress emailAddress = new EmailAddress(originalEmailAddressString);
                Object emailAddressObject = new EmailAddress(emailAddress);
                Assert.That(emailAddressObject, Is.Not.EqualTo(null));
                Assert.That(emailAddressObject, Is.InstanceOf<EmailAddress>());
                String emailAddressString = emailAddressObject.ToString();
                Assert.That(emailAddressString, Is.EqualTo(emailAddressString), $"Email Address '{emailAddressString}' did not work");
            }
        }
    }
}
