//-----------------------------------------------------------------------
// <copyright file="ViewModelUnitTestsBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;

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
        protected IFileApi FileApi { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ApplicationWrapper = Substitute.For<IApplicationWrapper>();
            ClipBoardWrapper = new MockClipBoardWrapper();
            DialogService = Substitute.For<IDialogService>();
            DispatcherTimerWrapper = new MockDispatcherTimerWrapper();
            DispatcherWrapper = new MockDispatcherWrapper();

            WpfApplicationObjects = Substitute.For<IWpfApplicationObjects>();
            WpfApplicationObjects.ApplicationWrapper.Returns(ApplicationWrapper);
            WpfApplicationObjects.ClipBoardWrapper.Returns(ClipBoardWrapper);
            WpfApplicationObjects.DialogService.Returns(DialogService);
            WpfApplicationObjects.DispatcherTimerWrapper.Returns(DispatcherTimerWrapper);
            WpfApplicationObjects.DispatcherWrapper.Returns(DispatcherWrapper);


            FileApi = Substitute.For<IFileApi>();

            //ViewModel.StatusProcess = StatusProcess;
            //ViewModel.UserProfileProcess = UserProfileProcess;
            //ViewModel.LoggedOnUserProcess = LoggedOnUserProcess;

            //ViewModel.StatusesList = StatusesList;
            //ViewModel.UserProfilesList = UserProfileList;
            //ViewModel.LoggedOnUsersList = LoggedOnUsersList;
        }
    }
}
