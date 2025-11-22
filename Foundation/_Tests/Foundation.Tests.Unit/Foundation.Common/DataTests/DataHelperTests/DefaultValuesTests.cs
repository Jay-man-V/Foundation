//-----------------------------------------------------------------------
// <copyright file="DefaultValuesTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;
using System.Drawing.Imaging;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

using FEnums = Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Common.DataTests.DataHelperTests
{
    /// <summary>
    /// The Default Values class
    /// </summary>
    [TestFixture]
    public class DefaultValuesTests : UnitTestBase
    {
        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultBoolean()
        {
            const Boolean expected = false;
            Boolean actual = DataHelpers.DefaultBoolean;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultEntityId()
        {
            EntityId expected = new EntityId(-1);
            EntityId actual = DataHelpers.DefaultEntityId;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultAppId()
        {
            AppId expected = new AppId(-1);
            AppId actual = DataHelpers.DefaultAppId;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultLogId()
        {
            LogId expected = new LogId(-1);
            LogId actual = DataHelpers.DefaultLogId;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultTaskStatus()
        {
            FEnums.TaskStatus expected = FEnums.TaskStatus.NotSet;
            FEnums.TaskStatus actual = DataHelpers.DefaultTaskStatus;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultLogSeverity()
        {
            LogSeverity expected = LogSeverity.NotSet;
            LogSeverity actual = DataHelpers.DefaultLogSeverity;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultEmailAddress()
        {
            EmailAddress expected = new EmailAddress();
            EmailAddress actual = DataHelpers.DefaultEmailAddress;

            Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultString()
        {
            String expected = String.Empty;
            String actual = DataHelpers.DefaultString;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultDateTime()
        {
            DateTime expected = DateTime.MinValue;
            DateTime actual = DataHelpers.DefaultDateTime;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultDate()
        {
            DateTime expected = DateTime.MinValue.Date;
            DateTime actual = DataHelpers.DefaultDate;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultTimespan()
        {
            TimeSpan expected = TimeSpan.Zero;
            TimeSpan actual = DataHelpers.DefaultTimeSpan;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultByteArray()
        {
            Byte[] expected = [0];
            Byte[] actual = DataHelpers.DefaultByteArray;

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultGuid()
        {
            Guid expected = Guid.Empty;
            Guid actual = DataHelpers.DefaultGuid;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultImage()
        {
            Int32 width = 1;
            Int32 height = 1;

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.FillRectangle(Brushes.Transparent, 0, 0, width, height);
            }

            MemoryStream ms = new MemoryStream();

            bmp.Save(ms, ImageFormat.Bmp);

            Image expected = Image.FromStream(ms);

            Image actual = DataHelpers.DefaultImage;

            Assert.That(actual.ToByteArray(), Is.EquivalentTo(expected.ToByteArray()));
        }
    }
}
