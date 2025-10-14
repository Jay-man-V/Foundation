//-----------------------------------------------------------------------
// <copyright file="CurrencyViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for CurrencyViewModelTests
    /// </summary>
    [TestFixture]
    public class CurrencyViewModelTests : GenericDataGridViewModelTests<ICurrency, ICurrencyViewModel, ICurrencyProcess>
    {
        protected override ICurrencyProcess CreateBusinessProcess()
        {
            ICurrencyProcess process = Substitute.For<ICurrencyProcess>();

            return process;
        }

        protected override ICurrency CreateBlankModel(Int32 entityId)
        {
            ICurrency retVal = new Currency();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ICurrency CreateModel(Int32 entityId)
        {
            ICurrency retVal = base.CreateModel(entityId);

            retVal.PrefixSymbol = true;
            retVal.Symbol = Guid.NewGuid().ToString();
            retVal.IsoCode = Guid.NewGuid().ToString();
            retVal.IsoNumber = Guid.NewGuid().ToString();
            retVal.Name = Guid.NewGuid().ToString();
            retVal.NumberToBasic = 100;

            return retVal;
        }

        protected override ICurrencyViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ICurrencyViewModel viewModel = new CurrencyViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
