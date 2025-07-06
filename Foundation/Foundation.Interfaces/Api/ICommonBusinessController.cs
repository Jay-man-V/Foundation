//-----------------------------------------------------------------------
// <copyright file="ICommonBusinessController.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net.Http;

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommonBusinessController : ICommonController
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ICommonBusinessController<TModel>
        where TModel : IFoundationModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage GetAll();
    }
}
