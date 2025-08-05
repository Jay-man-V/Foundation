//-----------------------------------------------------------------------
// <copyright file="IMailWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMailWrapper : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IMailWrapper SetupMailer();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailMessage"></param>
        void Send(IMailMessage mailMessage);
    }
}
