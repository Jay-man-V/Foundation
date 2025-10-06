//-----------------------------------------------------------------------
// <copyright file="EntityViewModelBaseTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Mocks.ViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels
{
    /// <summary>
    /// Summary description for EntityViewModelBaseTests
    /// </summary>
    [TestFixture]
    public class EntityViewModelBaseTests : EntityViewModelTestBaseClass<IMockFoundationModel, IMockModelViewModel, IMockFoundationModelProcess>
    {
        protected override String ExpectedScreenTitle { get; set; } = "Mock View Model";

        protected override IMockModelViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IMockModelViewModel entityViewModel = new MockModelViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects);

            return entityViewModel;
        }

        protected override IMockFoundationModelProcess CreateBusinessProcess()
        {
            IMockFoundationModelProcess process = Substitute.For<IMockFoundationModelProcess>();

            return process;
        }

        protected override IMockFoundationModel CreateModel()
        {
            IMockFoundationModel retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override string NameOfModelPropertyToBeChangedForPropertyChangedEvent => nameof(IMockFoundationModel.IsOpen);
        protected override string NameOfViewModelPropertyToBeChangedForPropertyChangedEvent => nameof(IMockModelViewModel.StringProperty);

        protected override void ChangePropertyForPropertyChangedEvent(IMockModelViewModel viewModel, IMockFoundationModel model)
        {
            viewModel.StringProperty = Guid.NewGuid().ToString();
            model.IsOpen = !model.IsOpen;
        }
    }
}
