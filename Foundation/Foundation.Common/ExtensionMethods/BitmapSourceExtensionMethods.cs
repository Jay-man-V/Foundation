//-----------------------------------------------------------------------
// <copyright file="BitmapSourceExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.IO;
using System.Windows.Media.Imaging;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the BitmapSourceExtensionMethods
    /// </summary>
    public static class BitmapSourceExtensionMethods
    {
        ///// <summary>
        ///// Converts the BitmapImage to a Byte[] representation
        ///// </summary>
        ///// <param name="currentValue">BitmapImage to convert</param>
        ///// <returns>Byte[] of BitmapImage</returns>
        //public static Byte[] ToByteArray(this BitmapSource currentValue)
        //{
        //    Byte[] retVal = null;

        //    if (currentValue.IsNotNull())
        //    {
        //        BmpBitmapEncoder encoder = new BmpBitmapEncoder();
        //        encoder.Frames.Add(BitmapFrame.Create(currentValue));
        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            encoder.Save(memoryStream);
        //            retVal = memoryStream.ToArray();
        //        }
        //    }

        //    return retVal;
        //}


        ///// <summary>
        ///// Compares the BitmapImage to <paramref name="compareTo"/> by first comparing both to Byte Arrays
        ///// </summary>
        ///// <param name="currentValue">The current value.</param>
        ///// <param name="compareTo">The image to compare to</param>
        ///// <returns>
        /////   <c>true</c> if the BitmapImage are the same; otherwise, <c>false</c>.
        ///// </returns>
        //public static Boolean CompareAsByteArray(this BitmapSource currentValue, BitmapSource compareTo)
        //{
        //    Boolean retVal = false;

        //    Byte[] currentValueByteArray = currentValue.ToByteArray();
        //    Byte[] compareToByteArray = compareTo.ToByteArray();

        //    retVal = StructuralComparisons.StructuralEqualityComparer.Equals(currentValueByteArray, compareToByteArray);

        //    return retVal;
        //}
    }
}
