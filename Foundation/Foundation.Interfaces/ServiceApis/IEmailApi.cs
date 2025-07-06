//-----------------------------------------------------------------------
// <copyright file="IEmailApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Email Api
    /// </summary>
    public interface IEmailApi : IRemoteServiceApi
    {
        /// <summary>
        /// Sends a simple test email to the <paramref name="toAddress"/>
        /// <para>
        /// Used to test that the email infrastructure and settings are working as expected
        /// </para>
        /// </summary>
        /// <param name="toAddress"></param>
        void SendTestMail(String toAddress);

        /// <summary>
        /// Sends a simple email based on the supplied parameters
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="fromAddress"></param>
        /// <param name="fromAddressDisplayName"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="mailAttachments"></param>
        void SendSimpleEmail(String toAddress, String fromAddress, String fromAddressDisplayName, String subject, String body, List<IMailAttachment>? mailAttachments = null);

        /// <summary>
        /// Sends a formal email based on the supplied parameters
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="fromAddress"></param>
        /// <param name="fromAddressDisplayName"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="mailAttachments"></param>
        void SendFormalEmail(String toAddress, String fromAddress, String fromAddressDisplayName, String subject, String body, List<IMailAttachment>? mailAttachments = null);

        /// <summary>
        /// Sends the mail based on <paramref name="mailMessage"/>
        /// </summary>
        void SendMail(IMailMessage mailMessage);
    }
}
