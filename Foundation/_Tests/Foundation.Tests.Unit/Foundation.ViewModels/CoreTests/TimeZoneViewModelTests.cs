//-----------------------------------------------------------------------
// <copyright file="TimeZoneViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for TimeZoneViewModelTests
    /// </summary>
    [TestFixture]
    public class TimeZoneViewModelTests : GenericDataGridViewModelTests<ITimeZone, ITimeZoneViewModel, ITimeZoneProcess>
    {
        protected override ITimeZoneProcess CreateBusinessProcess()
        {
            ITimeZoneProcess process = Substitute.For<ITimeZoneProcess>();

            return process;
        }

        protected override ITimeZone CreateBlankModel(Int32 entityId)
        {
            ITimeZone retVal = new FModels.TimeZone();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ITimeZone CreateModel(Int32 entityId)
        {
            ITimeZone retVal = base.CreateModel(entityId);

            retVal.Code = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();
            retVal.Offset = 1;
            retVal.HasDaylightSavings = true;

            return retVal;
        }

        protected override ITimeZoneViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ITimeZoneViewModel viewModel = new TimeZoneViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
