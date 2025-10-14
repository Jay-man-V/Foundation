//-----------------------------------------------------------------------
// <copyright file="OfficeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for OfficeViewModelTests
    /// </summary>
    [TestFixture]
    public class OfficeViewModelTests : GenericDataGridViewModelTests<IOffice, IOfficeViewModel, IOfficeProcess>
    {
        protected override IOfficeProcess CreateBusinessProcess()
        {
            IOfficeProcess process = Substitute.For<IOfficeProcess>();

            return process;
        }

        protected override IOffice CreateBlankModel(Int32 entityId)
        {
            IOffice retVal = new Office();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IOffice CreateModel(Int32 entityId)
        {
            IOffice retVal = base.CreateModel(entityId);

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.ContactDetailId = new EntityId(0);
            retVal.OfficeWeekCalendarId = new EntityId(0);

            return retVal;
        }

        protected override IOfficeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IOfficeViewModel viewModel = new OfficeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
