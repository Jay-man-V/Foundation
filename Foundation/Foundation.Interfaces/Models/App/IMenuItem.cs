//-----------------------------------------------------------------------
// <copyright file="IMenuItem.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Menu Item model interface
    /// </summary>
    public interface IMenuItem : IFoundationModel
    {
        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        /// <value>
        /// The application id
        /// </value>
        AppId ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the parent menu item id.
        /// </summary>
        /// <value>
        /// The parent menu item id
        /// </value>
        EntityId ParentMenuItemId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        String Name { get; set; }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption
        /// </value>
        String Caption { get; set; }

        /// <summary>
        /// Gets or sets the controller assembly.
        /// </summary>
        /// <value>
        /// The controller assembly
        /// </value>
        String ControllerAssembly { get; set; }

        /// <summary>
        /// Gets or sets the controller type.
        /// </summary>
        /// <value>
        /// The controller type
        /// </value>
        String ControllerType { get; set; }

        /// <summary>
        /// Gets or sets the view assembly.
        /// </summary>
        /// <value>
        /// The view assembly
        /// </value>
        String ViewAssembly { get; set; }

        /// <summary>
        /// Gets or sets the view type.
        /// </summary>
        /// <value>
        /// The view type
        /// </value>
        String ViewType { get; set; }

        /// <summary>
        /// Gets or sets the help text.
        /// </summary>
        /// <value>
        /// The help text
        /// </value>
        String HelpText { get; set; }

        /// <summary>
        /// Gets or sets the multi instance.
        /// </summary>
        /// <value>
        /// The multi instance
        /// </value>
        Boolean MultiInstance { get; set; }

        /// <summary>
        /// Gets or sets the show in tab.
        /// </summary>
        /// <value>
        /// The show in tab
        /// </value>
        Boolean ShowInTab { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon
        /// </value>
        Byte[]? Icon { get; set; }

        /// <summary>
        /// Gets the Depth
        /// </summary>
        Int32 Depth { get; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        Int32 DisplayOrder { get; set; }
    }
}
