//-----------------------------------------------------------------------
// <copyright file="ImportExportControlViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Log;
using Foundation.ViewModels.Log;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.LogTests
{
    /// <summary>
    /// Summary description for ImportExportControlViewModelTests
    /// </summary>
    [TestFixture]
    public class ImportExportControlViewModelTests : GenericDataGridViewModelTests<IImportExportControl, IImportExportControlViewModel, IImportExportControlProcess>
    {
        protected override IImportExportControlProcess CreateBusinessProcess()
        {
            IImportExportControlProcess process = Substitute.For<IImportExportControlProcess>();

            return process;
        }

        protected override IImportExportControl CreateBlankModel(Int32 entityId)
        {
            IImportExportControl retVal = new ImportExportControl();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IImportExportControl CreateModel(Int32 entityId)
        {
            IImportExportControl retVal = base.CreateModel(entityId);

            retVal.ProcessedOn = new DateTime(2025, 01, 25, 23, 03, 15);
            retVal.Name = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IImportExportControlViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IImportExportControlViewModel viewModel = new ImportExportControlViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
