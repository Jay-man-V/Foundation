//-----------------------------------------------------------------------
// <copyright file="IntervalType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Standard folders registered with the system. These folders are installed with Windows Vista
    /// and later operating systems, and a computer will have only folders appropriate to it
    /// installed.
    /// </summary>
    public enum KnownFolder
    {
        /// <summary>
        /// Contacts
        /// </summary>
        [Id(0), Display(Order = 1, Name = "Contacts")]
        Contacts = 0,

        /// <summary>
        /// Desktop
        /// </summary>
        [Id(1), Display(Order = 2, Name = "Desktop")]
        Desktop = 1,

        /// <summary>
        /// Documents
        /// </summary>
        [Id(2), Display(Order = 3, Name = "Documents")]
        Documents = 2,

        /// <summary>
        /// Downloads
        /// </summary>
        [Id(3), Display(Order = 4, Name = "Downloads")]
        Downloads = 3,

        /// <summary>
        /// Favourites
        /// </summary>
        [Id(4), Display(Order = 5, Name = "Favourites")]
        Favourites = 4,

        /// <summary>
        /// Links
        /// </summary>
        [Id(5), Display(Order = 6, Name = "Links")]
        Links = 5,

        /// <summary>
        /// Music
        /// </summary>
        [Id(6), Display(Order = 7, Name = "Music")]
        Music = 6,

        /// <summary>
        /// Pictures
        /// </summary>
        [Id(7), Display(Order = 8, Name = "Pictures")]
        Pictures = 7,

        /// <summary>
        /// Saved Games
        /// </summary>
        [Id(8), Display(Order = 9, Name = "Saved games")]
        SavedGames = 8,

        /// <summary>
        /// Saved Searches
        /// </summary>
        [Id(9), Display(Order = 10, Name = "Saved searches")]
        SavedSearches = 9,

        /// <summary>
        /// Videos
        /// </summary>
        [Id(10), Display(Order = 11, Name = "Videos")]
        Videos = 10,
    }
}
