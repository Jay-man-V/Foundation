//-----------------------------------------------------------------------
// <copyright file="DirectoryAlreadyExistsException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// DirectoryAlreadyExistsException - raised when a check for a directory already exists when it is not expected to
    /// </summary>
    public class DirectoryAlreadyExistsException : ApplicationException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DirectoryAlreadyExistsException"/> class.
        /// </summary>
        public DirectoryAlreadyExistsException
        (
            String message,
            String directoryPath
        ) :
            base
            (
                message
            )
        {
            DirectoryPath = directoryPath;
        }

        public String DirectoryPath { get; }
    }
}
