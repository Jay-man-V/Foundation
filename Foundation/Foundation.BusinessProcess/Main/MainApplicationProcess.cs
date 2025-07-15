//-----------------------------------------------------------------------
// <copyright file="MainApplicationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.Xml.Serialization;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Main Application Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class MainApplicationProcess : IMainApplicationProcess
    {
        /// <summary>
        /// The default application definition file
        /// </summary>
        public const String DefaultApplicationDefinitionFile = "ApplicationDefinition.xml";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="core"></param>
        public MainApplicationProcess
        (
            ICore core
        )
        {
            Core = core;
        }

        private ICore Core { get; }
    }
}
