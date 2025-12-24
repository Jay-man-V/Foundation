//-----------------------------------------------------------------------
// <copyright file="Int32ExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Int32 Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class Int32ExtensionMethodsTests : UnitTestBase
    {
        [TestCase(true, 2010, 2000, 2100, "True")]
        [TestCase(false, 2010, 2100, 2200, "False")]
        [TestCase(true, 2010, 2010, 2010, "SameValue")]
        [TestCase(true, 2010, 2010, 2100, "StartSameValue")]
        [TestCase(true, 2100, 2010, 2100, "EndSameValue")]
        public void Test_IsBetween(Boolean expected, Int32 workingValue, Int32 lowerValue, Int32 upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, null, 2000, 2100, "Null")]
        [TestCase(true, 2010, 2000, 2100, "True")]
        [TestCase(false, 2010, 2100, 2200, "False")]
        [TestCase(true, 2010, 2010, 2010, "SameValue")]
        [TestCase(true, 2010, 2010, 2100, "StartSameValue")]
        [TestCase(true, 2100, 2010, 2100, "EndSameValue")]
        public void Test_Nullable_IsBetween_True(Boolean expected, Int32? workingValue, Int32 lowerValue, Int32 upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }
    }
}
