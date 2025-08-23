//-----------------------------------------------------------------------
// <copyright file="FileAlreadyExistsException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// FileAlreadyExistsException - raised when a check for a file already exists when it is not expected to
    /// </summary>
    public class FileAlreadyExistsException : ApplicationException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FileAlreadyExistsException"/> class.
        /// </summary>
        public FileAlreadyExistsException
        (
            String message,
            String filePath
        ) :
            base
            (
                message
            )
        {
            FilePath = filePath;
        }

        public String FilePath { get; }
    }
}
