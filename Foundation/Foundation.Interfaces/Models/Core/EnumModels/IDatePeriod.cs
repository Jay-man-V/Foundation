//-----------------------------------------------------------------------
// <copyright file="IDatePeriod.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Date Period model interface
    /// </summary>
    public interface IDatePeriod : IEnumModel
    {
        /// <summary>Gets the Period.</summary>
        /// <value>The period.</value>
        DatePeriod Period { get; }
    }
}
