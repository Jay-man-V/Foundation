//-----------------------------------------------------------------------
// <copyright file="ImageExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Image Extension tests
    /// </summary>
    [TestFixture]
    public class ImageExtensionMethodsTests : UnitTestBase
    {
        private Image LoadBitmap()
        {
            Image retVal = Image.FromFile(@".Support\SampleDocuments\32BitColour_16x16.bmp");

            return retVal;
        }

        [TestCase]
        public void Test_CompareAsByteArray_1()
        {
            Image i1 = LoadBitmap();
            Image i2 = LoadBitmap();

            Boolean result1 = i1.CompareAsByteArray(i2);
            Boolean result2 = i2.CompareAsByteArray(i1);

            Assert.That(result1, Is.EqualTo(true));
            Assert.That(result2, Is.EqualTo(true));
        }
    }
}
