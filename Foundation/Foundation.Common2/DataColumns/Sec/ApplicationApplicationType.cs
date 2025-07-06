//-----------------------------------------------------------------------
// <copyright file="ApplicationApplicationType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Application/Application Type data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ApplicationApplicationType : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            //public const Int32 Name = 25;
            //public const Int32 Description = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "ApplicationApplicationType";

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the application type identifier.
        /// </summary>
        /// <value>
        /// The application type identifier.
        /// </value>
        public static String ApplicationTypeId => "ApplicationTypeId";
    }
}
