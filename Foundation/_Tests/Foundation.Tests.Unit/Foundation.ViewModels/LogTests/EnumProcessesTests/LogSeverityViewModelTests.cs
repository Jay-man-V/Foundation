//-----------------------------------------------------------------------
// <copyright file="LogSeverityViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Log.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

using FModels = Foundation.Models.Log.EnumModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.LogTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for LogSeverityViewModelTests
    /// </summary>
    [TestFixture]
    public class LogSeverityViewModelTests : GenericDataGridViewModelTests<ILogSeverity, ILogSeverityViewModel, ILogSeverityProcess>
    {
        protected override ILogSeverityProcess CreateBusinessProcess()
        {
            ILogSeverityProcess process = Substitute.For<ILogSeverityProcess>();

            return process;
        }

        protected override ILogSeverity CreateBlankModel(Int32 entityId)
        {
            ILogSeverity retVal = new FModels.LogSeverity();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ILogSeverity CreateModel(Int32 entityId)
        {
            ILogSeverity retVal = base.CreateModel(entityId);

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override ILogSeverityViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ILogSeverityViewModel viewModel = new LogSeverityViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
