//-----------------------------------------------------------------------
// <copyright file="IntervalType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Standard folders registered with the system. These folders are installed with Windows Vista
    /// and later operating systems, and a computer will have only folders appropriate to it
    /// installed.
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the known folder")]
    public enum KnownFolder
    {
        /// <summary>
        /// Contacts
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Contacts")]
        Contacts = 1,

        /// <summary>
        /// Desktop
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Desktop")]
        Desktop = 2,

        /// <summary>
        /// Documents
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Documents")]
        Documents = 3,

        /// <summary>
        /// Downloads
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Downloads")]
        Downloads = 4,

        /// <summary>
        /// Favourites
        /// </summary>
        [Id(5), Display(Order = 5, Name = "Favourites")]
        Favourites = 5,

        /// <summary>
        /// Links
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Links")]
        Links = 6,

        /// <summary>
        /// Music
        /// </summary>
        [Id(7), Display(Order = 7, Name = "Music")]
        Music = 7,

        /// <summary>
        /// Pictures
        /// </summary>
        [Id(8), Display(Order = 8, Name = "Pictures")]
        Pictures = 8,

        /// <summary>
        /// Saved Games
        /// </summary>
        [Id(9), Display(Order = 9, Name = "Saved games")]
        SavedGames = 9,

        /// <summary>
        /// Saved Searches
        /// </summary>
        [Id(10), Display(Order = 10, Name = "Saved searches")]
        SavedSearches = 10,

        /// <summary>
        /// Videos
        /// </summary>
        [Id(11), Display(Order = 11, Name = "Videos")]
        Videos = 11,
    }
}
