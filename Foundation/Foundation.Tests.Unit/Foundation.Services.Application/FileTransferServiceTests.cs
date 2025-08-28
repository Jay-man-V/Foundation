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
        private IFileApi FileApi { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            IEmailApi emailApi = Substitute.For<IEmailApi>();
            FileApi = Substitute.For<IFileApi>();
            IHttpApi httpApi = Substitute.For<IHttpApi>();
            IFtpApi ftpApi = Substitute.For<IFtpApi>();
            IRestApi restApi = Substitute.For<IRestApi>();
            IMqApi mqApi = Substitute.For<IMqApi>();

            TheService = new FileTransferService(emailApi, FileApi, httpApi, ftpApi, restApi, mqApi);
        }

        [TestCase]
        public void Test_TransferFile_Exception()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
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

        [TestCase]
        public void Test_FileSystem_Move()
        {
            IFileTransferSettings sourceFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Guid.NewGuid().ToString(),
            };

            IFileTransferSettings destinationFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Guid.NewGuid().ToString(),
            };

            IArchiveTransferSettings archiveFileTransferSettings = new ArchiveTransferSettings
            {
                FileTransferArchiveAction = FileTransferArchiveAction.Move,
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Guid.NewGuid().ToString(),
            };

            Stream aStream = new MemoryStream(SourceValueBytes);
            FileApi.GetFileContentsAsStream(sourceFileTransferSettings.Location).Returns(aStream);

            Stream? destinationStream = null;
            FileApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));

            Stream? archiveStream = null;
            FileApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));

            TheService!.TransferFile(sourceFileTransferSettings, destinationFileTransferSettings, archiveFileTransferSettings);

            Assert.That(destinationStream, Is.Not.EqualTo(null));
            Byte[] destinationContent = ((MemoryStream)destinationStream).ToArray();
            Assert.That(destinationContent, Is.EqualTo(SourceValueBytes));

            Assert.That(archiveStream, Is.Not.EqualTo(null));
            Byte[] archiveContent = ((MemoryStream)archiveStream).ToArray();
            Assert.That(archiveContent, Is.EqualTo(SourceValueBytes));

            FileApi.Received().DeleteFile(sourceFileTransferSettings);
        }

        [TestCase]
        public void Test_FileSystem_Copy()
        {
            IFileTransferSettings sourceFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Guid.NewGuid().ToString(),
            };

            IFileTransferSettings destinationFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Guid.NewGuid().ToString(),
            };

            IArchiveTransferSettings archiveFileTransferSettings = new ArchiveTransferSettings
            {
                FileTransferArchiveAction = FileTransferArchiveAction.Move,
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Guid.NewGuid().ToString(),
            };

            Stream aStream = new MemoryStream(SourceValueBytes);
            FileApi.GetFileContentsAsStream(sourceFileTransferSettings.Location).Returns(aStream);

            Stream? destinationStream = null;
            FileApi.UploadFile(destinationFileTransferSettings, Arg.Do<Stream>(s => destinationStream = s));

            Stream? archiveStream = null;
            FileApi.UploadFile(archiveFileTransferSettings, Arg.Do<Stream>(s => archiveStream = s));

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
