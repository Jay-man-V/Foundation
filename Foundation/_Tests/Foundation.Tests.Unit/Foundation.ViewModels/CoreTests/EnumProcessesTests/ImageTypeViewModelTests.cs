//-----------------------------------------------------------------------
// <copyright file="ImageTypeViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core.EnumModels;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ImageTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ImageTypeViewModelTests : GenericDataGridViewModelTests<IImageType, IImageTypeViewModel, IImageTypeProcess>
    {
        protected override IImageTypeProcess CreateBusinessProcess()
        {
            IImageTypeProcess process = Substitute.For<IImageTypeProcess>();

            return process;
        }

        protected override IImageType CreateBlankModel(Int32 entityId)
        {
            IImageType retVal = new ImageType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IImageType CreateModel(Int32 enityId)
        {
            IImageType retVal = base.CreateModel(enityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.FileExtension = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IImageTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IImageTypeViewModel viewModel = new ImageTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
