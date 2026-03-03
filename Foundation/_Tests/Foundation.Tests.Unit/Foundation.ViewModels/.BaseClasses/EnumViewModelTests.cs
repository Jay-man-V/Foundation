//-----------------------------------------------------------------------
// <copyright file="EnumViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.ViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses
{
    /// <summary>
    /// Summary description for EnumViewModelTests
    /// </summary>
    public abstract class EnumViewModelTests<TModel, TViewModel, TBusinessProcess> : GenericDataGridViewModelTests<TModel, TViewModel, TBusinessProcess>
        where TModel : IFoundationModel
        where TViewModel : IViewModel
        where TBusinessProcess : ICommonBusinessProcess<TModel>
    {
        public override void TestInitialise()
        {
            base.TestInitialise();
        }

        protected EnumViewModel<TModel>? TheEnumViewModel => TheViewModel as EnumViewModel<TModel>;
    }
}
