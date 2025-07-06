//-----------------------------------------------------------------------
// <copyright file="ITestSupportService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the Test Support Service
    /// </summary>
    public interface ITestSupportService
    {
        /// <summary>
        /// Simulates a long-running task
        /// </summary>
        void SimulateLongTask();

        /// <summary>
        /// Returns the current Date/Time
        /// </summary>
        /// <returns></returns>
        DateTime GetCurrentDateTime();
    }
}
