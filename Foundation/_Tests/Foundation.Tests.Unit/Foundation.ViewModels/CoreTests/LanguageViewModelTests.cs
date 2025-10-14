//-----------------------------------------------------------------------
// <copyright file="LanguageViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for LanguageViewModelTests
    /// </summary>
    [TestFixture]
    public class LanguageViewModelTests : GenericDataGridViewModelTests<ILanguage, ILanguageViewModel, ILanguageProcess>
    {
        protected override ILanguageProcess CreateBusinessProcess()
        {
            ILanguageProcess process = Substitute.For<ILanguageProcess>();

            return process;
        }

        protected override ILanguage CreateBlankModel(Int32 entityId)
        {
            ILanguage retVal = new Language();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ILanguage CreateModel(Int32 entityId)
        {
            ILanguage retVal = base.CreateModel(entityId);

            retVal.EnglishName = Guid.NewGuid().ToString();
            retVal.NativeName = Guid.NewGuid().ToString();
            retVal.CultureCode = Guid.NewGuid().ToString();
            retVal.UiCultureCode = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override ILanguageViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ILanguageViewModel viewModel = new LanguageViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
