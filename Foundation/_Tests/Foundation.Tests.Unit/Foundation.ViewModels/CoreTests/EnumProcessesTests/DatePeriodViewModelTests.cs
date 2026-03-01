//-----------------------------------------------------------------------
// <copyright file="DatePeriodViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

using FModels = Foundation.Models.Core.EnumModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for DatePeriodViewModelTests
    /// </summary>
    [TestFixture]
    public class DatePeriodViewModelTests : GenericDataGridViewModelTests<IDatePeriod, IDatePeriodViewModel, IDatePeriodProcess>
    {
        protected override IDatePeriodProcess CreateBusinessProcess()
        {
            IDatePeriodProcess process = Substitute.For<IDatePeriodProcess>();

            return process;
        }

        protected override IDatePeriod CreateBlankModel(Int32 entityId)
        {
            IDatePeriod retVal = new FModels.DatePeriod();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IDatePeriod CreateModel(Int32 entityId)
        {
            IDatePeriod retVal = base.CreateModel(entityId);

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IDatePeriodViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IDatePeriodViewModel viewModel = new DatePeriodViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
