//-----------------------------------------------------------------------
// <copyright file="ViewModelBaseTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.Mocks.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels
{
    /// <summary>
    /// Summary description for ViewModelBaseTests
    /// </summary>
    [TestFixture]
    public class ViewModelBaseTests : ViewModelTestBaseClass<IMockViewModel>
    {
        protected override String ExpectedScreenTitle { get; set; } = "Mock View";

        protected override IMockViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IMockViewModel viewModel = new MockViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects);

            return viewModel;
        }
    }
}
