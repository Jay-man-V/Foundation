//-----------------------------------------------------------------------
// <copyright file="OfficeWeekCalendarViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for OfficeWeekCalendarViewModelTests
    /// </summary>
    [TestFixture]
    public class OfficeWeekCalendarCalendarViewModelTests : GenericDataGridViewModelTestBaseClass<IOfficeWeekCalendar, IOfficeWeekCalendarViewModel, IOfficeWeekCalendarProcess>
    {
        protected override String ExpectedScreenTitle => "Office Week Calendars";
        protected override String ExpectedStatusBarText => "Number of Office Week Calendars:";

        protected override IOfficeWeekCalendarViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IOfficeWeekCalendarViewModel viewModel = new OfficeWeekCalendarViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IOfficeWeekCalendarProcess CreateBusinessProcess()
        {
            IOfficeWeekCalendarProcess process = Substitute.For<IOfficeWeekCalendarProcess>();

            return process;
        }

        protected override IOfficeWeekCalendar CreateModel()
        {
            IOfficeWeekCalendar retVal = base.CreateModel();

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
    }
}
