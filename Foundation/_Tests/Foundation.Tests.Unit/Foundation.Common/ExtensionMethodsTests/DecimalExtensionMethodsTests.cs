//-----------------------------------------------------------------------
// <copyright file="DecimalExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Decimal Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class DecimalExtensionMethodsTests : UnitTestBase
    {
        [TestCase(true, 20.10, 20.00, 21.00, "True")]
        [TestCase(false, 20.10, 30.00, 31.00, "False")]
        [TestCase(true, 20.00, 20.00, 20.00, "SameValue")]
        [TestCase(true, 20.00, 20.00, 21.00, "StartSameValue")]
        [TestCase(true, 21.00, 20.10, 21.00, "EndSameValue")]
        public void Test_IsBetween_True(Boolean expected, Decimal workingValue, Decimal lowerValue, Decimal upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, null, 20.00, 21.00, "Null")]
        [TestCase(true, 20.10, 20.00, 21.00, "True")]
        [TestCase(false, 20.10, 30.00, 31.00, "False")]
        [TestCase(true, 20.00, 20.00, 20.00, "SameValue")]
        [TestCase(true, 20.00, 20.00, 21.00, "StartSameValue")]
        [TestCase(true, 21.00, 20.00, 21.00, "EndSameValue")]
        public void Test_Nullable_IsBetween(Boolean expected, Decimal? workingValue, Decimal lowerValue, Decimal upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }
    }
}
