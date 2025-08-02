//-----------------------------------------------------------------------
// <copyright file="SystemFolders.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources
{
    /// <summary>
    /// Defines constants to access the standard System Folders
    /// </summary>
    public static class SystemFolders
    {
        /// <summary>
        /// The temporary directory
        /// </summary>
        public static String TempDirectory => Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine) ?? @"C:\Windows\Temp"; //: TODO - %SystemRoot%\TEMP
    }
}
