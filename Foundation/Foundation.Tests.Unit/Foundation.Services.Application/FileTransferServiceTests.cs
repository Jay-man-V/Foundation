//-----------------------------------------------------------------------
// <copyright file="FileTransferServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Services.Application;
using Foundation.Tests.Unit.Support;

using NSubstitute;

using System.Text;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// UnitTests for FileTransferServiceTests
    /// </summary>
    [TestFixture]
    public class FileTransferServiceTests : UnitTestBase
    {
        private const String SourceValueString = "AbCdEfGhIjKlMnOpQrStUvWxYz1234567980!£$%^&*()_+";
        private Byte[] SourceValueBytes => Encoding.UTF8.GetBytes(SourceValueString);

        private IFileTransferService? TheService { get; set; }
        private IEmailApi EmailApi { get; set; }
        private IFileApi FileApi { get; set; }
        private IHttpApi HttpApi { get; set; }
        private IFtpApi FtpApi { get; set; }
        private IRestApi RestApi { get; set; }
        private IMqApi MqApi { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            EmailApi = Substitute.For<IEmailApi>();
            FileApi = Substitute.For<IFileApi>();
            HttpApi = Substitute.For<IHttpApi>();
            FtpApi = Substitute.For<IFtpApi>();
            RestApi = Substitute.For<IRestApi>();
            MqApi = Substitute.For<IMqApi>();

            TheService = new FileTransferService(EmailApi, FileApi, HttpApi, FtpApi, RestApi, MqApi);
        }

        [TestCase(FileTransferMethod.Email)]
        [TestCase(FileTransferMethod.FileSystem)]
        [TestCase(FileTransferMethod.Ftp)]
        [TestCase(FileTransferMethod.Http)]
        [TestCase(FileTransferMethod.Rest)]
        [TestCase(FileTransferMethod.Mq)]
        public void Test_TransferFile_Exception(FileTransferMethod fileTransferMethod)
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = fileTransferMethod,
                Location = Guid.NewGuid().ToString(),
            };

            String errorMessage = $"Unable to retrieve file from source '{fileTransferSettings}'";
            InvalidOperationException? actualException = null;

            Stream? aStream = null;
            FileApi.GetFileContentsAsStream(fileTransferSettings.Location).Returns(aStream);

            try
            {
                _ = TheService!.TransferFile(fileTransferSettings);
            }
            catch (InvalidOperationException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(errorMessage, Is.EqualTo(actualException.Message));
        }

        [TestCase]
        public void Test_FileSystem_GetStream()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Guid.NewGuid().ToString(),
            };

            Stream aStream = new MemoryStream(SourceValueBytes);

            FileApi.GetFileContentsAsStream(fileTransferSettings.Location).Returns(aStream);

            MemoryStream fileContentStream = (MemoryStream)TheService!.TransferFile(fileTransferSettings);

            Byte[] fileContent = fileContentStream.ToArray();

            Assert.That(fileContent, Is.EqualTo(SourceValueBytes));
        }

        [TestCase(FileTransferMethod.Email)]
        [TestCase(FileTransferMethod.FileSystem)]
        [TestCase(FileTransferMethod.Ftp)]
        [TestCase(FileTransferMethod.Http)]
        [TestCase(FileTransferMethod.Rest)]
        [TestCase(FileTransferMethod.Mq)]
        public void Test_FileSystem_Move(FileTransferMethod fileTransferMethod)
        {
            IFileTransferSettings sourceFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = fileTransferMethod,
                Location = Guid.NewGuid().ToString(),
            };

            IFileTransferSettings destinationFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = fileTransferMethod,
                Location = Guid.NewGuid().ToString(),
            };

            IArchiveTransferSettings archiveFileTransferSettings = new ArchiveTransferSettings
            {
                FileTransferArchiveAction = FileTransferArchiveAction.Move,
                FileTransferMethod = fileTransferMethod,
                Location = Guid.NewGuid().ToString(),
            };

            Stream aStream = new MemoryStream(SourceValueBytes);
            EmailApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            FileApi.GetFileContentsAsStream(sourceFileTransferSettings.Location).Returns(aStream);
            FtpApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            HttpApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            RestApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            MqApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);

            Stream? destinationStream = null;
            EmailApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            FileApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            FtpApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            HttpApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            RestApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            MqApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));

            Stream? archiveStream = null;
            EmailApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            FileApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            FtpApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            HttpApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            RestApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            MqApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));

            TheService!.TransferFile(sourceFileTransferSettings, destinationFileTransferSettings, archiveFileTransferSettings);

            Assert.That(destinationStream, Is.Not.EqualTo(null));
            Byte[] destinationContent = ((MemoryStream)destinationStream).ToArray();
            Assert.That(destinationContent, Is.EqualTo(SourceValueBytes));

            Assert.That(archiveStream, Is.Not.EqualTo(null));
            Byte[] archiveContent = ((MemoryStream)archiveStream).ToArray();
            Assert.That(archiveContent, Is.EqualTo(SourceValueBytes));

            switch (fileTransferMethod)
            {
                case FileTransferMethod.Email:
                {
                    EmailApi.Received().DeleteFile(sourceFileTransferSettings);
                    break;
                }
                case FileTransferMethod.FileSystem:
                {
                    FileApi.Received().DeleteFile(sourceFileTransferSettings);
                    break;
                }
                case FileTransferMethod.Ftp:
                {
                    FtpApi.Received().DeleteFile(sourceFileTransferSettings);
                    break;
                }
                case FileTransferMethod.Http:
                {
                    HttpApi.Received().DeleteFile(sourceFileTransferSettings);
                    break;
                }
                case FileTransferMethod.Rest:
                {
                    RestApi.Received().DeleteFile(sourceFileTransferSettings);
                    break;
                }
                case FileTransferMethod.Mq:
                {
                    MqApi.Received().DeleteFile(sourceFileTransferSettings);
                    break;
                }
            }
        }

        [TestCase(FileTransferMethod.Email)]
        [TestCase(FileTransferMethod.FileSystem)]
        [TestCase(FileTransferMethod.Ftp)]
        [TestCase(FileTransferMethod.Http)]
        [TestCase(FileTransferMethod.Rest)]
        [TestCase(FileTransferMethod.Mq)]
        public void Test_FileSystem_Copy(FileTransferMethod fileTransferMethod)
        {
            IFileTransferSettings sourceFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = fileTransferMethod,
                Location = Guid.NewGuid().ToString(),
            };

            IFileTransferSettings destinationFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = fileTransferMethod,
                Location = Guid.NewGuid().ToString(),
            };

            IArchiveTransferSettings archiveFileTransferSettings = new ArchiveTransferSettings
            {
                FileTransferArchiveAction = FileTransferArchiveAction.Move,
                FileTransferMethod = fileTransferMethod,
                Location = Guid.NewGuid().ToString(),
            };

            Stream aStream = new MemoryStream(SourceValueBytes);
            EmailApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            FileApi.GetFileContentsAsStream(sourceFileTransferSettings.Location).Returns(aStream);
            FtpApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            HttpApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            RestApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);
            MqApi.DownloadFile(sourceFileTransferSettings).Returns(aStream);

            Stream? destinationStream = null;
            EmailApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            FileApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            FtpApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            HttpApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            RestApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));
            MqApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));

            Stream? archiveStream = null;
            EmailApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            FileApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            FtpApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            HttpApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            RestApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));
            MqApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));

            TheService!.TransferFile(sourceFileTransferSettings, destinationFileTransferSettings, archiveFileTransferSettings);

            Assert.That(destinationStream, Is.Not.EqualTo(null));
            Byte[] destinationContent = ((MemoryStream)destinationStream).ToArray();
            Assert.That(destinationContent, Is.EqualTo(SourceValueBytes));

            Assert.That(archiveStream, Is.Not.EqualTo(null));
            Byte[] archiveContent = ((MemoryStream)archiveStream).ToArray();
            Assert.That(archiveContent, Is.EqualTo(SourceValueBytes));
        }
    }
}
