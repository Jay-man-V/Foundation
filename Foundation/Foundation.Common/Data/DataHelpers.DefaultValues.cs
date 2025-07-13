//-----------------------------------------------------------------------
// <copyright file="DataHelpers.DefaultValues.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using Foundation.Interfaces;

using FEnums = Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the DataHelpers
    /// </summary>
    public static partial class DataHelpers
    {
        /// <summary>
        /// Gets a value indicating whether [default boolean].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [default boolean]; otherwise, <c>false</c>.
        /// </value>
        public static Boolean DefaultBoolean => false;

        /// <summary>
        /// Gets the default entity identifier.
        /// </summary>
        /// <value>
        /// The default entity identifier.
        /// </value>
        public static EntityId DefaultEntityId => new(-1);

        /// <summary>
        /// Gets the default application identifier.
        /// </summary>
        /// <value>
        /// The default application identifier.
        /// </value>
        public static AppId DefaultAppId => new(-1);

        /// <summary>
        /// Gets the default log identifier.
        /// </summary>
        /// <value>
        /// The default log identifier.
        /// </value>
        public static LogId DefaultLogId => new(-1);

        /// <summary>
        /// Gets the default task status.
        /// </summary>
        /// <value>
        /// The default task status.
        /// </value>
        public static FEnums.TaskStatus DefaultTaskStatus => FEnums.TaskStatus.NotSet;

        /// <summary>
        /// Gets the default log severity.
        /// </summary>
        /// <value>
        /// The default log severity.
        /// </value>
        public static LogSeverity DefaultLogSeverity => LogSeverity.NotSet;

        /// <summary>
        /// Gets the default email address.
        /// </summary>
        /// <value>
        /// The default email address.
        /// </value>
        public static EmailAddress DefaultEmailAddress => new();

        /// <summary>
        /// Gets the default string.
        /// </summary>
        /// <value>
        /// The default string.
        /// </value>
        public static String DefaultString => String.Empty;

        /// <summary>
        /// Gets the default date time.
        /// </summary>
        /// <value>
        /// The default date time.
        /// </value>
        public static DateTime DefaultDateTime => DateTime.MinValue;

        /// <summary>
        /// Gets the default date.
        /// </summary>
        /// <value>
        /// The default date.
        /// </value>
        public static DateTime DefaultDate => DateTime.MinValue.Date;

        /// <summary>
        /// Gets the default time span.
        /// </summary>
        /// <value>
        /// The default time span.
        /// </value>
        public static TimeSpan DefaultTimeSpan => TimeSpan.Zero;

        /// <summary>
        /// Gets the default byte array.
        /// </summary>
        /// <value>
        /// The default byte array.
        /// </value>
        public static Byte[] DefaultByteArray { get { return [0]; } }

        /// <summary>
        /// Gets the default guid.
        /// </summary>
        /// <value>
        /// The default guid.
        /// </value>
        public static Guid DefaultGuid => Guid.Empty;

        /// <summary>
        /// Gets the default image.
        /// </summary>
        /// <value>
        /// The default image.
        /// </value>
        public static Image DefaultImage
        {
            get
            {
                Int32 width = 1;
                Int32 height = 1;
                //Bitmap bmp = new Bitmap(width, height);
                //MemoryStream ms = new MemoryStream();

                //bmp.Save(ms, ImageFormat.Bmp);

                //Image retVal = Bitmap.FromStream(ms);

                Bitmap bmp = new(width, height);
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    graphics.FillRectangle(Brushes.Transparent, 0, 0, width, height);
                }

                MemoryStream ms = new();

                bmp.Save(ms, ImageFormat.Bmp);

                Image retVal = Bitmap.FromStream(ms);

                return retVal;
            }
        }
    }
}
