//-----------------------------------------------------------------------
// <copyright file="UserProfileViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Sec;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests
{
    /// <summary>
    /// Summary description for UserProfileViewModelTests
    /// </summary>
    [TestFixture]
    public class UserProfileViewModelTests : GenericDataGridViewModelTestBaseClass<IUserProfile, IUserProfileViewModel, IUserProfileProcess>
    {
        protected override String ExpectedScreenTitle => "User Profiles";
        protected override String ExpectedStatusBarText => "Number of User Profiles:";

        protected override IUserProfileViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IUserProfileViewModel viewModel = new UserProfileViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IUserProfileProcess CreateBusinessProcess()
        {
            IUserProfileProcess process = Substitute.For<IUserProfileProcess>();

            return process;
        }

        protected override IUserProfile CreateModel()
        {
            IUserProfile retVal = base.CreateModel();

            retVal.ExternalKeyId = Guid.NewGuid().ToString();
            retVal.Username = Guid.NewGuid().ToString();
            retVal.DisplayName = Guid.NewGuid().ToString();
            retVal.IsSystemSupport = false;
            retVal.ContactDetailId = new EntityId(1);

            return retVal;
        }
    }
}
