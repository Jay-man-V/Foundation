//-----------------------------------------------------------------------
// <copyright file="OfficeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for OfficeViewModelTests
    /// </summary>
    [TestFixture]
    public class OfficeViewModelTests : GenericDataGridViewModelTestBaseClass<IOffice, IOfficeViewModel, IOfficeProcess>
    {
        protected override String ExpectedScreenTitle => "Offices";
        protected override String ExpectedStatusBarText => "Number of Offices:";

        protected override IOfficeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IOfficeViewModel viewModel = new OfficeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IOfficeProcess CreateBusinessProcess()
        {
            IOfficeProcess process = Substitute.For<IOfficeProcess>();

            return process;
        }

        protected override IOffice CreateModel()
        {
            IOffice retVal = base.CreateModel();

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.ContactDetailId = new EntityId(0);
            retVal.OfficeWeekCalendarId = new EntityId(0);

            return retVal;
        }
    }
}
