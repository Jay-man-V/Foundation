//-----------------------------------------------------------------------
// <copyright file="ContactTypeViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ContactTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ContactTypeViewModelTests : GenericDataGridViewModelTests<IContactType, IContactTypeViewModel, IContactTypeProcess>
    {
        protected override IContactTypeProcess CreateBusinessProcess()
        {
            IContactTypeProcess process = Substitute.For<IContactTypeProcess>();

            return process;
        }

        protected override IContactType CreateBlankModel(Int32 entityId)
        {
            IContactType retVal = Substitute.For<IContactType>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContactType CreateModel(Int32 entityId)
        {
            IContactType retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IContactTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContactTypeViewModel viewModel = new ContactTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
