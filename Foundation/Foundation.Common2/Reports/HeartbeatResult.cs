//-----------------------------------------------------------------------
// <copyright file="HeartbeatResult.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the heartbeat result
    /// </summary>
    /// <seealso cref="IHeartbeatResult"/>
    [DependencyInjectionTransient]
    public class HeartbeatResult : IHeartbeatResult
    {
        /// <summary>
        /// 
        /// </summary>
        public HeartbeatResult
        (
            IDateTimeService dateTimeService
        )
        {
            DateRun = dateTimeService.SystemDateTimeNow;
            DateRun = new DateTime(DateRun.Year, DateRun.Month, DateRun.Day, DateRun.Hour, DateRun.Minute, DateRun.Second, DateRun.Millisecond, DateTimeKind.Unspecified);

            Logs = new List<String>();
        }

        /// <inheritdoc cref="IHeartbeatResult.DateRun"/>
        public DateTime DateRun { get; set; }

        /// <inheritdoc cref="IHeartbeatResult.Version"/>
        public String Version { get; set; } = String.Empty;

        /// <inheritdoc cref="IHeartbeatResult.Success"/>
        public Boolean Success { get; set; }

        /// <inheritdoc cref="IHeartbeatResult.Logs"/>
        public List<String> Logs { get; }

        /// <inheritdoc cref="Object.ToString()"/>
        public override String ToString()
        {
            String retVal = $"{DateRun:yyyy-MM-ddTHH:mm:ss.fff}. {Version}. {Success}. {String.Join(", ", Logs)}";

            return retVal;
        }
    }
}
