//-----------------------------------------------------------------------
// <copyright file="CopyToClipBoardEventArgs.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// The CopyToClipBoardEventArgs class
    /// </summary>
    public class CopyToClipBoardEventArgs
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CopyToClipBoardEventArgs"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public CopyToClipBoardEventArgs(String data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public String Data { get; private set; }
    }
}
