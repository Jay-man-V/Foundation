//-----------------------------------------------------------------------
// <copyright file="EmailApiTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Services.Mail;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Mail
{
    /// <summary>
    /// Summary description for EmailApiTests
    /// </summary>
    [TestFixture]
    [DeploymentItem(@".Support\SampleDocuments\Sample Image.jpg", @".Support\SampleDocuments\")]
    [DeploymentItem(@".Support\SampleDocuments\Sample Excel Document.xlsx", @".Support\SampleDocuments\")]
    [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
    [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
    [DeploymentItem(@".Support\SampleDocuments\Sample Word Document.docx", @".Support\SampleDocuments\")]
    public class EmailApiTests : BusinessProcessUnitTestsBase
    {
        private IEmailApi? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ICore core = Substitute.For<ICore>();
            IApplicationConfigurationService applicationConfigurationService = Substitute.For<IApplicationConfigurationService>();
            IMailWrapper mailWrapper = Substitute.For<IMailWrapper>();
            TheService = new EmailApi(core, applicationConfigurationService, mailWrapper);

            String smtpMailPath = Path.Combine(BaseTemporaryOutputsPath, "SmtpMail");
            DirectoryInfo smtpMailPathDirectoryInfo = new DirectoryInfo(smtpMailPath);
            if (!smtpMailPathDirectoryInfo.Exists)
            {
                smtpMailPathDirectoryInfo.Create();
            }

            List<FileInfo> allFiles = smtpMailPathDirectoryInfo.GetFiles().ToList();
            allFiles.ForEach(f => f.Delete());
        }

        private MailMessage CreateMailMessageForTests(String functionName)
        {
            MailMessage mailMessage = new MailMessage 
            {
                FromAddress = EmailFromAddress,
                FromAddressDisplayName = EmailFromDisplayName,
                Subject = EmailSubject + " " + functionName,
                Body = EmailBody,
            };
            mailMessage.ToAddress.Add(EmailToAddress);

            return mailMessage;
        }

        private List<IMailAttachment> CreateMailMessageAttachments()
        {
            List<IMailAttachment> retVal = [];

            String[] filesToAttach =
            [
                @".Support\SampleDocuments\Sample Image.jpg",
                @".Support\SampleDocuments\Sample Excel Document.xlsx",
                @".Support\SampleDocuments\Sample PDF Document.pdf",
                @".Support\SampleDocuments\Sample Text Document.txt",
                @".Support\SampleDocuments\Sample Word Document.docx",
            ];


            // TODO: replace with IFileApi mock
            IFileApi fileApi = Substitute.For<IFileApi>();

            foreach (String fileToAttach in filesToAttach)
            {
                FileInfo fileInfo = new FileInfo(fileToAttach);

                IMailAttachment mailAttachment = new MailAttachment();

                mailAttachment.Filename = fileInfo.Name;
                mailAttachment.Content = fileApi.GetFileContentsAsByteArray(fileToAttach);

                retVal.Add(mailAttachment);
            }

            return retVal;
        }

        [TestCase]
        public void Test_SendTestMail()
        {
            TheService!.SendTestMail(EmailToAddress);
        }

        [TestCase]
        public void Test_SendMail_NoAttachment()
        {
            String functionName = LocationUtils.GetFunctionName();

            MailMessage mailMessage = CreateMailMessageForTests(functionName);

            TheService!.SendMail(mailMessage);
        }

        [TestCase]
        public void Test_SendMail_WithAttachment()
        {
            String functionName = LocationUtils.GetFunctionName();

            MailMessage mailMessage = CreateMailMessageForTests(functionName);
            List<IMailAttachment> mailAttachments = CreateMailMessageAttachments();
            mailMessage.Attachments.AddRange(mailAttachments);

            TheService!.SendMail(mailMessage);
        }

        [TestCase]
        public void Test_SendFormalEmail_NoAttachment()
        {
            String functionName = LocationUtils.GetFunctionName();

            TheService!.SendFormalEmail(EmailToAddress, EmailFromAddress, EmailFromDisplayName, EmailSubject + " " + functionName, EmailBody);
        }

        [TestCase]
        public void Test_SendFormalEmail_WithAttachment()
        {
            String functionName = LocationUtils.GetFunctionName();

            List<IMailAttachment> mailAttachments = CreateMailMessageAttachments();

            TheService!.SendFormalEmail(EmailToAddress, EmailFromAddress, EmailFromDisplayName, EmailSubject + " " + functionName, EmailBody,
                mailAttachments);
        }

        [TestCase]
        public void Test_SendSimpleEmail_NoAttachment()
        {
            String functionName = LocationUtils.GetFunctionName();

            TheService!.SendSimpleEmail(EmailToAddress, EmailFromAddress, EmailFromDisplayName, EmailSubject + " " + functionName, EmailBody);
        }

        [TestCase]
        public void Test_SendSimpleEmail_WithAttachment()
        {
            String functionName = LocationUtils.GetFunctionName();

            List<IMailAttachment> mailAttachments = CreateMailMessageAttachments();

            TheService!.SendSimpleEmail(EmailToAddress, EmailFromAddress, EmailFromDisplayName, EmailSubject + " " + functionName, EmailBody,
                mailAttachments);
        }

        [TestCase]
        public void Test_DeleteFile()
        {
            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                IFileTransferSettings fileTransferSettings = new FileTransferSettings
                {
                    FileTransferMethod = FileTransferMethod.Email,
                };

                TheService!.DeleteFile(fileTransferSettings);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_DeleteFile_Async()
        {
            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                IFileTransferSettings fileTransferSettings = new FileTransferSettings
                {
                    FileTransferMethod = FileTransferMethod.Email,
                };

                TheService!.DeleteFileAsync(fileTransferSettings);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_DownloadFile()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.Email,
            };

            MemoryStream? memoryStream = (MemoryStream?)TheService!.DownloadFile(fileTransferSettings);

            Assert.That(memoryStream, Is.Not.EqualTo(null));
            Assert.That(memoryStream.Length, Is.EqualTo(0));
        }

        [TestCase]
        public void Test_DownloadFile_Async()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.Email,
            };

            Task<Stream?> t = TheService!.DownloadFileAsync(fileTransferSettings);
            t.Wait();
            MemoryStream? memoryStream = (MemoryStream?)t.Result;

            Assert.That(memoryStream, Is.Not.EqualTo(null));
            Assert.That(memoryStream.Length, Is.EqualTo(0));
        }

        [TestCase]
        public void Test_UploadFile_Path()
        {
            AggregateException actualException = Assert.Throws<AggregateException>(() =>
            {
                IFileTransferSettings fileTransferSettings = new FileTransferSettings
                {
                    FileTransferMethod = FileTransferMethod.Email,
                };
                String filePath = @".Support\SampleDocuments\Sample Image.jpg";

                TheService!.UploadFile(fileTransferSettings, filePath);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.InnerExceptions.Count, Is.EqualTo(1));

            NotImplementedException? expectedException = actualException.InnerExceptions[0] as NotImplementedException;
            Assert.That(expectedException, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_UploadFile_Path_Async()
        {
            AggregateException actualException = Assert.Throws<AggregateException>(() =>
            {
                IFileTransferSettings fileTransferSettings = new FileTransferSettings
                {
                    FileTransferMethod = FileTransferMethod.Email,
                };
                String filePath = @".Support\SampleDocuments\Sample Image.jpg";

                Task t = TheService!.UploadFileAsync(fileTransferSettings, filePath);
                if (t.Exception != null)
                {
                    throw t.Exception;
                }
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.InnerExceptions.Count, Is.EqualTo(1));

            NotImplementedException? expectedException = actualException.InnerExceptions[0] as NotImplementedException;
            Assert.That(expectedException, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_UploadFile_Stream()
        {
            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                IFileTransferSettings fileTransferSettings = new FileTransferSettings
                {
                    FileTransferMethod = FileTransferMethod.Email,
                };

                String filePath = @".Support\SampleDocuments\Sample Image.jpg";

                Stream stream = new MemoryStream();
                using (Stream s = File.OpenRead(filePath))
                {
                    s.CopyTo(stream);
                }

                TheService!.UploadFile(fileTransferSettings, stream);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_UploadFile_Stream_Async()
        {
            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                IFileTransferSettings fileTransferSettings = new FileTransferSettings
                {
                    FileTransferMethod = FileTransferMethod.Email,
                };

                String filePath = @".Support\SampleDocuments\Sample Image.jpg";

                Stream stream = new MemoryStream();
                using (Stream s = File.OpenRead(filePath))
                {
                    s.CopyTo(stream);
                }

                TheService!.UploadFile(fileTransferSettings, stream);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
        }
    }
}
