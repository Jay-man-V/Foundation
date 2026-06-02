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
            LogId parentLogId = LoggingService!.CreateLogEntry(RootLogId, CoreInstance.ApplicationId, BatchName, ClassName, functionName, LogSeverity.Testing, String.Empty);

            FileCopyTaskParameters fileCopyTaskParameters = new FileCopyTaskParameters
            {
                ApplicationName = ClassName,
                BatchName = BatchName,
                TaskName = functionName,

                SourceFilePath = $@".ExpectedResults\FileManagement\{Guid.NewGuid()}",
                DestinationFilePath = $@".ExpectedResults\FolderToDelete\{Guid.NewGuid()}",
            };

            // Setup - Create source folder and add files to it
            Directory.CreateDirectory(fileCopyTaskParameters.SourceFilePath);
            File.Copy(@".ExpectedResults\FileManagement\ExistingFile.txt", Path.Combine(fileCopyTaskParameters.SourceFilePath, "ExistingFile.txt"));
            File.Copy(@".ExpectedResults\FileManagement\FileToDelete.txt", Path.Combine(fileCopyTaskParameters.SourceFilePath, "FileToDelete.txt"));
            File.Copy(@".ExpectedResults\FileManagement\SmallFile.txt", Path.Combine(fileCopyTaskParameters.SourceFilePath, "SmallFile.txt"));

            // Create the Destination Folder
            Directory.CreateDirectory(fileCopyTaskParameters.DestinationFilePath);

            // Get list of files in source folder before task is run
            List<String> sourceFilesBefore = Directory.GetFiles(fileCopyTaskParameters.SourceFilePath).ToList();
            Assert.That(sourceFilesBefore.Count, Is.EqualTo(3));

            List<String> destinationFolderBefore = Directory.GetFiles(fileCopyTaskParameters.DestinationFilePath).ToList();
            Assert.That(destinationFolderBefore.Count, Is.EqualTo(0));

            String taskParameters = SerialisationHelpers.Serialise(fileCopyTaskParameters);

            TheService!.RunTask(parentLogId, taskParameters);

            // Get list of files in source folder after task is run and compare with list before task is run to ensure files have been copied
        }
    }
}
