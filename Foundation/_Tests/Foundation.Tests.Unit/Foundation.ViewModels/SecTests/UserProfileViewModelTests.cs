//-----------------------------------------------------------------------
// <copyright file="UserProfileViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Sec;
using Foundation.ViewModels.Sec;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests
{
    /// <summary>
    /// Summary description for UserProfileViewModelTests
    /// </summary>
    [TestFixture]
    public class UserProfileViewModelTests : GenericDataGridViewModelTests<IUserProfile, IUserProfileViewModel, IUserProfileProcess>
    {
        protected override IUserProfileProcess CreateBusinessProcess()
        {
            IUserProfileProcess process = Substitute.For<IUserProfileProcess>();

            return process;
        }

        protected override IUserProfile CreateBlankModel(Int32 entityId)
        {
            IUserProfile retVal = new UserProfile();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IUserProfile CreateModel(Int32 entityId)
        {
            IUserProfile retVal = base.CreateModel(entityId);

            retVal.ExternalKeyId = Guid.NewGuid().ToString();
            retVal.Username = Guid.NewGuid().ToString();
            retVal.DisplayName = Guid.NewGuid().ToString();
            retVal.IsSystemSupport = false;
            retVal.ContactDetailId = new EntityId(1);

            return retVal;
        }

        protected override IUserProfileViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IUserProfileViewModel viewModel = new UserProfileViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
