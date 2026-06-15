//-----------------------------------------------------------------------
// <copyright file="StringExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The String Extension tests
    /// </summary>
    [TestFixture]
    public class StringExtensionMethodsTests : UnitTestBase
    {
        [TestCase]
        public void Test_IsNullOrEmptyOrWhiteSpace_Null()
        {
            String? val = null;
            Boolean actualResult = val!.IsNullOrEmptyOrWhiteSpace();
            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_IsNullOrEmptyOrWhiteSpace_Empty()
        {
            String val = String.Empty;
            Boolean actualResult = val.IsNullOrEmptyOrWhiteSpace();
            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_IsNullOrEmptyOrWhiteSpace_WhiteSpace()
        {
            String val = "   ";
            Boolean actualResult = val.IsNullOrEmptyOrWhiteSpace();
            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_IsNullOrEmptyOrWhiteSpace_Value()
        {
            String val = "Hello, World!";
            Boolean actualResult = val.IsNullOrEmptyOrWhiteSpace();
            Assert.That(actualResult, Is.EqualTo(false));
        }
    }
}