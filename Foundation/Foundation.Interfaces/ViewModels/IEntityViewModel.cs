//-----------------------------------------------------------------------
// <copyright file="IEntityViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Model ViewModel
    /// </summary>
    public interface IEntityViewModel : IViewModel
    {
        /// <summary>
        /// Tracks if the View Model has any user made changes to the data
        /// </summary>
        Boolean HasChanges { get; }

        /// <summary>
        /// Calls the appropriate Save routine for the data
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Asks the user if they wish to save changes before exiting
        /// </summary>
        /// <returns></returns>
        DialogResult PromptSaveBeforeExit();

        /// <summary>
        /// Initialises the Entity ViewModel
        /// </summary>
        /// <param name="targetWindow">The target window.</param>
        /// <param name="parentViewModel">The parent view model.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="formTitle">The form title.</param>
        void Initialise(IWindow targetWindow, IViewModel parentViewModel, IFoundationModel entity, String formTitle);
    }
}