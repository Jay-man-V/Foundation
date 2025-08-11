//-----------------------------------------------------------------------
// <copyright file="MailWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

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
        /// <param name="applicationConfigurationService"></param>
        public MailWrapper
        (
            ICore core,
            IApplicationConfigurationService applicationConfigurationService
        )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationService);

            Core = core;
            ApplicationConfigurationService = applicationConfigurationService;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// This private constructor is used to set up the Mailer class compatible with the <see cref="IDisposable"/> pattern and multiple use within components
        /// without the consumer needing to re-create the outer wrapper
        /// </summary>
        /// <param name="core"></param>
        /// <param name="applicationConfigurationService"></param>
        /// <param name="port"></param>
        /// <param name="host"></param>
        /// <param name="enableSsl"></param>
        /// <param name="networkCredential"></param>
        private MailWrapper
        (
            ICore core,
            IApplicationConfigurationService applicationConfigurationService,
            Int32 port,
            String host,
            Boolean enableSsl,
            NetworkCredential networkCredential
        )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationService, port, host, enableSsl, networkCredential);

            Core = core;
            ApplicationConfigurationService = applicationConfigurationService;

            Client = new NetMail.SmtpClient();

            Client.Port = port;
            Client.Host = host;
            Client.EnableSsl = enableSsl;
            Client.Credentials = networkCredential;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IApplicationConfigurationService ApplicationConfigurationService { get; }

        private NetMail.SmtpClient? Client { get; set; }

        /// <inheritdoc cref="IMailWrapper.SetupMailer()"/>
        public IMailWrapper SetupMailer()
        {
            LoggingHelpers.TraceCallEnter();
        
            String username = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostUsername);
            String password = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPassword);

            Int32 port = ApplicationConfigurationService.Get<Int32>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPort);
            String host = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostAddress);
            Boolean enableSsl = ApplicationConfigurationService.Get<Boolean>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostEnableSsl);
            NetworkCredential networkCredential  = new NetworkCredential(username, password);

            IMailWrapper retVal = new MailWrapper(Core, ApplicationConfigurationService, port, host, enableSsl, networkCredential);

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
                    if (mailAttachment.Content != null)
                    {
                        MemoryStream ms = new MemoryStream(mailAttachment.Content);
                        netMailMessage.Attachments.Add(new NetMail.Attachment(ms, mailAttachment.Filename));
                    }
                }

                Client?.Send(netMailMessage);
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

            foreach (IMailAttachment mailAttachment in mailMessage.Attachments)
            {
                if (mailAttachment.Content != null)
                {
                    MemoryStream ms = new MemoryStream(mailAttachment.Content);

                    NetMail.Attachment item = new NetMail.Attachment(ms, mailAttachment.Filename);
                    retVal.Attachments.Add(item);
                }
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
