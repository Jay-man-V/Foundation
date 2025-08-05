//-----------------------------------------------------------------------
// <copyright file="ScheduledJobProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateScheduledTaskEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullyQualifiedTypeName"></param>
        public CreateScheduledTaskEventArgs(FullyQualifiedTypeName fullyQualifiedTypeName)
        {
            FullyQualifiedTypeName = fullyQualifiedTypeName;
        }

        /// <summary>
        /// 
        /// </summary>
        public FullyQualifiedTypeName FullyQualifiedTypeName { get; }

        /// <summary>
        /// 
        /// </summary>
        public IScheduledTask? ServiceInstance { get; set; }
    }
}
