//-----------------------------------------------------------------------
// <copyright file="ImportExportControlViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Log;

namespace Foundation.Tests.Unit.Foundation.ViewModels.LogTests
{
    /// <summary>
    /// Summary description for ImportExportControlViewModelTests
    /// </summary>
    [TestFixture]
    public class ImportExportControlViewModelTests : GenericDataGridViewModelTestBaseClass<IImportExportControl, IImportExportControlViewModel, IImportExportControlProcess>
    {
        protected override String ExpectedScreenTitle => "Import/Export Control";
        protected override String ExpectedStatusBarText => "Number of Import/Export Controls:";

        protected override IImportExportControlViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IImportExportControlViewModel viewModel = new ImportExportControlViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IImportExportControlProcess CreateBusinessProcess()
        {
            IImportExportControlProcess process = Substitute.For<IImportExportControlProcess>();

            return process;
        }

        protected override IImportExportControl CreateModel()
        {
            IImportExportControl retVal = base.CreateModel();

            retVal.ProcessedOn = new DateTime(2025, 01, 25, 23, 03, 15);
            retVal.Name = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
