//-----------------------------------------------------------------------
// <copyright file="MockGenericDataGridViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.ViewModels;

namespace Foundation.Tests.Unit.Mocks.ViewModels
{
    public interface IMockGenericDataGridViewModel : IViewModel
    {
        String StringProperty { get; set; }
    }

    public class MockGenericDataGridViewModel : GenericDataGridViewModelBase<IMockFoundationModel>, IMockGenericDataGridViewModel
    {
        public MockGenericDataGridViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IMockFoundationModelProcess commonBusinessProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                commonBusinessProcess
            )
        {
        }

        private String _stringProperty = String.Empty;
        public string StringProperty
        {
            get => _stringProperty;
            set => SetPropertyValue(ref _stringProperty, value);
        }

        public override void Initialise()
        {
            // Does nothing
        }
    }
}
