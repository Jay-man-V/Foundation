//-----------------------------------------------------------------------
// <copyright file="UserLogonExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The UserLogonExceptionTests Tests
    /// </summary>
    [TestFixture]
    public class UserLogonExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            String userCredentials = RunTimeEnvironmentSettings.UserFullLogonName;
            String processName = UserLogonException.ApplicationSystemLogon;

            String errorMessage = UserLogonException.CannotLocateUserCredentials;

            UserLogonException exception = new UserLogonException(TestingApplicationId, RunTimeEnvironmentSettings.UserFullLogonName);

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
            String processName = UserLogonException.ApplicationSystemLogon;

            String errorMessage = "Please enter user name";

            UserLogonException exception = new UserLogonException(TestingApplicationId, userCredentials, errorMessage);

            Assert.That(exception.UserCredentials, Is.EqualTo(userCredentials));
            Assert.That(exception.ProcessName, Is.EqualTo(processName));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
            Assert.That(exception.GetBaseException().Message, Is.EqualTo(errorMessage));
            Assert.That(exception.InnerException, Is.EqualTo(null));
        }
    }
}
