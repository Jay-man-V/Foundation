//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalMultiplierMatrixViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ScheduleIntervalMultiplierMatrixViewModelTests
    /// </summary>
    [TestFixture]
    public class ScheduleIntervalMultiplierMatrixViewModelTests : GenericDataGridViewModelTests<IScheduleIntervalMultiplierMatrix, IScheduleIntervalMultiplierMatrixViewModel, IScheduleIntervalMultiplierMatrixProcess>
    {
        private IScheduleIntervalProcess? ScheduleIntervalProcess { get; set; }

        protected override IScheduleIntervalMultiplierMatrixProcess CreateBusinessProcess()
        {
            ScheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();
            IScheduleIntervalMultiplierMatrixProcess process = Substitute.For<IScheduleIntervalMultiplierMatrixProcess>();

            return process;
        }

        protected override IScheduleIntervalMultiplierMatrix CreateBlankModel(Int32 entityId)
        {
            IScheduleIntervalMultiplierMatrix retVal = new FModels.ScheduleIntervalMultiplierMatrix();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduleIntervalMultiplierMatrix CreateModel(Int32 entityId)
        {
            IScheduleIntervalMultiplierMatrix retVal = base.CreateModel(entityId);

            retVal.FromScheduleIntervalId = new EntityId(1);
            retVal.ToScheduleIntervalId = new EntityId(2);
            retVal.Multiplier = 3;
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IScheduleIntervalMultiplierMatrixViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IScheduleIntervalMultiplierMatrixViewModel viewModel = new ScheduleIntervalMultiplierMatrixViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ScheduleIntervalProcess!);

            return viewModel;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IScheduleInterval> scheduleIntervals =
            [
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>(),
            ];
            ScheduleIntervalProcess!.GetAll().Returns(scheduleIntervals);

            List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices = new List<IScheduleIntervalMultiplierMatrix>();
            BusinessProcess.ApplyFilter(Arg.Any<List<IScheduleIntervalMultiplierMatrix>>(), Arg.Any<IScheduleInterval>(), Arg.Any<IScheduleInterval>()).Returns(scheduleIntervalMultiplierMatrices);
        }

        protected override Object CreateModelForDropDown1()
        {
            return Substitute.For<IScheduleInterval>();
        }

        protected override Object CreateModelForDropDown2()
        {
            return Substitute.For<IScheduleInterval>();
        }
    }
}
