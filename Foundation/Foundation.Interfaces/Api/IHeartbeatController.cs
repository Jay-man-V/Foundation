//-----------------------------------------------------------------------
// <copyright file="IHeartbeatController.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net.Http;

namespace Foundation.Interfaces.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHeartbeatController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage IsAlive();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage GetRunTimeEnvironmentSettings();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage GetLoggedOnUser();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage ExceptionDemo();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage BasicExceptionDemo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        HttpResponseMessage ReturnInput(Int32 id, String input);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage GetHeartbeat();
    }
}
