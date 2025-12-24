//-----------------------------------------------------------------------
// <copyright file="ByteExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Byte Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class ByteExtensionMethodsTests : UnitTestBase
    {
        [TestCase("AQIDBAUGBwgJCg==", "1, 2, 3, 4, 5, 6, 7, 8, 9, 10")]
        public void Test_ToBase64String(String expected, String inputString)
        {
            Byte[] input = inputString.Split(',').Select(Byte.Parse).ToArray();
            String actualBase64 = input.ToBase64();

            Assert.That(actualBase64, Is.EqualTo(expected));
        }

        [TestCase(true, 75, 50, 100, "True")]
        [TestCase(false, 10, 50, 100, "False")]
        [TestCase(true, 100, 100, 100, "SameValue")]
        [TestCase(true, 50, 50, 100, "StartSameValue")]
        [TestCase(true, 100, 50, 100, "EndSameValue")]
        public void Test_IsBetween(Boolean expected, Byte workingValue, Byte lowerValue, Byte upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, null, 50, 100, "Null")]
        [TestCase(true, 75, 50, 100, "True")]
        [TestCase(false, 10, 50, 100, "False")]
        [TestCase(true, 100, 100, 100, "SameValue")]
        [TestCase(true, 50, 50, 100, "StartSameValue")]
        [TestCase(true, 100, 50, 100, "EndSameValue")]
        public void Test_Nullable_IsBetween(Boolean expected, Byte? workingValue, Byte lowerValue, Byte upperValue, String comment)
        {
            Boolean actualResult = workingValue.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }
    }
}
