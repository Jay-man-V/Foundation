//-----------------------------------------------------------------------
// <copyright file="FileServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Resources;
using System.Text;

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Services.Application;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// UnitTests for FileServiceTests
    /// </summary>
    [TestFixture]
    public class FileServiceTests : UnitTestBase
    {
        private IFileApi? TheService { get; set; }
        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = new FileService(CoreInstance, ApplicationConfigurationService);
        }

        public override void TestCleanup()
        {
            TheService = null;

            base.TestCleanup();
        }

        /// <summary>
        /// baseFolder and targetFolder do not have a trailing slash
        /// </summary>
        [TestCase]
        public void Test_MakeDataPath_Folder_1()
        {
            String baseFolder = "baseFolder";
            String targetFolder = "targetFolder";
            String expected = @"baseFolder\targetFolder\";
            String actual = TheService!.MakeDataPath(baseFolder, targetFolder);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// baseFolder and targetFolder do have a trailing slash
        /// </summary>
        [TestCase]
        public void Test_MakeDataPath_Folder_2()
        {
            String baseFolder = @"baseFolder\";
            String targetFolder = @"targetFolder\";
            String expected = @"baseFolder\targetFolder\";
            String actual = TheService!.MakeDataPath(baseFolder, targetFolder);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_MakeDataPath_File()
        {
            String baseFolder = "baseFolder";
            String targetFolder = "targetFolder";
            String targetFileName = "NewFile.txt";
            String expected = @"baseFolder\targetFolder\NewFile.txt";
            String actual = TheService!.MakeDataPath(baseFolder, targetFolder, targetFileName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_UserDataPath()
        {
            String userDataPath = @".\UserData\";

            ApplicationConfigurationService.Get<String>(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), ApplicationConfigurationKeys.UserDataPath).Returns(userDataPath);

            String expected = @".\UserData\";
            String actual = TheService!.UserDataPath;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_SystemDataPath()
        {
            String systemDataPath = @"\SystemData\";

            ApplicationConfigurationService.Get<String>(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), ApplicationConfigurationKeys.SystemDataPath).Returns(systemDataPath);

            String expected = @"\SystemData\";
            String actual = TheService!.SystemDataPath;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_GetNewTempFilePath()
        {
            String systemTempFolderPath = Path.GetTempPath();
            String baseFolder = ".ExpectedResults";
            String filePrefix = "UnitTest";
            String actual = TheService!.GetNewTempFilePath(baseFolder, filePrefix);

            Assert.That(String.IsNullOrEmpty(actual), Is.EqualTo(false));
            Assert.That(String.IsNullOrWhiteSpace(actual), Is.EqualTo(false));

            FileInfo fi = new (actual);

            String tempFolderPath = fi.DirectoryName ?? String.Empty;
            String tempFileName = fi.Name;

            Assert.That(Path.Combine(systemTempFolderPath, baseFolder), Is.EqualTo(tempFolderPath));
            Assert.That(tempFileName.StartsWith(filePrefix));
        }

        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_EnsureFileExists_True()
        {
            String filePath = @".Support\SampleDocuments\Blank_10x10.bmp";

            TheService!.EnsureFileExists(filePath);
        }

        [TestCase]
        public void Test_EnsureFileExists_False()
        {
            String filePath = "MadeUp.File.Name";
            String errorMessage = $"The file '{filePath}' does not exist or access to it is denied";
            FileNotFoundException? actualException = null;

            try
            {
                TheService!.EnsureFileExists(filePath);
            }
            catch (FileNotFoundException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;
            String actualErrorFileName = actualException.FileName ?? String.Empty;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
            Assert.That(actualErrorFileName, Is.EqualTo(filePath));
        }

        [TestCase]
        public void Test_EnsureFileDoesNotExist_True()
        {
            String filePath = $@".Support\SampleDocuments\{Guid.NewGuid()}";

            TheService!.EnsureFileDoesNotExist(filePath);
        }

        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_EnsureFileDoesNotExist_False()
        {
            String filePath = @".Support\SampleDocuments\Blank_10x10.bmp";
            String errorMessage = $"The file '{filePath}' already exists";
            FileAlreadyExistsException? actualException = null;

            try
            {
                TheService!.EnsureFileDoesNotExist(filePath);
            }
            catch (FileAlreadyExistsException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;
            String actualErrorFileName = actualException.FilePath;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
            Assert.That(actualErrorFileName, Is.EqualTo(filePath));
        }

        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_EnsureDirectoryExists_True()
        {
            String filePath = @".Support\SampleDocuments";

            TheService!.EnsureDirectoryExists(filePath);
        }

        [TestCase]
        public void Test_EnsureDirectoryExists_False()
        {
            String directoryPath = "MadeUp.File.Name";
            String errorMessage = $"The directory '{directoryPath}' does not exist or access to it is denied";
            DirectoryNotFoundException? actualException = null;

            try
            {
                TheService!.EnsureDirectoryExists(directoryPath);
            }
            catch (DirectoryNotFoundException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_EnsureDirectoryDoesNotExist_True()
        {
            String filePath = $@".Support\SampleDocuments\{Guid.NewGuid()}";

            TheService!.EnsureDirectoryDoesNotExist(filePath);
        }

        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_EnsureDirectoryDoesNotExist_False()
        {
            String directoryPath = @".Support\SampleDocuments\";
            String errorMessage = $"The directory '{directoryPath}' already exists";
            DirectoryAlreadyExistsException? actualException = null;

            try
            {
                TheService!.EnsureDirectoryDoesNotExist(directoryPath);
            }
            catch (DirectoryAlreadyExistsException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;
            String actualDirectoryPath = actualException.DirectoryPath;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
            Assert.That(actualDirectoryPath, Is.EqualTo(directoryPath));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_DoesFileExist_True()
        {
            String filePath = @".Support\SampleDocuments\Blank_10x10.bmp";
            const Boolean expected = true;
            Boolean actual = TheService!.DoesFileExist(filePath);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DoesFileExist_False()
        {
            String filePath = $"Fake filename - {Guid.NewGuid()}" + Guid.NewGuid();
            const Boolean expected = false;
            Boolean actual = TheService!.DoesFileExist(filePath);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_DoesFileExist_SameAsDirectoryName()
        {
            String filePath = @".Support\SampleDocuments";
            const Boolean expected = true;
            Boolean actual = TheService!.DoesFileExist(filePath);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_DoesDirectoryExist_True()
        {
            String filePath = @".Support\SampleDocuments\";
            const Boolean expected = true;
            Boolean actual = TheService!.DoesDirectoryExist(filePath);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Blank_10x10.bmp", @".Support\SampleDocuments\")]
        public void Test_DoesDirectoryExist_SameAsFileName()
        {
            String filePath = @".Support\SampleDocuments\Blank_10x10.bmp";
            const Boolean expected = true;
            Boolean actual = TheService!.DoesDirectoryExist(filePath);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DoesDirectoryExist_False()
        {
            String filePath = @".Support\MadeUp folder\";
            const Boolean expected = false;
            Boolean actual = TheService!.DoesDirectoryExist(filePath);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_GetFileContentsAsStream_Fail()
        {
            String filePath = @"C:\FakeFile.txt";

            String message = $"The file '{filePath}' does not exist or access to it is denied";

            FileNotFoundException? actualException = null;

            try
            {
                TheService!.GetFileContentsAsStream(filePath);
            }
            catch (FileNotFoundException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            Assert.That(actualException.Message, Is.EqualTo(message));
            Assert.That(actualException.FileName, Is.EqualTo(filePath));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\FileManagement\SmallFile.txt", @".ExpectedResults\FileManagement\")]
        public void Test_GetFileContentsAsStream_Success()
        {
            String filePath = @".ExpectedResults\FileManagement\SmallFile.txt";
            Stream fileContent = File.OpenRead(filePath);

            Stream actualFileContent = TheService!.GetFileContentsAsStream(filePath);

            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase]
        public void Test_GetFileContentsAsText_Fail()
        {
            String filePath = @"C:\FakeFile.txt";
            Encoding encoding = Encoding.UTF8;

            String message = $"The file '{filePath}' does not exist or access to it is denied";

            FileNotFoundException? actualException = null;

            try
            {
                TheService!.GetFileContentsAsText(filePath, encoding);
            }
            catch (FileNotFoundException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            Assert.That(actualException.Message, Is.EqualTo(message));
            Assert.That(actualException.FileName, Is.EqualTo(filePath));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\FileManagement\SmallFile.txt", @".ExpectedResults\FileManagement\")]
        public void Test_GetFileContentsAsText_Success()
        {
            String filePath = @".ExpectedResults\FileManagement\SmallFile.txt";
            Encoding encoding = Encoding.UTF8;
            String fileContent = "Just a small text file";

            String actualFileContent = TheService!.GetFileContentsAsText(filePath, encoding);

            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase]
        public void Test_GetFileContentsAsByteArray_Fail_NoFile()
        {
            String filePath = @"C:\FakeFile.txt";

            String message = $"The file '{filePath}' does not exist or access to it is denied";

            FileNotFoundException? actualException = null;

            try
            {
                TheService!.GetFileContentsAsByteArray(filePath);
            }
            catch (FileNotFoundException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            Assert.That(actualException.Message, Is.EqualTo(message));
            Assert.That(actualException.FileName, Is.EqualTo(filePath));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\FileManagement\SmallFile.txt", @".ExpectedResults\FileManagement\")]
        public void Test_GetFileContentsAsByteArray_Success()
        {
            String filePath = @".ExpectedResults\FileManagement\SmallFile.txt";
            Byte[] fileContent = File.ReadAllBytes(filePath);

            Byte[] actualFileContent = TheService!.GetFileContentsAsByteArray(filePath);

            Assert.That(actualFileContent, Is.EquivalentTo(fileContent));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_GetAssemblyResource_Fail()
        {
            String filePath = "FakeFile.txt";

            String message = $"Resource File '{filePath}' does not exist in the Assembly 'Foundation.Tests.Unit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'";

            MissingManifestResourceException? actualException = null;

            try
            {
                Assembly thisAssembly = Assembly.GetExecutingAssembly();

                TheService!.GetAssemblyResource(thisAssembly, filePath);
            }
            catch (MissingManifestResourceException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            Assert.That(actualException.Message, Is.EqualTo(message));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_GetAssemblyResource_Success()
        {
            String filePath = "Foundation.Tests.Unit..Support.SampleDocuments.Embedded_Documents.Embedded Sample Text Document.txt";
            String fileContent = "A sample text document";

            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            String actualFileContent;
            using (Stream resourceStream = TheService!.GetAssemblyResource(thisAssembly, filePath))
            {
                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    actualFileContent = reader.ReadToEnd();
                }
            }

            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase]
        public void Test_GetFileContentsAsTextFromAssembly()
        {
            String filePath = "Foundation.Tests.Unit..Support.SampleDocuments.Embedded_Documents.Embedded Sample Text Document.txt";
            Encoding encoding = Encoding.UTF8;
            String fileContent = "A sample text document";

            Assembly resourceAssembly = Assembly.GetAssembly(this.GetType())!;
            String actualFileContent = TheService!.GetFileContentsAsTextFromAssembly(resourceAssembly, filePath, encoding);

            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Sample Word Document.docx", @".Support\SampleDocuments\")]
        public void Test_GetFileContentsAsByteArrayFromAssembly()
        {
            String filePath = "Foundation.Tests.Unit..Support.SampleDocuments.Embedded_Documents.Embedded Sample Word Document.docx";
            Byte[] fileContent = File.ReadAllBytes(@".Support\\SampleDocuments\\Sample Word Document.docx");

            Assembly resourceAssembly = Assembly.GetAssembly(this.GetType())!;
            Byte[] actualFileContent = TheService!.GetFileContentsAsByteArrayFromAssembly(resourceAssembly, filePath);

            Assert.That(actualFileContent, Is.EquivalentTo(fileContent));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        public void Test_OpenFileForReading_FileExists()
        {
            String filePath = @".Support\SampleDocuments\Sample Text Document.txt";
            Encoding encoding = Encoding.UTF8;
            String expected = "A sample text document";
            String actual;
            using (TextReader reader = TheService!.OpenFileForReading(filePath, encoding))
            {
                actual = reader.ReadToEnd();
            }

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_OpenFileForReading_FileNotExists()
        {
            String filePath = @".Support\SampleDocuments\Random file that does not exist " + Guid.NewGuid();
            Encoding encoding = Encoding.UTF8;
            String errorMessage = $"The file '{filePath}' does not exist or access to it is denied";
            FileNotFoundException? actualException = null;

            try
            {
                TheService!.OpenFileForReading(filePath, encoding);
            }
            catch (FileNotFoundException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;
            String actualErrorFileName = actualException.FileName ?? String.Empty;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
            Assert.That(actualErrorFileName, Is.EqualTo(filePath));
        }

        [TestCase]
        public void Test_OpenFileForWriting_Fail_FileDoesNotExist()
        {
            String filePath = Guid.NewGuid().ToString();
            Encoding encoding = Encoding.UTF8;
            String errorMessage = $"The file '{filePath}' does not exist or access to it is denied";

            FileNotFoundException? actualException = null;

            try
            {
                const Boolean appendToFile = true;
                TheService!.OpenFileForWriting(filePath, encoding, appendToFile);
            }
            catch (FileNotFoundException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;
            String actualErrorFileName = actualException.FileName ?? String.Empty;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
            Assert.That(actualErrorFileName, Is.EqualTo(filePath));
        }

        [TestCase]
        public void Test_OpenFileForWriting_Fail_FileAlreadyExists()
        {
            String filePath = Guid.NewGuid().ToString();
            Encoding encoding = Encoding.UTF8;
            String errorMessage = $"The file '{filePath}' already exists and cannot be created";

            UnauthorizedAccessException? actualException = null;

            try
            {
                TheService!.OpenFileForWriting(filePath, encoding);

                TheService!.OpenFileForWriting(filePath, encoding);
            }
            catch (UnauthorizedAccessException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_OpenFileForWriting_Create_Success()
        {
            String filePath = Guid.NewGuid().ToString();
            Encoding encoding = Encoding.UTF8;
            String fileContent = Guid.NewGuid().ToString();

            using (TextWriter writer = TheService!.OpenFileForWriting(filePath, encoding))
            {
                writer.Write(fileContent);
            }

            String actualFileContent;
            TheService!.EnsureFileExists(filePath);
            using (TextReader reader = TheService!.OpenFileForReading(filePath, encoding))
            {
                actualFileContent = reader.ReadToEnd();
            }

            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase]
        public void Test_OpenFileForWriting_Append_Success()
        {
            String filePath = Guid.NewGuid().ToString();
            Encoding encoding = Encoding.UTF8;
            String fileContent = Guid.NewGuid().ToString();

            // Create the file first, before appending to it
            using (TextWriter writer = TheService!.OpenFileForWriting(filePath, encoding))
            {
                writer.Write(fileContent);
            }

            // Now append to the file
            const Boolean appendToFile = true;
            using (TextWriter writer = TheService!.OpenFileForWriting(filePath, encoding, appendToFile))
            {
                writer.Write(fileContent);
            }

            String actualFileContent;
            TheService!.EnsureFileExists(filePath);
            using (TextReader reader = TheService!.OpenFileForReading(filePath, encoding))
            {
                actualFileContent = reader.ReadToEnd();
            }

            Assert.That(actualFileContent, Is.EqualTo(fileContent + fileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_CopyFile_Success(String sourceFile)
        {
            String systemTempFolderPath = Path.GetTempPath();
            String outputFile = Guid.NewGuid().ToString();
            String destinationFilePath = Path.Combine(systemTempFolderPath, outputFile);
            TheService!.CopyFile(sourceFile, destinationFilePath);

            Boolean fileExists = TheService!.DoesFileExist(destinationFilePath);
            Assert.That(fileExists, Is.EqualTo(true));

            Stream sourceFileContent = File.OpenRead(sourceFile);
            Stream destinationFileContent = File.OpenRead(destinationFilePath);
            Assert.That(sourceFileContent, Is.EqualTo(destinationFileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_CopyFile_AlreadyExists(String sourceFile)
        {
            String errorMessage = $"The destination file path '{sourceFile}' already exists.";

            Exception? actualException = null;
            try
            {
                TheService!.CopyFile(sourceFile, sourceFile);
            }
            catch (Exception exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException, Is.InstanceOf<IOException>());

            if (actualException is IOException ioException)
            {
                String actualErrorMessage = ioException.Message;
                Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
            }
            else
            {
                Assert.Fail($"Unexpected exception: {actualException}");
            }
        }

        [TestCase]
        public void Test_MoveFile_Success()
        {
            String sourceFile = Guid.NewGuid().ToString();
            Encoding encoding = Encoding.UTF8;
            String fileContent = Guid.NewGuid().ToString();

            // Create the file first, before moving it
            using (TextWriter writer = TheService!.OpenFileForWriting(sourceFile, encoding))
            {
                writer.Write(fileContent);
            }

            String systemTempFolderPath = Path.GetTempPath();
            String outputFile = Guid.NewGuid().ToString();
            String destinationFilePath = Path.Combine(systemTempFolderPath, outputFile);

            MemoryStream sourceFileContent = new MemoryStream();
            using (Stream tempFileStream = File.OpenRead(sourceFile))
            {
                tempFileStream.CopyTo(sourceFileContent);
            }

            TheService!.MoveFile(sourceFile, destinationFilePath);

            Boolean sourceFileExists = TheService!.DoesFileExist(sourceFile);
            Assert.That(sourceFileExists, Is.EqualTo(false));

            Boolean destinationFileExists = TheService!.DoesFileExist(destinationFilePath);
            Assert.That(destinationFileExists, Is.EqualTo(true));
            Stream destinationFileContent = File.OpenRead(destinationFilePath);

            Assert.That(sourceFileContent, Is.EqualTo(destinationFileContent));
        }

        [TestCase]
        public void Test_MoveFile_AlreadyExists()
        {
            String sourceFile = Guid.NewGuid().ToString();
            Encoding encoding = Encoding.UTF8;
            String fileContent = Guid.NewGuid().ToString();

            // Create the file first, before moving it
            using (TextWriter writer = TheService!.OpenFileForWriting(sourceFile, encoding))
            {
                writer.Write(fileContent);
            }

            String errorMessage = $"The destination file path '{sourceFile}' already exists.";

            Exception? actualException = null;
            try
            {
                TheService!.MoveFile(sourceFile, sourceFile);
            }
            catch (Exception exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException, Is.InstanceOf<IOException>());

            if (actualException is IOException ioException)
            {
                String actualErrorMessage = ioException.Message;
                Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
            }
            else
            {
                Assert.Fail($"Unexpected exception: {actualException}");
            }
        }

        [TestCase]
        public void Test_DeleteFile_Exists()
        {
            String filePath = Guid.NewGuid().ToString();
            Encoding encoding = Encoding.UTF8;
            String fileContent = Guid.NewGuid().ToString();

            // Create the file first, before deleting it
            using (TextWriter writer = TheService!.OpenFileForWriting(filePath, encoding))
            {
                writer.Write(fileContent);
            }

            TheService!.EnsureFileExists(filePath);

            TheService!.DeleteFile(filePath);

            Boolean fileExists = TheService!.DoesFileExist(filePath);

            Assert.That(fileExists, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_DeleteFile_DoesNotExists()
        {
            String filePath = Guid.NewGuid().ToString();

            TheService!.DeleteFile(filePath);

            Boolean fileExists = TheService!.DoesFileExist(filePath);

            Assert.That(fileExists, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_CreateDirectory_DoesNotExist()
        {
            String basePath = ".";
            String newDirectoryName = Guid.NewGuid().ToString();
            const Boolean throwExceptionIfExists = false;

            Boolean checkDirectoryExists = TheService!.DoesDirectoryExist(newDirectoryName);

            Assert.That(checkDirectoryExists, Is.EqualTo(false));

            TheService!.CreateDirectory(basePath, newDirectoryName, throwExceptionIfExists);

            Boolean actualDirectoryExists = TheService!.DoesDirectoryExist(newDirectoryName);

            Assert.That(actualDirectoryExists, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_CreateDirectory_AlreadyExist()
        {
            String basePath = ".";
            String newDirectoryName = Guid.NewGuid().ToString();
            Boolean throwExceptionIfExists = false;

            Boolean checkDirectoryExists = TheService!.DoesDirectoryExist(newDirectoryName);

            Assert.That(checkDirectoryExists, Is.EqualTo(false));

            TheService!.CreateDirectory(basePath, newDirectoryName, throwExceptionIfExists);

            // Create a second time to ensure no exception is raised
            TheService!.CreateDirectory(basePath, newDirectoryName, throwExceptionIfExists);

            checkDirectoryExists = TheService!.DoesDirectoryExist(newDirectoryName);

            Assert.That(checkDirectoryExists, Is.EqualTo(true));

            String errorMessage = $@"The directory path '{basePath}\{newDirectoryName}' already exists, the directory '{newDirectoryName}' cannot be created again";

            Exception? actualException = null;
            try
            {
                throwExceptionIfExists = true;

                // Call the Create method a second time
                TheService!.CreateDirectory(basePath, newDirectoryName, throwExceptionIfExists);
            }
            catch (Exception exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_DeleteFolder()
        {
            String basePath1 = ".";
            String newDirectoryName1 = Guid.NewGuid().ToString();

            String basePath2 = Path.Combine(basePath1, newDirectoryName1);
            String newDirectoryName2 = Guid.NewGuid().ToString();

            const Boolean throwExceptionIfExists = false;
            const Boolean recursive = false;
            Boolean checkDirectoryExists;

            TheService!.CreateDirectory(basePath1, newDirectoryName1, throwExceptionIfExists);
            checkDirectoryExists = TheService!.DoesDirectoryExist(newDirectoryName1);
            Assert.That(checkDirectoryExists, Is.EqualTo(true));

            TheService!.CreateDirectory(basePath2, newDirectoryName2, throwExceptionIfExists);
            checkDirectoryExists = TheService!.DoesDirectoryExist(Path.Combine(basePath2, newDirectoryName2));
            Assert.That(checkDirectoryExists, Is.EqualTo(true));

            TheService!.DeleteDirectory(Path.Combine(basePath2, newDirectoryName2), recursive);

            checkDirectoryExists = TheService!.DoesDirectoryExist(Path.Combine(basePath2, newDirectoryName2));

            Assert.That(checkDirectoryExists, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_DeleteFolderRecursive_Success()
        {
            String basePath1 = ".";
            String newDirectoryName1 = Guid.NewGuid().ToString();

            String basePath2 = Path.Combine(basePath1, newDirectoryName1);
            String newDirectoryName2 = Guid.NewGuid().ToString();

            const Boolean throwExceptionIfExists = false;
            const Boolean recursive = true;
            Boolean checkDirectoryExists;

            TheService!.CreateDirectory(basePath1, newDirectoryName1, throwExceptionIfExists);
            checkDirectoryExists = TheService!.DoesDirectoryExist(newDirectoryName1);
            Assert.That(checkDirectoryExists, Is.EqualTo(true));

            TheService!.CreateDirectory(basePath2, newDirectoryName2, throwExceptionIfExists);
            checkDirectoryExists = TheService!.DoesDirectoryExist(Path.Combine(basePath2, newDirectoryName2));
            Assert.That(checkDirectoryExists, Is.EqualTo(true));

            TheService!.DeleteDirectory(basePath2, recursive);

            checkDirectoryExists = TheService!.DoesDirectoryExist(Path.Combine(basePath2, newDirectoryName2));
            Assert.That(checkDirectoryExists, Is.EqualTo(false));

            checkDirectoryExists = TheService!.DoesDirectoryExist(basePath2);
            Assert.That(checkDirectoryExists, Is.EqualTo(false));
        }


        [TestCase]
        public void Test_DeleteFolderRecursive_Fail()
        {
            String basePath1 = ".";
            String newDirectoryName1 = Guid.NewGuid().ToString();

            String basePath2 = Path.Combine(basePath1, newDirectoryName1);
            String newDirectoryName2 = Guid.NewGuid().ToString();

            const Boolean throwExceptionIfExists = false;
            const Boolean recursive = false;
            Boolean checkDirectoryExists;

            DirectoryInfo createdFolder = TheService!.CreateDirectory(basePath1, newDirectoryName1, throwExceptionIfExists);
            checkDirectoryExists = TheService!.DoesDirectoryExist(createdFolder.FullName);
            Assert.That(checkDirectoryExists, Is.EqualTo(true));

            TheService!.CreateDirectory(basePath2, newDirectoryName2, throwExceptionIfExists);
            checkDirectoryExists = TheService!.DoesDirectoryExist(Path.Combine(basePath2, newDirectoryName2));
            Assert.That(checkDirectoryExists, Is.EqualTo(true));

            String errorMessage = $"The directory is not empty. : '{createdFolder.FullName}'";

            IOException? actualException = null;
            try
            {
                TheService!.DeleteDirectory(basePath2, recursive);
            }
            catch (IOException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetNewTempFolderPath_False()
        {
            String systemTempFolderPath = Path.GetTempPath();
            String baseFolder = ".ExpectedResults";
            const Boolean createFolder = false;
            String actual = TheService!.GetNewTempFolderPath(baseFolder, createFolder);

            Assert.That(String.IsNullOrEmpty(actual), Is.EqualTo(false));
            Assert.That(String.IsNullOrWhiteSpace(actual), Is.EqualTo(false));

            String tempFolderPath = Path.GetDirectoryName(actual) ?? String.Empty;

            Assert.That(Path.Combine(systemTempFolderPath, baseFolder), Is.EqualTo(tempFolderPath));
        }

        [TestCase]
        public void Test_GetNewTempFolderPath_True()
        {
            String systemTempFolderPath = Path.GetTempPath();
            String baseFolder = ".ExpectedResults";
            const Boolean createFolder = true;
            String actual = TheService!.GetNewTempFolderPath(baseFolder, createFolder);

            Assert.That(String.IsNullOrEmpty(actual), Is.EqualTo(false));
            Assert.That(String.IsNullOrWhiteSpace(actual), Is.EqualTo(false));

            Boolean folderExists = TheService!.DoesDirectoryExist(actual);
            Assert.That(folderExists, Is.EqualTo(true));

            String tempFolderPath = Path.GetDirectoryName(actual) ?? String.Empty;
            Assert.That(Path.Combine(systemTempFolderPath, baseFolder), Is.EqualTo(tempFolderPath));
            TheService!.DeleteDirectory(tempFolderPath, recursive: true);
        }

        [TestCase]
        public void Test_WriteFileContent()
        {
            String systemTempFolderPath = Path.GetTempPath();
            String outputFile = Guid.NewGuid().ToString();
            String outputPath = Path.Combine(systemTempFolderPath, outputFile);
            String fileOutput1 = "Sample text";
            String fileOutput2 = "New data";

            MemoryStream memoryStream1 = new MemoryStream();
            StreamWriter sw1 = new StreamWriter(memoryStream1);
            sw1.Write(fileOutput1);
            sw1.Flush();

            TheService!.WriteFileContent(outputPath, memoryStream1);
            Boolean fileWrite1FileExists = TheService!.DoesFileExist(outputPath);
            Assert.That(fileWrite1FileExists, Is.EqualTo(true));

            MemoryStream memoryStream2 = new MemoryStream();
            StreamWriter sw2 = new StreamWriter(memoryStream2);
            sw2.Write(fileOutput2);
            sw2.Flush();

            TheService!.WriteFileContent(outputPath, memoryStream2, overwriteIfFileExists: true);
            Boolean fileWrite2FileExists = TheService!.DoesFileExist(outputPath);
            Assert.That(fileWrite2FileExists, Is.EqualTo(true));

            String fileContent = TheService!.GetFileContentsAsText(outputPath, Encoding.Default);
            Assert.That(fileContent, Is.EqualTo(fileOutput2));
        }

        [TestCase]
        public void Test_WriteFileContent_Overwrite()
        {
            String systemTempFolderPath = Path.GetTempPath();
            String outputFile = Guid.NewGuid().ToString();
            String outputPath = Path.Combine(systemTempFolderPath, outputFile);
            String fileOutput1 = "Sample text";
            String fileOutput2 = "New data";

            MemoryStream memoryStream1 = new MemoryStream();
            StreamWriter sw1 = new StreamWriter(memoryStream1);
            sw1.Write(fileOutput1);
            sw1.Flush();

            TheService!.WriteFileContent(outputPath, memoryStream1);
            Boolean fileWrite1FileExists = TheService!.DoesFileExist(outputPath);
            Assert.That(fileWrite1FileExists, Is.EqualTo(true));

            MemoryStream memoryStream2 = new MemoryStream();
            StreamWriter sw2 = new StreamWriter(memoryStream2);
            sw2.Write(fileOutput2);
            sw2.Flush();

            TheService!.WriteFileContent(outputPath, memoryStream2, overwriteIfFileExists: true);
            Boolean fileWrite2FileExists = TheService!.DoesFileExist(outputPath);
            Assert.That(fileWrite2FileExists, Is.EqualTo(true));

            String fileContent = TheService!.GetFileContentsAsText(outputPath, Encoding.Default);
            Assert.That(fileContent, Is.EqualTo(fileOutput2));
        }

        [TestCase]
        public void Test_RemoteServiceAPI_DeleteFile_FileExists()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                Location = Guid.NewGuid().ToString()
            };
            Encoding encoding = Encoding.UTF8;
            String fileContent = Guid.NewGuid().ToString();

            // Create the file first, before deleting to it
            using (TextWriter writer = TheService!.OpenFileForWriting(fileTransferSettings.Location, encoding))
            {
                writer.Write(fileContent);
            }

            TheService!.EnsureFileExists(fileTransferSettings.Location);

            TheService!.DeleteFile(fileTransferSettings);

            Boolean fileExists = TheService!.DoesFileExist(fileTransferSettings.Location);

            Assert.That(fileExists, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_RemoteServerAPI_DeleteFile_DoesNotExists()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                Location = Guid.NewGuid().ToString()
            };

            TheService!.DeleteFile(fileTransferSettings);

            Boolean fileExists = TheService!.DoesFileExist(fileTransferSettings.Location);

            Assert.That(fileExists, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_RemoteServiceAPI_DeleteFileAsync_FileExists()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                Location = Guid.NewGuid().ToString()
            };
            Encoding encoding = Encoding.UTF8;
            String fileContent = Guid.NewGuid().ToString();

            // Create the file first, before deleting to it
            using (TextWriter writer = TheService!.OpenFileForWriting(fileTransferSettings.Location, encoding))
            {
                writer.Write(fileContent);
            }

            TheService!.EnsureFileExists(fileTransferSettings.Location);

            Task t = TheService!.DeleteFileAsync(fileTransferSettings);
            t.Wait();

            Boolean fileExists = TheService!.DoesFileExist(fileTransferSettings.Location);

            Assert.That(fileExists, Is.EqualTo(false));
        }


        [TestCase]
        public void Test_RemoteServerAPI_DeleteFileAsync_DoesNotExists()
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                Location = Guid.NewGuid().ToString()
            };

            Task t = TheService!.DeleteFileAsync(fileTransferSettings);
            t.Wait();

            Boolean fileExists = TheService!.DoesFileExist(fileTransferSettings.Location);

            Assert.That(fileExists, Is.EqualTo(false));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_RemoteServiceAPI_DownloadFileAsStream(String sourceFile)
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = sourceFile,
            };

            Stream fileContent = TheService!.DownloadFile(fileTransferSettings)!;

            Stream actualFileContent = File.OpenRead(sourceFile);
            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_RemoteServiceAPI_DownloadFileAsStream_Async(String sourceFile)
        {
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = sourceFile,
            };

            Task<Stream?> t = TheService!.DownloadFileAsync(fileTransferSettings);

            t.Wait();
            Stream? fileContent = t.Result;

            Stream actualFileContent = File.OpenRead(sourceFile);
            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_RemoteServiceAPI_UploadFile(String sourceFile)
        {
            String targetLocation = Guid.NewGuid().ToString();
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = targetLocation,
            };

            Stream fileContent = File.OpenRead(sourceFile);

            String newLocation = TheService!.UploadFile(fileTransferSettings, sourceFile);

            Stream actualFileContent = File.OpenRead(newLocation);
            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_RemoteServiceAPI_UploadFileAsStream(String sourceFile)
        {
            String targetLocation = Guid.NewGuid().ToString();
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = targetLocation,
            };

            Stream fileContent = File.OpenRead(sourceFile);

            String newLocation = TheService!.UploadFile(fileTransferSettings, fileContent);

            Stream actualFileContent = File.OpenRead(newLocation);
            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_RemoteServiceAPI_UploadFile_Async(String sourceFile)
        {
            String targetLocation = Guid.NewGuid().ToString();
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = targetLocation,
            };

            Stream fileContent = File.OpenRead(sourceFile);

            Task<String> t = TheService!.UploadFileAsync(fileTransferSettings, sourceFile);

            t.Wait();
            String newLocation = t.Result;

            Stream actualFileContent = File.OpenRead(newLocation);
            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_RemoteServiceAPI_UploadFileAsStream_Async(String sourceFile)
        {
            String targetLocation = Guid.NewGuid().ToString();
            IFileTransferSettings fileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = targetLocation,
            };

            Stream fileContent = File.OpenRead(sourceFile);

            Task<String> t = TheService!.UploadFileAsync(fileTransferSettings, fileContent);

            t.Wait();
            String newLocation = t.Result;

            Stream actualFileContent = File.OpenRead(newLocation);
            Assert.That(actualFileContent, Is.EqualTo(fileContent));
        }

        [TestCase(@".Support\SampleDocuments\Sample Text Document.txt")]
        [TestCase(@".Support\SampleDocuments\32BitColour_16x16.bmp")]
        [TestCase(@".Support\SampleDocuments\Sample PDF Document.pdf")]
        [DeploymentItem(@".Support\SampleDocuments\Sample Text Document.txt", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        [DeploymentItem(@".Support\SampleDocuments\Sample PDF Document.pdf", @".Support\SampleDocuments\")]
        public void Test_RemoteServiceAPI_DownloadFile_Then_Upload(String sourceFile)
        {
            IFileTransferSettings sourceFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = sourceFile,
            };
            Stream fileContent = TheService!.DownloadFile(sourceFileTransferSettings)!;

            IFileTransferSettings destinationFileTransferSettings = new FileTransferSettings
            {
                FileTransferMethod = FileTransferMethod.FileSystem,
                Location = Path.Combine(@".Support\SampleDocuments\", Guid.NewGuid().ToString()),
            };
            TheService!.UploadFile(destinationFileTransferSettings, fileContent);

            Boolean fileExists = TheService!.DoesFileExist(destinationFileTransferSettings.Location);
            Assert.That(fileExists, Is.EqualTo(true));

            Stream sourceFileContent = File.OpenRead(sourceFileTransferSettings.Location);
            Stream destinationFileContent = File.OpenRead(destinationFileTransferSettings.Location);
            Assert.That(sourceFileContent, Is.EqualTo(destinationFileContent));
        }
    }
}
