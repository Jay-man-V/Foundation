//-----------------------------------------------------------------------
// <copyright file="LanguageViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for LanguageViewModelTests
    /// </summary>
    [TestFixture]
    public class LanguageViewModelTests : GenericDataGridViewModelTestBaseClass<ILanguage, ILanguageViewModel, ILanguageProcess>
    {
        protected override String ExpectedScreenTitle => "Languages";
        protected override String ExpectedStatusBarText => "Number of Languages:";

        protected override ILanguageViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ILanguageViewModel viewModel = new LanguageViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override ILanguageProcess CreateBusinessProcess()
        {
            ILanguageProcess process = Substitute.For<ILanguageProcess>();

            return process;
        }

        protected override ILanguage CreateModel()
        {
            ILanguage retVal = base.CreateModel();

            retVal.EnglishName = Guid.NewGuid().ToString();
            retVal.NativeName = Guid.NewGuid().ToString();
            retVal.CultureCode = Guid.NewGuid().ToString();
            retVal.UiCultureCode = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
