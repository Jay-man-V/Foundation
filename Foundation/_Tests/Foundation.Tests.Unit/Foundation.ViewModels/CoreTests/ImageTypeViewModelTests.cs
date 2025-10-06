//-----------------------------------------------------------------------
// <copyright file="ImageTypeViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core.EnumViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ImageTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ImageTypeViewModelTests : GenericDataGridViewModelTestBaseClass<IImageType, IImageTypeViewModel, IImageTypeProcess>
    {
        protected override String ExpectedScreenTitle => "Image Types";
        protected override String ExpectedStatusBarText => "Number of Image Types:";

        protected override IImageTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IImageTypeViewModel viewModel = new ImageTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IImageTypeProcess CreateBusinessProcess()
        {
            IImageTypeProcess process = Substitute.For<IImageTypeProcess>();

            return process;
        }

        protected override IImageType CreateModel()
        {
            IImageType retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.FileExtension = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
