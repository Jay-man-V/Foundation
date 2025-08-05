//-----------------------------------------------------------------------
// <copyright file="IHeartbeatResult.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Heartbeat Result model interface
    /// </summary>
    public interface IHeartbeatResult
    {
        /// <summary>
        /// The Date/Time the request was serviced
        /// </summary>
        DateTime DateRun { get; }

        /// <summary>
        /// Version of the Api
        /// </summary>
        String Version { get; set; }

        /// <summary>
        /// Resulting status of the call
        /// </summary>
        Boolean Success { get; set; }

        /// <summary>
        /// The content of any Logs created on the Api that are to be sent back to the caller in the result
        /// </summary>
        List<String> Logs { get; }
    }
}
