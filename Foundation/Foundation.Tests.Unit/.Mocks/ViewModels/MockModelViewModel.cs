//-----------------------------------------------------------------------
// <copyright file="MockModelViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using Foundation.Interfaces;
using Foundation.ViewModels;

namespace Foundation.Tests.Unit.Mocks
{
    public interface IMockModelViewModel : IEntityViewModel
    {
        String StringProperty { get; set; }
    }

    public class MockModelViewModel : EntityViewModelBase<IMockFoundationModel>, IMockModelViewModel
    {
        public MockModelViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                "Mock View Model"
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
