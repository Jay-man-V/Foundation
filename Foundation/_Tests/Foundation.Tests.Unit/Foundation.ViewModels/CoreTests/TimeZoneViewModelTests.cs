//-----------------------------------------------------------------------
// <copyright file="TimeZoneViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for TimeZoneViewModelTests
    /// </summary>
    [TestFixture]
    public class TimeZoneViewModelTests : GenericDataGridViewModelTestBaseClass<ITimeZone, ITimeZoneViewModel, ITimeZoneProcess>
    {
        protected override String ExpectedScreenTitle => "Time Zones";
        protected override String ExpectedStatusBarText => "Number of Time Zones:";

        protected override ITimeZoneViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ITimeZoneViewModel viewModel = new TimeZoneViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override ITimeZoneProcess CreateBusinessProcess()
        {
            ITimeZoneProcess process = Substitute.For<ITimeZoneProcess>();

            return process;
        }

        protected override ITimeZone CreateModel()
        {
            ITimeZone retVal = base.CreateModel();

            retVal.Code = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();
            retVal.Offset = 1;
            retVal.HasDaylightSavings = true;

            return retVal;
        }
    }
}
