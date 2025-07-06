//-----------------------------------------------------------------------
// <copyright file="KnownFolders.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Runtime.InteropServices;

using Foundation.Interfaces;

namespace Foundation.Resources
{
    /// <summary>
    /// Class containing methods to retrieve specific file system paths.
    /// </summary>
    public static class KnownFolders
    {
        [DllImport("Shell32.dll")]
        private static extern Int32 SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, UInt32 dwFlags, IntPtr hToken, out IntPtr ppszPath);

        /// <summary>
        /// Enum for known system folders
        /// </summary>
        [Flags]
        internal enum KnownFolderFlags : UInt32
        {
            SimpleIdList = 0x00000100,
            NotParentRelative = 0x00000200,
            DefaultPath = 0x00000400,
            Init = 0x00000800,
            NoAlias = 0x00001000,
            DoNotUnExpand = 0x00002000,
            DoNotVerify = 0x00004000,
            Create = 0x00008000,
            NoAppContainerRedirection = 0x00010000,
            AliasOnly = 0x80000000
        }

        /// <summary>
        /// The known folder guids
        /// </summary>
        private static readonly String[] KnownFolderGuids =
        [
            "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
            "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", // Desktop
            "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", // Documents
            "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
            "{1777F761-68AD-4D8A-87BD-30B759FA33DD}", // Favorites
            "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
            "{4BD8D571-6D19-48D3-BE97-422220080E43}", // Music
            "{33E28130-4E1E-4676-835A-98395C3BC3BB}", // Pictures
            "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // SavedGames
            "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // SavedSearches
            "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", // Videos
        ];

        /// <summary>
        /// Gets the current path to the specified known folder as currently configured. This does
        /// not require the folder to exist.
        /// </summary>
        /// <param name="knownFolder">The known folder which current path will be returned.</param>
        /// <returns>The default path of the known folder.</returns>
        /// <exception cref="ExternalException">Thrown if the path
        ///     could not be retrieved.</exception>
        public static String GetPath(KnownFolder knownFolder)
        {
            const Boolean defaultUser = false;
            String retVal = GetPath(knownFolder, defaultUser);
            return retVal;
        }

        /// <summary>
        /// Gets the current path to the specified known folder as currently configured. This does
        /// not require the folder to exist.
        /// </summary>
        /// <param name="knownFolder">The known folder which current path will be returned.</param>
        /// <param name="defaultUser">Specifies if the paths of the default user (user profile
        ///     template) will be used. This requires administrative rights.</param>
        /// <returns>The default path of the known folder.</returns>
        /// <exception cref="ExternalException">Thrown if the path
        ///     could not be retrieved.</exception>
        public static String GetPath(KnownFolder knownFolder, Boolean defaultUser)
        {
            String retVal = GetPath(knownFolder, KnownFolderFlags.DoNotVerify, defaultUser);
            return retVal;
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <param name="knownFolder">The known folder.</param>
        /// <param name="flags">The flags.</param>
        /// <param name="defaultUser">if set to <c>true</c> [default user].</param>
        /// <returns></returns>
        /// <exception cref="ExternalException"></exception>
        internal static String GetPath(KnownFolder knownFolder, KnownFolderFlags flags, Boolean defaultUser)
        {
            Guid folderId = new(KnownFolderGuids[(Int32)knownFolder]);
            IntPtr defaultUserToken = new(defaultUser ? -1 : 0);
            Int32 result = SHGetKnownFolderPath(folderId, (UInt32)flags, defaultUserToken, out IntPtr outPath);

            String retVal;

            if (result >= 0)
            {
                retVal = Marshal.PtrToStringUni(outPath) ?? String.Empty;
                Marshal.FreeCoTaskMem(outPath);
            }
            else
            {
                String errorMessage = $"Unable to retrieve the known folder path '{knownFolder}'. It may not be available on this system.";
                throw new ExternalException(errorMessage, result);
            }

            return retVal;
        }
    }
}
