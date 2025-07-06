//-----------------------------------------------------------------------
// <copyright file="IClipBoardWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface ClipBoard Wrapper
    /// </summary>
    public interface IClipBoardWrapper
    {
        /// <summary>
        /// Stores <see cref="F:System.Windows.DataFormats.UnicodeText" /> data on the Clipboard.
        /// </summary>
        /// <param name="text">A string that contains the <see cref="F:System.Windows.DataFormats.UnicodeText" /> data to store on the Clipboard.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="text" /> is <see langword="null" />.
        /// </exception>
        void SetText(String text);

        /// <summary>
        /// Returns a string containing the <see cref="F:System.Windows.DataFormats.UnicodeText" /> data on the Clipboard.
        /// </summary>
        /// <returns>A string containing the <see cref="F:System.Windows.DataFormats.UnicodeText" /> data , or an empty string if no <see cref="F:System.Windows.DataFormats.UnicodeText" /> data is available on the Clipboard.</returns>
        String GetText();
    }
}
