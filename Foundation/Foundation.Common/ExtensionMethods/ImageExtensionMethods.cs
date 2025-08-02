//-----------------------------------------------------------------------
// <copyright file="ImageExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Drawing;
using System.IO;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the ImageExtensionMethods
    /// </summary>
    public static class ImageExtensionMethods
    {
        /// <summary>
        /// Converts the Image to a Byte[] representation
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <returns>Byte[] of image</returns>
        public static Byte[] ToByteArray(this Image currentValue)
        {
            Byte[] retVal;
            using (MemoryStream currentValueStream = new())
            {
                currentValue.Save(currentValueStream, currentValue.RawFormat);
                retVal = currentValueStream.ToArray();
            }

            return retVal;
        }

        /// <summary>
        /// Compares the image to <paramref name="compareTo"/> by first comparing both to Byte Arrays
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="compareTo">The image to compare to</param>
        /// <returns>
        ///   <c>true</c> if the images are the same; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean CompareAsByteArray(this Image currentValue, Image compareTo)
        {
            Byte[] currentValueByteArray = currentValue.ToByteArray();
            Byte[] compareToByteArray = compareTo.ToByteArray();

            Boolean retVal = StructuralComparisons.StructuralEqualityComparer.Equals(currentValueByteArray, compareToByteArray);

            return retVal;
        }
    }
}
