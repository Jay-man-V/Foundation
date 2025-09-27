//-----------------------------------------------------------------------
// <copyright file="BitmapExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Bitmap Extension tests
    /// </summary>
    [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments")]
    [TestFixture]
    public class BitmapExtensionMethodsTests : UnitTestBase
    {
        private Bitmap LoadBitmap()
        {
            Bitmap retVal = new Bitmap(@".Support\SampleDocuments\32BitColour_16x16.bmp");

            return retVal;
        }

        [TestCase]
        public void Test_CompareAsByteArray_1()
        {
            Bitmap i1 = LoadBitmap();
            Bitmap i2 = LoadBitmap();

            Boolean result1 = i1.CompareAsByteArray(i2);
            Boolean result2 = i2.CompareAsByteArray(i1);

            Assert.That(result1, Is.EqualTo(true));
            Assert.That(result2, Is.EqualTo(true));
        }
    }
}
