//-----------------------------------------------------------------------
// <copyright file="IMenuitemProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Menu Items Business process 
    /// </summary>
    public interface IMenuItemProcess : ICommonBusinessProcess<IMenuItem>
    {
        /// <summary>
        /// Applies the given filter criteria (<paramref name="application"/> and <paramref name="parentMenuItem"/>) to the supplied
        /// <paramref name="menuItems"/> and returns the result
        /// </summary>
        /// <param name="menuItems">The full list of <see cref="IContract"/></param>
        /// <param name="application">The <see cref="IApplication"/> to filter by</param>
        /// <param name="parentMenuItem">The <see cref="IMenuItem"/> to filter by</param>
        /// <returns>Filtered <see cref="List{IMenuItem}"/></returns>
        List<IMenuItem> ApplyFilter(List<IMenuItem> menuItems, IApplication? application, IMenuItem? parentMenuItem);

        /// <summary>
        /// Given the <paramref name="menuItems"/> function will create a new list of <see cref="IMenuItem"/> that are Parents
        /// </summary>
        /// <param name="menuItems">The full list of menu items</param>
        /// <returns>List of <see cref="IMenuItem"/> that are Parents</returns>
        List<IMenuItem> MakeListOfParentMenuItems(List<IMenuItem> menuItems);
    }
}
