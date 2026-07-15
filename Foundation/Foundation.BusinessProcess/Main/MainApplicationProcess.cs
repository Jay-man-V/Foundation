//-----------------------------------------------------------------------
// <copyright file="MainApplicationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess.Main
{
    /// <summary>
    /// The Main Application Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class MainApplicationProcess : IMainApplicationProcess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core"></param>
        public MainApplicationProcess
        (
            ICore core
        )
        {
            LoggingHelpers.TraceCallEnter(core);

            Core = core;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
    }
}
