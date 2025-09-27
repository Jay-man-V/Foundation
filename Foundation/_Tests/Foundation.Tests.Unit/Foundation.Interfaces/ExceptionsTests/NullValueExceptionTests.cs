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
    /// The NullValueException Tests
    /// </summary>
    [TestFixture]
    public class NullValueExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            String errorMessage = "Null value received";

            NullValueException exception = new NullValueException("Null value received");

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
            Assert.That(exception.GetBaseException().Message, Is.EqualTo(errorMessage));
            Assert.That(exception.InnerException, Is.EqualTo(null));
        }
    }
}
