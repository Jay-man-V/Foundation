//-----------------------------------------------------------------------
// <copyright file="UInt32ExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The UUInt32 Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class UInt32ExtensionMethodsTests : UnitTestBase
    {
        [TestCase(true, 2010u, 2000u, 2100u, "True")]
        [TestCase(false, 2010u, 2100u, 2200u, "False")]
        [TestCase(true, 2010u, 2010u, 2010u, "SameValue")]
        [TestCase(true, 2010u, 2010u, 2100u, "StartSameValue")]
        [TestCase(true, 2100u, 2010u, 2100u, "EndSameValue")]
        public void Test_IsBetween_UInt32(Boolean expected, UInt32 workingValue, UInt32 lowerValue, UInt32 upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(true, 2010u, 2000, 2100, "True")]
        [TestCase(false, 2010u, 2100, 2200, "False")]
        [TestCase(true, 2010u, 2010, 2010, "SameValue")]
        [TestCase(true, 2010u, 2010, 2100, "StartSameValue")]
        [TestCase(true, 2100u, 2010, 2100, "EndSameValue")]
        public void Test_IsBetween_Int32_True(Boolean expected, UInt32 workingValue, Int32 lowerValue, Int32 upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, null, 2000u, 2100u, "Null")]
        [TestCase(true, 2010u, 2000u, 2100u, "True")]
        [TestCase(false, 2010u, 2100u, 2200u, "False")]
        [TestCase(true, 2010u, 2010u, 2010u, "SameValue")]
        [TestCase(true, 2010u, 2010u, 2100u, "StartSameValue")]
        [TestCase(true, 2100u, 2010u, 2100u, "EndSameValue")]
        public void Test_Nullable_IsBetween_UInt32(Boolean expected, UInt32? workingValue, UInt32 lowerValue, UInt32 upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, null, 2000, 2100, "Null")]
        [TestCase(true, 2010u, 2000, 2100, "True")]
        [TestCase(false, 2010u, 2100, 2200, "False")]
        [TestCase(true, 2010u, 2010, 2010, "SameValue")]
        [TestCase(true, 2010u, 2010, 2100, "StartSameValue")]
        [TestCase(true, 2100u, 2010, 2100, "EndSameValue")]
        public void Test_Nullable_IsBetween_Int32(Boolean expected, UInt32? workingValue, Int32 lowerValue, Int32 upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }
    }
}
