//-----------------------------------------------------------------------
// <copyright file="ToBase64Tests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.ByteExtensionMethodsTests
{
    /// <summary>
    /// The Byte Array Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class ToBase64Tests : UnitTestBase
    {

        [TestCase]
        public void Test_ToBase64String()
        {
            String expectedBase64 = "AQIDBAUGBwgJCg==";

            Byte[] input = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            String actualBase64 = input.ToBase64();

            Assert.That(actualBase64, Is.EqualTo(expectedBase64));
        }
    }
}
