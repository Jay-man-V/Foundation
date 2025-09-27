//-----------------------------------------------------------------------
// <copyright file="EmailAddress.OtherTests.cs" company="JDV Software Ltd">
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
        /// Tests the lengths.
        /// </summary>
        [TestCase]
        public void Test_Lengths()
        {
            String exceedsLocal = "@valid.com".PadLeft(80, 'a');
            String exceedsDomain = "valid@".PadRight(300, 'a');
            exceedsDomain = String.Concat(exceedsDomain, ".com");

            EmailAddress invalidLocal = new EmailAddress(exceedsLocal);
            EmailAddress invalidDomain = new EmailAddress(exceedsDomain);

            Assert.That(invalidLocal.IsValid, Is.EqualTo(false));
            Assert.That(invalidDomain.IsValid, Is.EqualTo(false));
        }
    }
}
