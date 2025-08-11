//-----------------------------------------------------------------------
// <copyright file="EmailApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Text;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Services.Mail
{
    /// <summary>
    /// The Email Api class
    /// </summary>
    [DependencyInjectionTransient]
    public class EmailApi : IEmailApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core">The core foundation service.</param>
        /// <param name="applicationConfigurationService">The application configuration service.</param>
        /// <param name="mailWrapper">The mail wrapper service.</param>
        public EmailApi
        (
            ICore core,
            IApplicationConfigurationService applicationConfigurationService,
            IMailWrapper mailWrapper
        )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationService, mailWrapper);

            Core = core;
            ApplicationConfigurationService = applicationConfigurationService;
            MailWrapper = mailWrapper;

            LoggingHelpers.TraceCallReturn();
        }

        ICore Core { get; }
        IApplicationConfigurationService ApplicationConfigurationService { get; }
        IMailWrapper MailWrapper { get; }

        /// <inheritdoc cref="IEmailApi.SendTestMail(String)"/>
        public void SendTestMail(String toAddress)
        {
            LoggingHelpers.TraceCallEnter(toAddress);

            String mailFrom = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailFromAddress);
            String mailSubject = "Test email";
            String mailBody = "Test email";

            String textAttachmentBody = "Sample text file";
            Byte[] fileAttachment = Encoding.ASCII.GetBytes(textAttachmentBody);

            using (IMailWrapper client = MailWrapper.SetupMailer())
            {
                MailMessage mailMessage = new MailMessage
                {
                    FromAddress = mailFrom,
                    Subject = mailSubject,
                    Body = mailBody,
                };
                toAddress.Split(';').ToList().ForEach(s => mailMessage.ToAddress.Add(s));
                mailMessage.Attachments.Add(new MailAttachment
                {
                    Filename = "Sample file.txt",
                    Content = fileAttachment,
                });

                client.Send(mailMessage);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IEmailApi.SendSimpleEmail(String, String, String, String, String, List{IMailAttachment})"/>
        public void SendSimpleEmail(String toAddress, String fromAddress, String fromAddressDisplayName, String subject, String body, List<IMailAttachment>? mailAttachments = null)
        {
            LoggingHelpers.TraceCallEnter(toAddress, fromAddress, subject, body, mailAttachments);

            MailMessage mailMessage = new MailMessage
            {
                FromAddress = fromAddress,
                FromAddressDisplayName = fromAddressDisplayName,
                Subject = subject,
                Body = body,
            };
            mailMessage.ToAddress.AddRange(toAddress.Split(';'));

            if (mailAttachments != null &&
                mailAttachments.HasItems())
            {
                mailAttachments.ForEach(ma => mailMessage.Attachments.Add(ma));
            }

            SendMail(mailMessage);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IEmailApi.SendFormalEmail(String, String, String, String, String, List{IMailAttachment})"/>
        public void SendFormalEmail(String toAddress, String fromAddress, String fromAddressDisplayName, String subject, String body, List<IMailAttachment>? mailAttachments = null)
        {
            LoggingHelpers.TraceCallEnter(toAddress, fromAddress, subject, body, mailAttachments);

            String mailTemplateHtml = ResourceLoader.GetResourceFileAsText(ResourceNames.EMailTemplates.FormalEmailTemplate);
            String newBody = mailTemplateHtml;
            newBody = newBody.Replace("$$SUBJECT$$", subject);
            newBody = newBody.Replace("$$BODY$$", body);

            IMailMessage mailMessage = new MailMessage
            {
                FromAddress = fromAddress,
                FromAddressDisplayName = fromAddressDisplayName,
                Subject = subject,
                Body = newBody,
                IsBodyHtml = true,
            };
            mailMessage.ToAddress.AddRange(toAddress.Split(';'));

            if (mailAttachments != null &&
                mailAttachments.HasItems())
            {
                mailAttachments.ForEach(ma => mailMessage.Attachments.Add(ma));
            }

            SendMail(mailMessage);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IEmailApi.SendMail(IMailMessage)"/>
        public void SendMail(IMailMessage mailMessage)
        {
            LoggingHelpers.TraceCallEnter(mailMessage);

            using (IMailWrapper client = MailWrapper.SetupMailer())
            {
                client.Send(mailMessage);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IRemoteServiceApi.DeleteFile(IFileTransferSettings)"/>
        public void DeleteFile(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            Task t = DeleteFileAsync(fileTransferSettings);
            t.Wait();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IRemoteServiceApi.DeleteFileAsync(IFileTransferSettings)"/>
        public Task DeleteFileAsync(IFileTransferSettings fileTransferSettings)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IRemoteServiceApi.DownloadFile(IFileTransferSettings)"/>
        public Stream DownloadFile(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            Task<Stream> t = DownloadFileAsync(fileTransferSettings);
            t.Wait();
            Stream retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.DownloadFileAsync(IFileTransferSettings)"/>
        public async Task<Stream> DownloadFileAsync(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            Stream retVal = new MemoryStream(0);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFile(IFileTransferSettings, String)"/>
        public String UploadFile(IFileTransferSettings fileTransferSettings, String filePath)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, filePath);

            Task<String> t = UploadFileAsync(fileTransferSettings, filePath);
            t.Wait();
            String retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFile(IFileTransferSettings, Stream)"/>
        public String UploadFile(IFileTransferSettings fileTransferSettings, Stream fileContent)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, fileContent);

            Task<String> t = UploadFileAsync(fileTransferSettings, fileContent);
            t.Wait();
            String retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFileAsync(IFileTransferSettings, String)"/>
        public async Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, String filePath)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, filePath);

            String retVal;
            using (Stream stream = File.OpenRead(filePath))
            {
                Task<String> t = UploadFileAsync(fileTransferSettings, stream);
                await t;
                retVal = t.Result;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFileAsync(IFileTransferSettings, Stream)"/>
        public Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, Stream fileContent)
        {
            //https://medium.com/@niteshsinghal85/file-upload-to-web-api-with-different-http-clients-in-c-ae123555ef49
            throw new NotImplementedException();
        }
    }
}
