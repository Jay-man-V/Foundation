//-----------------------------------------------------------------------
// <copyright file="UserCredentialsExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The UserCredentialsExceptionTests Tests
    /// </summary>
    [TestFixture]
    public class UserCredentialsExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            String userCredentials = $@"{Environment.UserDomainName}\{Environment.UserName}";
            String processName = "Application/System Logon";

            String errorMessage = "Cannot locate user credentials";

            UserCredentialsException exception = new UserCredentialsException(CoreInstance.ApplicationId, userCredentials, processName, errorMessage);

            Assert.That(exception.UserCredentials, Is.EqualTo(userCredentials));
            Assert.That(exception.ProcessName, Is.EqualTo(processName));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
            Assert.That(exception.GetBaseException().Message, Is.EqualTo(errorMessage));
            Assert.That(exception.InnerException, Is.EqualTo(null));
        }

        [TestCase]
        public void Test_Constructor_2()
        {
            String userCredentials = $@"{Environment.UserDomainName}\{Environment.UserName}";
            String processName = "Unit Test Process";
            String innerExceptionMessage = "Inner InvalidTimeZoneException";
            InvalidTimeZoneException innerException = new InvalidTimeZoneException(innerExceptionMessage);

            String errorMessage = "Please enter user name";

            UserCredentialsException exception = new UserCredentialsException(CoreInstance.ApplicationId, userCredentials, processName, errorMessage, innerException);

            Assert.That(exception.UserCredentials, Is.EqualTo(userCredentials));
            Assert.That(exception.ProcessName, Is.EqualTo(processName));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
            Assert.That(exception.GetBaseException().Message, Is.EqualTo(innerExceptionMessage));
            Assert.That(exception.InnerException, Is.Not.EqualTo(null));
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
            Assert.That(exception.InnerException.Message, Is.EqualTo(innerExceptionMessage));
        }
    }
}
