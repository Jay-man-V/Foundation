//-----------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Menu data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class MenuItem : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The Name
            /// </summary>
            public const Int32 Name = 250;

            /// <summary>
            /// The Caption
            /// </summary>
            public const Int32 Caption = 250;

            /// <summary>
            /// The Controller Assembly
            /// </summary>
            public const Int32 ControllerAssembly = 250;

            /// <summary>
            /// The Controller Type
            /// </summary>
            public const Int32 ControllerType = 250;

            /// <summary>
            /// The View Assembly
            /// </summary>
            public const Int32 ViewAssembly = 250;

            /// <summary>
            /// The View Type
            /// </summary>
            public const Int32 ViewType = 250;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(MenuItem);

        /// <summary>
        /// Gets the application id.
        /// </summary>
        /// <value>
        /// The application id.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the parent menu id.
        /// </summary>
        /// <value>
        /// The parent menu id.
        /// </value>
        public static String ParentMenuItemId => "ParentMenuItemId";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        public static String Caption => "Caption";

        /// <summary>
        /// Gets the controller assembly.
        /// </summary>
        /// <value>
        /// The controller assembly.
        /// </value>
        public static String ControllerAssembly => "ControllerAssembly";

        /// <summary>
        /// Gets the controller type.
        /// </summary>
        /// <value>
        /// The controller type.
        /// </value>
        public static String ControllerType => "ControllerType";

        /// <summary>
        /// Gets the view assembly.
        /// </summary>
        /// <value>
        /// The view assembly.
        /// </value>
        public static String ViewAssembly => "ViewAssembly";

        /// <summary>
        /// Gets the view type.
        /// </summary>
        /// <value>
        /// The view type.
        /// </value>
        public static String ViewType => "ViewType";

        /// <summary>
        /// Gets the help text.
        /// </summary>
        /// <value>
        /// The help text.
        /// </value>
        public static String HelpText => "HelpText";

        /// <summary>
        /// Gets the multi instance.
        /// </summary>
        /// <value>
        /// The multi instance.
        /// </value>
        public static String MultiInstance => "MultiInstance";

        /// <summary>
        /// Gets the show in yab.
        /// </summary>
        /// <value>
        /// The show in tab.
        /// </value>
        public static String ShowInTab => "ShowInTab";

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public static String Icon => "Icon";

        /// <summary>
        /// Gets the Depth.
        /// </summary>
        /// <value>
        /// The Depth.
        /// </value>
        public static String Depth => "Depth";
    }
}
