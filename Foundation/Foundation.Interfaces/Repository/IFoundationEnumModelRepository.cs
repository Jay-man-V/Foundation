//-----------------------------------------------------------------------
// <copyright file="IFoundationEnumModelRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Foundation Enum Model Data Access interface
    /// </summary>
    public interface IFoundationEnumModelRepository<TEnumModel> : IFoundationModelDataAccess<TEnumModel>
        where TEnumModel : IEnumModel
    {
    }
}
