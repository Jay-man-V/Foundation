//-----------------------------------------------------------------------
// <copyright file="TestSupportService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
#if(DEBUG)
    /// <inheritdoc cref="ITestSupportService"/>
    [DependencyInjectionTransient]
    public class TestSupportService : ITestSupportService
    {
        /// <inheritdoc cref="ITestSupportService.SimulateLongTask"/>
        public void SimulateLongTask()
        {
            LoggingHelpers.TraceCallEnter();

            for (Byte i = 0; i < Byte.MaxValue; i++)
            {
                Thread.Sleep(5);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ITestSupportService.GetCurrentDateTime"/>
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
#endif
}
