//-----------------------------------------------------------------------
// <copyright file="ByteArrayToMediaImageConverter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Foundation.Views.Converters
{
    /// <summary>
    /// Converts a <see cref="Byte"/> array to a <see cref="BitmapImage"/>
    /// </summary>
    /// <seealso cref="IValueConverter" />
    [ValueConversion(typeof(Byte[]), typeof(BitmapSource))]
    public class ByteArrayToMediaImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        public Object? Convert(Object? value, Type targetType, Object? parameter, CultureInfo culture)
        {
            BitmapImage? retVal = null;
            if (value == null ||
                value.GetType() != typeof(Byte[])) return retVal;

            Byte[] byteArray = (Byte[])value;

            if (byteArray.Length > 1)
            {
                MemoryStream mem1 = new MemoryStream(byteArray);

                retVal = new BitmapImage();
                mem1.Seek(0, SeekOrigin.Begin);
                //retVal.BeginInit();
                retVal.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                retVal.CacheOption = BitmapCacheOption.Default;
                retVal.UriSource = null;
                retVal.StreamSource = mem1;
                //retVal.EndInit();
                //retVal.Freeze();
            }

            return retVal;
        }

        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        public Object? ConvertBack(Object? value, Type targetType, Object? parameter, CultureInfo culture)
        {
            const Bitmap? retVal = null;

            return retVal;
        }
    }
}
