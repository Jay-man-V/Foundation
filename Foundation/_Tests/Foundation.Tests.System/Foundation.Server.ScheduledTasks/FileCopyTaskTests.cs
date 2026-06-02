//-----------------------------------------------------------------------
// <copyright file="FileCopyTaskTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
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
        private String ClassName { get; set; }
        private IFileCopyTask? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ClassName = this.GetType().Name;

            TheService = CoreInstance.IoC.Get<IFileCopyTask>();
        }

        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestCase]
        public void Test_RunTask_NoArchive()
        {
            String functionName = LocationUtils.GetFunctionName();

            FileCopyTaskParameters fileCopyTaskParameters = new FileCopyTaskParameters
            {
                ApplicationName = ClassName,
                BatchName = BatchName,
                ProcessName = ProcessName,
                TaskName = functionName,

                SourceFilePath = $@"{BaseTemporaryOutputsPath}\Source\{Guid.NewGuid()}",
                DestinationFilePath = $@"{BaseTemporaryOutputsPath}\Destination\{Guid.NewGuid()}",
            };

            // Setup - Create source folder and add files to it
            String[] filesToCopy = ["ExistingFile.txt", "FileToDelete.txt", "SmallFile.txt"];
            Directory.CreateDirectory(fileCopyTaskParameters.SourceFilePath);
            foreach (String fileToCopy in filesToCopy)
            {
                File.Copy($@".ExpectedResults\FileManagement\{fileToCopy}", Path.Combine(fileCopyTaskParameters.SourceFilePath, fileToCopy));
            }

            // Create the Destination Folder
            Directory.CreateDirectory(fileCopyTaskParameters.DestinationFilePath);

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
        }

        [TestCase]
        public void Test_RunTask_WithArchive()
        {
            String functionName = LocationUtils.GetFunctionName();

            FileCopyTaskParameters fileCopyTaskParameters = new FileCopyTaskParameters
            {
                ApplicationName = ClassName,
                BatchName = BatchName,
                ProcessName = ProcessName,
                TaskName = functionName,

                SourceFilePath = $@"{BaseTemporaryOutputsPath}\Source\{Guid.NewGuid()}",
                DestinationFilePath = $@"{BaseTemporaryOutputsPath}\Destination\{Guid.NewGuid()}",
                ArchiveFilePath = $@"{BaseTemporaryOutputsPath}\Archive\{Guid.NewGuid()}",
            };

            // Setup - Create source folder and add files to it
            String[] filesToCopy = ["ExistingFile.txt", "FileToDelete.txt", "SmallFile.txt"];
            Directory.CreateDirectory(fileCopyTaskParameters.SourceFilePath);
            foreach (String fileToCopy in filesToCopy)
            {
                File.Copy($@".ExpectedResults\FileManagement\{fileToCopy}", Path.Combine(fileCopyTaskParameters.SourceFilePath, fileToCopy));
            }

            // Create the Destination and Archive Folders
            Directory.CreateDirectory(fileCopyTaskParameters.DestinationFilePath);
            Directory.CreateDirectory(fileCopyTaskParameters.ArchiveFilePath);

            // Get list of files in source folder before task is run
            List<String> sourceFilesBefore = Directory.GetFiles(fileCopyTaskParameters.SourceFilePath).ToList();
            Assert.That(sourceFilesBefore.Count, Is.EqualTo(filesToCopy.Length));

            List<String> destinationFolderBefore = Directory.GetFiles(fileCopyTaskParameters.DestinationFilePath).ToList();
            Assert.That(destinationFolderBefore.Count, Is.EqualTo(0));

            String taskParameters = SerialisationHelpers.Serialise(fileCopyTaskParameters);
            TheService!.RunTask(RootLogId, taskParameters);

            // Get list of files in source folder after task is run and compare with list before task is run to ensure files have been copied

            // With archiving enabled, source folder should be empty after task is run as files should have been moved to destination folder and archived
            List<String> sourceFolderAfter = Directory.GetFiles(fileCopyTaskParameters.SourceFilePath).ToList();
            Assert.That(sourceFolderAfter.Count, Is.EqualTo(0));

            List<String> destinationFolderAfter = Directory.GetFiles(fileCopyTaskParameters.DestinationFilePath).ToList();
            Assert.That(destinationFolderAfter.Count, Is.EqualTo(filesToCopy.Length));

            foreach (String fileToCopy in filesToCopy)
            {
                String sourceFileContent = File.ReadAllText($@".ExpectedResults\FileManagement\{fileToCopy}");
                String destinationFileContent = File.ReadAllText(Path.Combine(fileCopyTaskParameters.DestinationFilePath, fileToCopy));

                Assert.That(destinationFileContent, Is.EqualTo(sourceFileContent), $"Content of '{fileToCopy}' does not match");
            }

            // Get list of files in source folder after task is run and compare with list before task is run to ensure files have been copied
            List<String> archiveFolderAfter = Directory.GetFiles(fileCopyTaskParameters.ArchiveFilePath).ToList();
            Assert.That(archiveFolderAfter.Count, Is.EqualTo(filesToCopy.Length));

            foreach (String fileToCopy in filesToCopy)
            {
                String sourceFileContent = File.ReadAllText($@".ExpectedResults\FileManagement\{fileToCopy}");
                String destinationFileContent = File.ReadAllText(Path.Combine(fileCopyTaskParameters.DestinationFilePath, fileToCopy));

                Assert.That(destinationFileContent, Is.EqualTo(sourceFileContent), $"Content of '{fileToCopy}' does not match");
            }
        }
    }
}
