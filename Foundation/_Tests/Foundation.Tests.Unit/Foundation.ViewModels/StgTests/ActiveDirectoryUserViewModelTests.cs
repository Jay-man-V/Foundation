//-----------------------------------------------------------------------
// <copyright file="ActiveDirectoryUserViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Stg;
using Foundation.ViewModels.Stg;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.StgTests
{
    /// <summary>
    /// Summary description for ActiveDirectoryUserViewModelTests
    /// </summary>
    [TestFixture]
    public class ActiveDirectoryUserViewModelTests : GenericDataGridViewModelTests<IActiveDirectoryUser, IActiveDirectoryUserViewModel, IActiveDirectoryUserProcess>
    {
        protected override IActiveDirectoryUserProcess CreateBusinessProcess()
        {
            IActiveDirectoryUserProcess process = Substitute.For<IActiveDirectoryUserProcess>();

            return process;
        }

        protected override IActiveDirectoryUser CreateBlankModel(Int32 entityId)
        {
            IActiveDirectoryUser retVal = new ActiveDirectoryUser();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IActiveDirectoryUser CreateModel(Int32 entityId)
        {
            IActiveDirectoryUser retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();
            retVal.ObjectSId = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IActiveDirectoryUserViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IActiveDirectoryUserViewModel viewModel = new ActiveDirectoryUserViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override Object SetupForAction1Command()
        {
            Object retVal = base.SetupForAction1Command();

            List<IActiveDirectoryUser> entities = [];
            BusinessProcess.GetAll().Returns(entities);

            TheViewModel!.RefreshCommand.Execute(null);

            return retVal;
        }

        protected override void AssertForAction1Command()
        {
            base.AssertForAction1Command();

            Assert.That(TheViewModel!.Action1CommandEnabled, Is.EqualTo(false));
        }

        protected override Object SetupForAction2Command()
        {
            Object retVal = base.SetupForAction2Command();

            List<IActiveDirectoryUser> entities = [];
            BusinessProcess.GetAll().Returns(entities);

            TheViewModel!.RefreshCommand.Execute(null);

            return retVal;
        }

        protected override void AssertForAction2Command()
        {
            base.AssertForAction2Command();

            Assert.That(TheViewModel!.Action2CommandEnabled, Is.EqualTo(false));
        }
    }
}
