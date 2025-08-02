//-----------------------------------------------------------------------
// <copyright file="UserFolders.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources
{
    /// <summary>
    /// Defines constants to access the standard User Folders
    /// </summary>
    public static class UserFolders
    {
        /// <summary>
        /// My documents
        /// </summary>
        public static String MyDocuments => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        /// <summary>
        /// The temporary directory
        /// </summary>
        public static String TempDirectory => Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User) ?? @"C:\Windows\Temp"; //: TODO - %USERPROFILE%\AppData\Local\Temp 
    }
}
