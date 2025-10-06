//-----------------------------------------------------------------------
// <copyright file="ActiveDirectoryUserViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Stg;

namespace Foundation.Tests.Unit.Foundation.ViewModels.StgTests
{
    /// <summary>
    /// Summary description for ActiveDirectoryUserViewModelTests
    /// </summary>
    [TestFixture]
    public class ActiveDirectoryUserViewModelTests : GenericDataGridViewModelTestBaseClass<IActiveDirectoryUser, IActiveDirectoryUserViewModel, IActiveDirectoryUserProcess>
    {
        protected override String ExpectedScreenTitle => "Active Directory Users";
        protected override String ExpectedStatusBarText => "Number of Active Directory Users:";

        protected override Boolean ExpectedHasOptionalAction1 => true;
        protected override String ExpectedAction1Name => "Save to Staging";
        protected override Boolean ExpectedHasOptionalAction2 => true;
        protected override String ExpectedAction2Name => "Sync User Profiles";


        protected override IActiveDirectoryUserViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IActiveDirectoryUserViewModel viewModel = new ActiveDirectoryUserViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IActiveDirectoryUserProcess CreateBusinessProcess()
        {
            IActiveDirectoryUserProcess process = Substitute.For<IActiveDirectoryUserProcess>();

            return process;
        }

        protected override IActiveDirectoryUser CreateModel()
        {
            IActiveDirectoryUser retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();
            retVal.ObjectSId = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override Object SetupForAction1Command(IActiveDirectoryUserViewModel viewModel)
        {
            Object retVal = base.SetupForAction1Command(viewModel);

            List<IActiveDirectoryUser> entities = new List<IActiveDirectoryUser>();
            BusinessProcess.GetAll().Returns(entities);

            viewModel.RefreshCommand.Execute(null);

            return retVal;
        }

        protected override void AssertForAction1Command(IActiveDirectoryUserViewModel viewModel)
        {
            base.AssertForAction1Command(viewModel);

            Assert.That(viewModel.Action1CommandEnabled, Is.EqualTo(false));
        }

        protected override Object SetupForAction2Command(IActiveDirectoryUserViewModel viewModel)
        {
            Object retVal = base.SetupForAction2Command(viewModel);

            List<IActiveDirectoryUser> entities = new List<IActiveDirectoryUser>();
            BusinessProcess.GetAll().Returns(entities);

            viewModel.RefreshCommand.Execute(null);

            return retVal;
        }

        protected override void AssertForAction2Command(IActiveDirectoryUserViewModel viewModel)
        {
            base.AssertForAction2Command(viewModel);

            Assert.That(viewModel.Action2CommandEnabled, Is.EqualTo(false));
        }
    }
}
