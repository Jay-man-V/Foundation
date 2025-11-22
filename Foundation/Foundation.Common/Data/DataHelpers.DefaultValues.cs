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
        /// Gets a default boolean (false).
        /// </summary>
        /// <value>
        ///   <c>true</c> if [default boolean]; otherwise, <c>false</c>.
        /// </value>
        public static Boolean DefaultBoolean => false;

        /// <summary>
        /// Gets the default entity identifier (-1).
        /// </summary>
        /// <value>
        /// The default entity identifier.
        /// </value>
        public static EntityId DefaultEntityId => new EntityId(-1);

        /// <summary>
        /// Gets the default application identifier (-1).
        /// </summary>
        /// <value>
        /// The default application identifier.
        /// </value>
        public static AppId DefaultAppId => new AppId(-1);

        /// <summary>
        /// Gets the default log identifier (-1).
        /// </summary>
        /// <value>
        /// The default log identifier.
        /// </value>
        public static LogId DefaultLogId => new LogId(-1);

        /// <summary>
        /// Gets the default task status (NotSet).
        /// </summary>
        /// <value>
        /// The default task status.
        /// </value>
        public static FEnums.TaskStatus DefaultTaskStatus => FEnums.TaskStatus.NotSet;

        /// <summary>
        /// Gets the default log severity (NotSet).
        /// </summary>
        /// <value>
        /// The default log severity.
        /// </value>
        public static LogSeverity DefaultLogSeverity => LogSeverity.NotSet;

        /// <summary>
        /// Gets the default email address (Empty).
        /// </summary>
        /// <value>
        /// The default email address.
        /// </value>
        public static EmailAddress DefaultEmailAddress => new EmailAddress();

        /// <summary>
        /// Gets the default string (String.Empty).
        /// </summary>
        /// <value>
        /// The default string.
        /// </value>
        public static String DefaultString => String.Empty;

        /// <summary>
        /// Gets the default date time (DateTime.MinValue).
        /// </summary>
        /// <value>
        /// The default date time.
        /// </value>
        public static DateTime DefaultDateTime => DateTime.MinValue;

        /// <summary>
        /// Gets the default date (DateTime.MinValue.Date).
        /// </summary>
        /// <value>
        /// The default date.
        /// </value>
        public static DateTime DefaultDate => DateTime.MinValue.Date;

        /// <summary>
        /// Gets the default time span (TimeSpan.Zero).
        /// </summary>
        /// <value>
        /// The default time span.
        /// </value>
        public static TimeSpan DefaultTimeSpan => TimeSpan.Zero;

        /// <summary>
        /// Gets the default Byte array ([0]).
        /// </summary>
        /// <value>
        /// The default Byte array.
        /// </value>
        public static Byte[] DefaultByteArray => [0];

        /// <summary>
        /// Gets the default guid (Guid.Empty).
        /// </summary>
        /// <value>
        /// The default guid.
        /// </value>
        public static Guid DefaultGuid => Guid.Empty;

        /// <summary>
        /// Gets the default image (1x1 - Transparent).
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

                Bitmap bmp = new Bitmap(width, height);
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    graphics.FillRectangle(Brushes.Transparent, 0, 0, width, height);
                }

                MemoryStream ms = new MemoryStream();

                bmp.Save(ms, ImageFormat.Bmp);

                Image retVal = Bitmap.FromStream(ms);

                return retVal;
            }
        }
    }
}
