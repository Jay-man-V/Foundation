////-----------------------------------------------------------------------
//// <copyright file="MockViewModel.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using Foundation.Interfaces;
//using Foundation.ViewModels;

//namespace Foundation.Tests.Unit.Mocks.ViewModels
//{
//    public interface IMockViewModel : IViewModel
//    {
//        String StringProperty { get; set; }
//    }

//    public class MockViewModel : ViewModelBase, IMockViewModel
//    {
//        public MockViewModel
//        (
//            ICore core,
//            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
//            IDateTimeService dateTimeService,
//            IWpfApplicationObjects wpfApplicationObjects
//        )
//            : base
//            (
//                core,
//                runTimeEnvironmentSettings,
//                dateTimeService,
//                wpfApplicationObjects,
//                "Mock View"
//            )
//        {
//        }

//        private String _stringProperty = String.Empty;
//        public string StringProperty
//        {
//            get => _stringProperty;
//            set => SetPropertyValue(ref _stringProperty, value);
//        }

//        public override void Initialise()
//        {
//            // Does nothing
//        }
//    }
//}
