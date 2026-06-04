//-----------------------------------------------------------------------
// <copyright file="FileCopyTaskTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.Resources;
using Foundation.Server.ScheduledTasks.TaskParameters;

using Foundation.Tests.System.BaseClasses;

namespace Foundation.Tests.System.Foundation.Server.ScheduledTasks
{
    /// <summary>
    /// System Tests for FileCopyTaskTests
    /// </summary>
    [TestFixture]
    public class FileCopyTaskTests : SystemTestBase
    {
        private String ClassName => LocationUtils.GetClassName();
        private IFileCopyTask? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = CoreInstance.IoC.Get<IFileCopyTask>();
        }

        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        protected override List<IApplicationConfiguration> GetTestApplicationConfigurations()
        {
            List<IApplicationConfiguration> retVal = base.GetTestApplicationConfigurations();

            IApplicationConfiguration applicationConfiguration;

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailSubject", EmailSubject);
            retVal.Add(applicationConfiguration);

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailToAddresses", EmailToAddress);
            retVal.Add(applicationConfiguration);

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailCcAddresses", EmailCcAddress);
            retVal.Add(applicationConfiguration);

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailFromAddresses", EmailFromAddress);
            retVal.Add(applicationConfiguration);

            return retVal;
        }

        [TestCase(true, true, true, true)]
        [TestCase(true, true, true, false)]
        [TestCase(true, true, false, true)]
        [TestCase(true, true, false, false)]
        [TestCase(true, false, true, true)]
        [TestCase(true, false, true, false)]
        [TestCase(true, false, false, true)]
        [TestCase(true, false, false, false)]
        [TestCase(false, true, true, true)]
        [TestCase(false, true, true, false)]
        [TestCase(false, true, false, true)]
        [TestCase(false, true, false, false)]
        [TestCase(false, false, true, true)]
        [TestCase(false, false, true, false)]
        [TestCase(false, false, false, true)]
        [TestCase(false, false, false, false)]
        public void Test_RunTask(Boolean archiveFiles, Boolean emailAfterCopy, Boolean attachFilesToEmail, Boolean emailAddFilePathsToEmail)
        {
            String functionName = LocationUtils.GetFunctionName();

            FileCopyTaskParameters fileCopyTaskParameters = new FileCopyTaskParameters
            {
                ApplicationName = ClassName,
                BatchName = BatchName,
                ProcessName = ProcessName,
                TaskName = functionName,

                SourceFileMask = String.Empty,
                CopyFilesSinceLastRun = false,
                SourceFilePath = Path.Combine(BaseTemporaryOutputsPath, "Source", Guid.NewGuid().ToString()),
                DestinationFilePath = Path.Combine(BaseTemporaryOutputsPath, "Destination", Guid.NewGuid().ToString()),

                EmailAfterCopy = false, //emailAfterCopy,
                EmailAdditionalText = $"Additional text for {functionName}, (EmailAfterCopy: {emailAfterCopy}. AttachFilesToEmail: {attachFilesToEmail}. EmailAddFilePathsToEmail: {emailAddFilePathsToEmail})",
                EmailSubjectConfigKey = $"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailSubject",
                EmailFromAddressesConfigKey = $"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailFromAddresses",
                EmailToAddressesConfigKey = $"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailToAddresses",
                EmailCcAddressesConfigKey = $"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailCcAddresses",
                AttachFilesToEmail = attachFilesToEmail,
                EmailAddFilePathsToEmail = emailAddFilePathsToEmail,
            };

            if (archiveFiles)
            {
                fileCopyTaskParameters.ArchiveFilePath = Path.Combine(BaseTemporaryOutputsPath, "Archive", Guid.NewGuid().ToString());
            }

            // Setup - Create source folder and add files to it
            String[] filesToCopy = ["ExistingFile.txt", "FileToDelete.txt", "SmallFile.txt"];
            Directory.CreateDirectory(fileCopyTaskParameters.SourceFilePath);
            foreach (String fileToCopy in filesToCopy)
            {
                File.Copy($@".ExpectedResults\FileManagement\{fileToCopy}", Path.Combine(fileCopyTaskParameters.SourceFilePath, fileToCopy));
            }

            // Create the Destination and Archive Folders
            Directory.CreateDirectory(fileCopyTaskParameters.DestinationFilePath);

            if (archiveFiles)
            {
                Directory.CreateDirectory(fileCopyTaskParameters.ArchiveFilePath);
            }

            // Get list of files in source folder before task is run
            List<String> sourceFilesBefore = Directory.GetFiles(fileCopyTaskParameters.SourceFilePath).ToList();
            Assert.That(sourceFilesBefore.Count, Is.EqualTo(filesToCopy.Length));

            List<String> destinationFolderBefore = Directory.GetFiles(fileCopyTaskParameters.DestinationFilePath).ToList();
            Assert.That(destinationFolderBefore.Count, Is.EqualTo(0));

            String taskParameters = SerialisationHelpers.Serialise(fileCopyTaskParameters);
            TheService!.RunTask(RootLogId, taskParameters);

            // Get list of files in source folder after task is run and compare with list before task is run to ensure files have been copied
            List<String> destinationFolderAfter = Directory.GetFiles(fileCopyTaskParameters.DestinationFilePath).ToList();
            Assert.That(destinationFolderAfter.Count, Is.EqualTo(filesToCopy.Length));

            foreach (String fileToCopy in filesToCopy)
            {
                String sourceFileContent = File.ReadAllText($@".ExpectedResults\FileManagement\{fileToCopy}");
                String destinationFileContent = File.ReadAllText(Path.Combine(fileCopyTaskParameters.DestinationFilePath, fileToCopy));

                Assert.That(destinationFileContent, Is.EqualTo(sourceFileContent), $"Content of '{fileToCopy}' does not match");
            }

            if (archiveFiles)
            {
                // Get list of files in source folder after task is run and compare with list before task is run to ensure files have been copied
                List<String> archiveFolderAfter = Directory.GetFiles(fileCopyTaskParameters.ArchiveFilePath).ToList();
                Assert.That(archiveFolderAfter.Count, Is.EqualTo(filesToCopy.Length));

                Thread.Sleep(1500); // Wait for 1 second to ensure all files are copied

                foreach (String fileToCopy in filesToCopy)
                {
                    String sourceFileContent = File.ReadAllText($@".ExpectedResults\FileManagement\{fileToCopy}");
                    String destinationFileContent = File.ReadAllText(Path.Combine(fileCopyTaskParameters.DestinationFilePath, fileToCopy));

                    Assert.That(destinationFileContent, Is.EqualTo(sourceFileContent), $"Content of '{fileToCopy}' does not match");
                }
            }
        }
    }
}
