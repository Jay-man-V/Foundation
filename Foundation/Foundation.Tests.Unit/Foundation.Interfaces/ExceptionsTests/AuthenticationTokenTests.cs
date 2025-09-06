//-----------------------------------------------------------------------
// <copyright file="AuthenticationTokenExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The AuthenticationTokenExceptionTests Tests
    /// </summary>
    [TestFixture]
    public class AuthenticationTokenExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            EntityId userProfileId = new EntityId(123);
            String message = LocationUtils.GetFunctionName();

            String errorMessage = LocationUtils.GetFunctionName();

            AuthenticationTokenException atException = new AuthenticationTokenException(userProfileId, message);

            Assert.That(atException.UserProfileId, Is.EqualTo(userProfileId));

            Assert.That(atException.Message, Is.EqualTo(errorMessage));
            Assert.That(atException.GetBaseException().Message, Is.EqualTo(errorMessage));
            Assert.That(atException.InnerException, Is.EqualTo(null));
        }
    }
}
