//-----------------------------------------------------------------------
// <copyright file="LocationUtilsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.UtilsTests
{
    /// <summary>
    /// The Location Utils Tests
    /// </summary>
    [TestFixture]
    public class LocationUtilsTests : UnitTestBase
    {
        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ClassName()
        {
            String expectedClassName = this.GetType().Name;
            String actualActualClassName = LocationUtils.GetClassName();

            Assert.That(actualActualClassName, Is.EqualTo(expectedClassName));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_FunctionName()
        {
            String expectedFunctionName = "Test_FunctionName";
            String actualFunctionName = LocationUtils.GetFunctionName();

            Assert.That(actualFunctionName, Is.EqualTo(expectedFunctionName));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_FullyQualifiedFunctionName()
        {
            String expectedFunctionName = $"{GetType()}.Test_FullyQualifiedFunctionName";
            String actualFunctionName = LocationUtils.GetFullyQualifiedFunctionName();

            Assert.That(actualFunctionName, Is.EqualTo(expectedFunctionName));
        }
    }
}
