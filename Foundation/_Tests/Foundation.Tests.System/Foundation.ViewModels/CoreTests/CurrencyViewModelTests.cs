//-----------------------------------------------------------------------
// <copyright file="CurrencyViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for CurrencyViewModelTests
    /// </summary>
    [TestFixture]
    public class CurrencyViewModelTests : GenericDataGridViewModelTestBaseClass<ICurrency, ICurrencyViewModel, ICurrencyProcess>
    {
        protected override String ExpectedScreenTitle => "Currencies";
        protected override String ExpectedStatusBarText => "Number of Currencies:";

        protected override ICurrencyViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ICurrencyViewModel viewModel = new CurrencyViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override ICurrencyProcess CreateBusinessProcess()
        {
            ICurrencyProcess process = Substitute.For<ICurrencyProcess>();

            return process;
        }

        protected override ICurrency CreateModel()
        {
            ICurrency retVal = base.CreateModel();

            retVal.PrefixSymbol = true;
            retVal.Symbol = Guid.NewGuid().ToString();
            retVal.IsoCode = Guid.NewGuid().ToString();
            retVal.IsoNumber = Guid.NewGuid().ToString();
            retVal.Name = Guid.NewGuid().ToString();
            retVal.NumberToBasic = 100;

            return retVal;
        }
    }
}
