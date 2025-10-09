//-----------------------------------------------------------------------
// <copyright file="ViewModelUnitTestsBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;
using Foundation.ViewModels.Services;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;
using Foundation.Tests.Unit.Mocks.Wrappers;

namespace Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses
{
    /// <summary>
    /// Summary description for ViewModelUnitTestsBase
    /// </summary>
    [TestFixture]
    public abstract class ViewModelUnitTestsBase : BusinessProcessUnitTestsBase
    {
        protected IWpfApplicationObjects WpfApplicationObjects { get; set; }
        protected IApplicationWrapper ApplicationWrapper { get; set; }
        protected IClipBoardWrapper ClipBoardWrapper { get; set; }
        protected IDialogService DialogService { get; set; }
        protected IDispatcherTimerWrapper DispatcherTimerWrapper { get; set; }
        protected IDispatcherWrapper DispatcherWrapper { get; set; }
        protected IMouseWrapper? MouseWrapper { get; set; }
        protected IFileApi FileApi { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ApplicationWrapper = Substitute.For<IApplicationWrapper>();
            ClipBoardWrapper = new MockClipBoardWrapper();
            DialogService = Substitute.For<IDialogService>();
            DispatcherTimerWrapper = new MockDispatcherTimerWrapper();
            DispatcherWrapper = new MockDispatcherWrapper();
            MouseWrapper = Substitute.For<IMouseWrapper>();

            WpfApplicationObjects = new WpfApplicationObjects(ApplicationWrapper, ClipBoardWrapper, DialogService, DispatcherTimerWrapper, DispatcherWrapper, MouseWrapper);

            FileApi = Substitute.For<IFileApi>();

            ViewModel.StatusProcess = StatusProcess;
            ViewModel.UserProfileProcess = UserProfileProcess;
            ViewModel.LoggedOnUserProcess = LoggedOnUserProcess;
        }

        public override void TestCleanup()
        {
            MouseWrapper!.Dispose();
            MouseWrapper = null;

            base.TestCleanup();
        }
    }
}
