//-----------------------------------------------------------------------
// <copyright file="MailWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.Net;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

using NetMail = System.Net.Mail;

namespace Foundation.Services.Mail.Services
{
    [DependencyInjectionTransient]
    internal class MailWrapper : IMailWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core"></param>
        /// <param name="applicationConfigurationProcess"></param>
        public MailWrapper
        (
            ICore core,
            IApplicationConfigurationProcess applicationConfigurationProcess
        )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationProcess);

            Core = core;
            ApplicationConfigurationProcess = applicationConfigurationProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// This private constructor is used to set up the Mailer class compatible with the <see cref="IDisposable"/> pattern and multiple use within components
        /// without the consumer needing to re-create the outer wrapper
        /// </summary>
        /// <param name="core"></param>
        /// <param name="applicationConfigurationProcess"></param>
        /// <param name="port"></param>
        /// <param name="host"></param>
        /// <param name="enableSsl"></param>
        /// <param name="networkCredential"></param>
        private MailWrapper
        (
            ICore core,
            IApplicationConfigurationProcess applicationConfigurationProcess,
            Int32 port,
            String host,
            Boolean enableSsl,
            NetworkCredential networkCredential
        )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationProcess, port, host, enableSsl, networkCredential);

            Core = core;
            ApplicationConfigurationProcess = applicationConfigurationProcess;

            Client = new NetMail.SmtpClient();

            Client.Port = port;
            Client.Host = host;
            Client.EnableSsl = enableSsl;
            Client.Credentials = networkCredential;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IApplicationConfigurationProcess ApplicationConfigurationProcess { get; }

        private NetMail.SmtpClient? Client { get; set; }

        /// <inheritdoc cref="IMailWrapper.SetupMailer()"/>
        public IMailWrapper SetupMailer()
        {
            LoggingHelpers.TraceCallEnter();
        
            String username = ApplicationConfigurationProcess.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostUsername);
            String password = ApplicationConfigurationProcess.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPassword);

            Int32 port = ApplicationConfigurationProcess.Get<Int32>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPort);
            String host = ApplicationConfigurationProcess.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostAddress);
            Boolean enableSsl = ApplicationConfigurationProcess.Get<Boolean>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostEnableSsl);
            NetworkCredential networkCredential  = new NetworkCredential(username, password);

            IMailWrapper retVal = new MailWrapper(Core, ApplicationConfigurationProcess, port, host, enableSsl, networkCredential);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        public void Send(IMailMessage mailMessage)
        {
            LoggingHelpers.TraceCallEnter(mailMessage);

            using (NetMail.MailMessage netMailMessage = new NetMail.MailMessage())
            {
                netMailMessage.From = new NetMail.MailAddress(mailMessage.FromAddress, mailMessage.FromAddressDisplayName);
                netMailMessage.Subject = mailMessage.Subject;
                netMailMessage.Body = mailMessage.Body;
                netMailMessage.IsBodyHtml = mailMessage.IsBodyHtml;
                
                mailMessage.ToAddress.ForEach(ta => netMailMessage.To.Add(ta));

                foreach (IMailAttachment mailAttachment in mailMessage.Attachments)
                {
                    MemoryStream ms = new MemoryStream(mailAttachment.Content);
                    netMailMessage.Attachments.Add(new NetMail.Attachment(ms, mailAttachment.Filename));
                }

                Client.Send(netMailMessage);
            }


            LoggingHelpers.TraceCallReturn();
        }


        /// <summary>
        /// Creates the mail message.
        /// </summary>
        /// <param name="mailMessage">The mail message.</param>
        /// <returns>
        /// The Mail Message
        /// </returns>
        private NetMail.MailMessage CreateSmtpMailMessage(IMailMessage mailMessage)
        {
            LoggingHelpers.TraceCallEnter(mailMessage);

            NetMail.MailMessage retVal = new NetMail.MailMessage();
            NetMail.MailAddress from = new NetMail.MailAddress(mailMessage.FromAddress, mailMessage.FromAddressDisplayName);

            foreach (String toMailAddress in mailMessage.ToAddress)
            {
                NetMail.MailAddress to = new NetMail.MailAddress(toMailAddress);
                retVal.To.Add(to);
            }

            foreach (IMailAttachment attachment in mailMessage.Attachments)
            {
                MemoryStream ms = new MemoryStream(attachment.Content);

                NetMail.Attachment item = new NetMail.Attachment(ms, attachment.Filename);
                retVal.Attachments.Add(item);
            }

            retVal.From = from;

            retVal.IsBodyHtml = mailMessage.IsBodyHtml;
            retVal.Body = mailMessage.Body;
            retVal.Subject = mailMessage.Subject;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        public void Dispose()
        {
            if (Client != null)
            {
                Client.Dispose();
                Client = null;
            }
        }
    }
}
