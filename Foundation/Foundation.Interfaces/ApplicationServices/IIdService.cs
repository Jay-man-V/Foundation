//-----------------------------------------------------------------------
// <copyright file="IIdService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Id Service
    /// </summary>
    public interface IIdService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Guid NewGuid();
    }
}
