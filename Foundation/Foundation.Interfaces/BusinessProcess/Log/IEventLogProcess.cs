//-----------------------------------------------------------------------
// <copyright file="IEventLogProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Event Log process
    /// </summary>
    public interface IEventLogProcess : ICommonBusinessProcess<IEventLog>
    {
        /// <summary>
        /// Loads the event log from the data store
        /// </summary>
        /// <param name="logId">The Id of the event log to be loaded</param>
        IEventLog? Get(LogId logId);
    }
}
