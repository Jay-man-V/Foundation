//-----------------------------------------------------------------------
// <copyright file="OfficeWeekCalendarViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for OfficeWeekCalendarViewModelTests
    /// </summary>
    [TestFixture]
    public class OfficeWeekCalendarCalendarViewModelTests : GenericDataGridViewModelTests<IOfficeWeekCalendar, IOfficeWeekCalendarViewModel, IOfficeWeekCalendarProcess>
    {
        protected override IOfficeWeekCalendarProcess CreateBusinessProcess()
        {
            IOfficeWeekCalendarProcess process = Substitute.For<IOfficeWeekCalendarProcess>();

            return process;
        }

        protected override IOfficeWeekCalendar CreateBlankModel(Int32 entityId)
        {
            IOfficeWeekCalendar retVal = new OfficeWeekCalendar();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IOfficeWeekCalendar CreateModel(Int32 entityId)
        {
            IOfficeWeekCalendar retVal = base.CreateModel(entityId);

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.Mon = true;
            retVal.Tue = true;
            retVal.Wed = true;
            retVal.Thu = true;
            retVal.Fri = true;
            retVal.Sat = true;
            retVal.Sun = true;

            return retVal;
        }

        protected override IOfficeWeekCalendarViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IOfficeWeekCalendarViewModel viewModel = new OfficeWeekCalendarViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
