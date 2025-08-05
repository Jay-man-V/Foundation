//-----------------------------------------------------------------------
// <copyright file="MainApplicationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

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
