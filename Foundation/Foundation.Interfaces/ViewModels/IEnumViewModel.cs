//-----------------------------------------------------------------------
// <copyright file="IEnumViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Generic DataGrid View Model
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IEnumViewModel<TModel> : IGenericDataGridViewModel<TModel>
        where TModel : IFoundationModel
    {
    }
}