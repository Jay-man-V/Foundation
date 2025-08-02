//-----------------------------------------------------------------------
// <copyright file="IViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the View Model
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged
    {
        //String Caption { get; }
        //Object Icon { get; }

        /// <summary>
        /// The form title
        /// </summary>
        String FormTitle { get; }

        /// <summary>
        /// The Parent View Model
        /// </summary>
        IViewModel? ParentViewModel { get; }

        /// <summary>
        /// Generic property to hold parameters for the View Model
        /// </summary>
        Dictionary<String, Object> Parameters { get; }

        /// <summary>
        /// Initialises the View Model
        /// </summary>
//        void Initialise();
        void Initialise(IWindow targetWindow, IViewModel? parentViewModel, String formTitle);
    }
}