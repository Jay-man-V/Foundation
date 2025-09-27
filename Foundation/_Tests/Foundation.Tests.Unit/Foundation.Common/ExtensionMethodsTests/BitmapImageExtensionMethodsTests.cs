//-----------------------------------------------------------------------
// <copyright file="BitmapImageExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Windows.Media.Imaging;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Bitmap Image Extension tests
    /// </summary>
    [TestFixture]
    public class BitmapImageExtensionMethodsTests : UnitTestBase
    {
        private BitmapImage LoadBitmapImage()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            String location = assembly.Location;
            FileInfo fileInfo = new FileInfo(location);
            String imagePath = Path.Combine(fileInfo.DirectoryName!, @".Support\SampleDocuments\32BitColour_16x16.bmp");
            BitmapImage retVal = new BitmapImage(new Uri(imagePath));

            return retVal;
        }

        [TestCase]
        public void Test_CompareAsByteArray_1()
        {
            //BitmapImage i1 = LoadBitmapImage();
            //BitmapImage i2 = LoadBitmapImage();

            //Boolean result1 = i1.CompareAsByteArray(i2);
            //Boolean result2 = i2.CompareAsByteArray(i1);

            //Assert.That(result1, Is.EqualTo(true));
            //Assert.That(result2, Is.EqualTo(true));
        }
    }
}
