//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalMultiplierMatrixProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for ScheduleIntervalMultiplierMatrixProcessTests
    /// </summary>
    [TestFixture]
    public class ScheduleIntervalMultiplierMatrixProcessTests : CommonBusinessProcessTests<IScheduleIntervalMultiplierMatrix, IScheduleIntervalMultiplierMatrixProcess, IScheduleIntervalMultiplierMatrixRepository>
    {
        private IScheduleIntervalProcess? ScheduleIntervalProcess { get; set; }

        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "Schedule Interval Multiplier Matrix";
        protected override String ExpectedStatusBarText => "Number of Schedule Interval Multiplier Matrices:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "From Schedule Interval:";
        protected override string ExpectedFilter1DisplayMemberPath => FDC.ScheduleInterval.Name;

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "To Schedule Interval:";
        protected override string ExpectedFilter2DisplayMemberPath => FDC.ScheduleInterval.Name;

        protected override IScheduleIntervalMultiplierMatrixRepository CreateRepository()
        {
            IScheduleIntervalMultiplierMatrixRepository retVal = Substitute.For<IScheduleIntervalMultiplierMatrixRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IScheduleIntervalMultiplierMatrixProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ScheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();

            SetComboBoxProperties(ScheduleIntervalProcess);

            IScheduleIntervalMultiplierMatrixProcess process = new ScheduleIntervalMultiplierMatrixProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!, ScheduleIntervalProcess);

            return process;
        }

        protected override IScheduleIntervalMultiplierMatrix CreateBlankEntity(Int32 entityId)
        {
            IScheduleIntervalMultiplierMatrix retVal = new FModels.ScheduleIntervalMultiplierMatrix();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduleIntervalMultiplierMatrix CreateEntity(IScheduleIntervalMultiplierMatrixProcess process, Int32 entityId)
        {
            IScheduleIntervalMultiplierMatrix retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.FromScheduleIntervalId = new EntityId(10);
            retVal.ToScheduleIntervalId = new EntityId(2);
            retVal.Multiplier = 123;
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IScheduleIntervalMultiplierMatrix entity)
        {
            //Assert.That(entity.DisplayName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IScheduleIntervalMultiplierMatrix entity)
        {
            //Assert.That(entity.DisplayName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IScheduleIntervalMultiplierMatrix entity)
        {
            //Assert.That(entity.DisplayName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IScheduleIntervalMultiplierMatrix entity1, IScheduleIntervalMultiplierMatrix entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.FromScheduleIntervalId, Is.EqualTo(entity1.FromScheduleIntervalId));
            Assert.That(entity2.ToScheduleIntervalId, Is.EqualTo(entity1.ToScheduleIntervalId));
            Assert.That(entity2.Multiplier, Is.EqualTo(entity1.Multiplier));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,From Schedule Interval,To Schedule Interval,Multiplier,Description" + Environment.NewLine;
            retVal += "1,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "2,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "3,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "4,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "5,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "6,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "7,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "8,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "9,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;
            retVal += "10,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,0,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,<<yyyy-MM-DDTHH:mm:ss.fff>>,10,2,123,anananan-anan-anan-anan-anananananan" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IScheduleIntervalMultiplierMatrix entity)
        {
            entity.Multiplier *= 100;
            entity.Description += "Updated";
        }

        [TestCase]
        public void Test_ValidateEntity()
        {
            IScheduleIntervalMultiplierMatrix scheduleIntervalMultiplierMatrix = CreateEntity(TheProcess!, 1);
            scheduleIntervalMultiplierMatrix.Description = String.Empty;

            String aggregateErrorMessage = "One or more errors occurred. (Description must be provided)";
            String validationErrorMessage = "Description must be provided";

            AggregateException actualException = Assert.Throws<AggregateException>(() =>
            {
                TheProcess!.ValidateEntity(scheduleIntervalMultiplierMatrix);
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(aggregateErrorMessage));

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException, Is.TypeOf<AggregateException>());

            ValidationException validationException = (ValidationException)actualException.InnerExceptions[0];
            Assert.That(validationException.Message, Is.EqualTo(validationErrorMessage));
        }

        [TestCase]
        public void Test_MakeListOfFromScheduleIntervals()
        {
            List<IScheduleInterval> scheduleIntervals =
            [
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>()
            ];

            scheduleIntervals[0].Id = new EntityId(0);
            scheduleIntervals[1].Id = new EntityId(1);
            scheduleIntervals[2].Id = new EntityId(2);
            scheduleIntervals[3].Id = new EntityId(3);
            scheduleIntervals[4].Id = new EntityId(4);

            ScheduleIntervalProcess!.Get(Arg.Any<List<EntityId>>()).Returns(scheduleIntervals);

            List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            scheduleIntervalMultiplierMatrices[0].FromScheduleIntervalId = new EntityId(0);
            scheduleIntervalMultiplierMatrices[1].FromScheduleIntervalId = new EntityId(1);
            scheduleIntervalMultiplierMatrices[2].FromScheduleIntervalId = new EntityId(2);
            scheduleIntervalMultiplierMatrices[3].FromScheduleIntervalId = new EntityId(3);
            scheduleIntervalMultiplierMatrices[4].FromScheduleIntervalId = new EntityId(4);

            List<IScheduleInterval> fromScheduleIntervalMultiplierMatrices = TheProcess!.MakeListOfFromSchedulerIntervals(scheduleIntervalMultiplierMatrices);
            Assert.That(fromScheduleIntervalMultiplierMatrices.Count, Is.EqualTo(5));
        }

        [TestCase]
        public void Test_MakeListOfToScheduleIntervals()
        {
            List<IScheduleInterval> scheduleIntervals =
            [
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>(),
                Substitute.For<IScheduleInterval>()
            ];

            scheduleIntervals[0].Id = new EntityId(0);
            scheduleIntervals[1].Id = new EntityId(1);
            scheduleIntervals[2].Id = new EntityId(2);
            scheduleIntervals[3].Id = new EntityId(3);
            scheduleIntervals[4].Id = new EntityId(4);

            ScheduleIntervalProcess!.Get(Arg.Any<List<EntityId>>()).Returns(scheduleIntervals);

            List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            scheduleIntervalMultiplierMatrices[0].FromScheduleIntervalId = new EntityId(0);
            scheduleIntervalMultiplierMatrices[1].FromScheduleIntervalId = new EntityId(1);
            scheduleIntervalMultiplierMatrices[2].FromScheduleIntervalId = new EntityId(2);
            scheduleIntervalMultiplierMatrices[3].FromScheduleIntervalId = new EntityId(3);
            scheduleIntervalMultiplierMatrices[4].FromScheduleIntervalId = new EntityId(4);

            List<IScheduleInterval> fromScheduleIntervalMultiplierMatrices = TheProcess!.MakeListOfToSchedulerIntervals(scheduleIntervalMultiplierMatrices);
            Assert.That(fromScheduleIntervalMultiplierMatrices.Count, Is.EqualTo(5));
        }

        [TestCase]
        public void Test_ApplyFilter_FromScheduleInterval()
        {
            IScheduleInterval fromScheduleInterval1 = Substitute.For<IScheduleInterval>();
            fromScheduleInterval1.Id = new EntityId(1);

            IScheduleInterval fromScheduleInterval2 = Substitute.For<IScheduleInterval>();
            fromScheduleInterval2.Id = new EntityId(2);

            const IScheduleInterval? toScheduleInterval = null;

            List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            scheduleIntervalMultiplierMatrices[0].Id = new EntityId(0);
            scheduleIntervalMultiplierMatrices[0].FromScheduleIntervalId = fromScheduleInterval1.Id;

            scheduleIntervalMultiplierMatrices[1].Id = new EntityId(1);
            scheduleIntervalMultiplierMatrices[1].FromScheduleIntervalId = fromScheduleInterval2.Id;

            scheduleIntervalMultiplierMatrices[2].Id = new EntityId(2);
            scheduleIntervalMultiplierMatrices[2].FromScheduleIntervalId = fromScheduleInterval1.Id;

            scheduleIntervalMultiplierMatrices[3].Id = new EntityId(3);
            scheduleIntervalMultiplierMatrices[3].FromScheduleIntervalId = fromScheduleInterval2.Id;

            scheduleIntervalMultiplierMatrices[4].Id = new EntityId(4);
            scheduleIntervalMultiplierMatrices[4].FromScheduleIntervalId = fromScheduleInterval1.Id;

            List<IScheduleIntervalMultiplierMatrix> filtered1 = TheProcess!.ApplyFilter(scheduleIntervalMultiplierMatrices, fromScheduleInterval1, toScheduleInterval);
            Assert.That(filtered1.Count, Is.EqualTo(3));

            List<IScheduleIntervalMultiplierMatrix> filtered2 = TheProcess!.ApplyFilter(scheduleIntervalMultiplierMatrices, fromScheduleInterval2, toScheduleInterval);
            Assert.That(filtered2.Count, Is.EqualTo(2));
        }

        [TestCase]
        public void Test_ApplyFilter_ToScheduleInterval()
        {
            IScheduleInterval toScheduleInterval1 = Substitute.For<IScheduleInterval>();
            toScheduleInterval1.Id = new EntityId(1);

            IScheduleInterval toScheduleInterval2 = Substitute.For<IScheduleInterval>();
            toScheduleInterval2.Id = new EntityId(2);

            const IScheduleInterval? fromScheduleInterval = null;

            List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices =
            [
                CreateEntity(TheProcess!, 1),
                CreateEntity(TheProcess!, 2),
                CreateEntity(TheProcess!, 3),
                CreateEntity(TheProcess!, 4),
                CreateEntity(TheProcess!, 5),
            ];

            scheduleIntervalMultiplierMatrices[0].Id = new EntityId(0);
            scheduleIntervalMultiplierMatrices[0].ToScheduleIntervalId = toScheduleInterval1.Id;

            scheduleIntervalMultiplierMatrices[1].Id = new EntityId(1);
            scheduleIntervalMultiplierMatrices[1].ToScheduleIntervalId = toScheduleInterval2.Id;

            scheduleIntervalMultiplierMatrices[2].Id = new EntityId(2);
            scheduleIntervalMultiplierMatrices[2].ToScheduleIntervalId = toScheduleInterval1.Id;

            scheduleIntervalMultiplierMatrices[3].Id = new EntityId(3);
            scheduleIntervalMultiplierMatrices[3].ToScheduleIntervalId = toScheduleInterval2.Id;

            scheduleIntervalMultiplierMatrices[4].Id = new EntityId(4);
            scheduleIntervalMultiplierMatrices[4].ToScheduleIntervalId = toScheduleInterval1.Id;

            List<IScheduleIntervalMultiplierMatrix> filtered1 = TheProcess!.ApplyFilter(scheduleIntervalMultiplierMatrices, fromScheduleInterval, toScheduleInterval1);
            Assert.That(filtered1.Count, Is.EqualTo(3));

            List<IScheduleIntervalMultiplierMatrix> filtered2 = TheProcess!.ApplyFilter(scheduleIntervalMultiplierMatrices, fromScheduleInterval, toScheduleInterval2);
            Assert.That(filtered2.Count, Is.EqualTo(2));
        }
    }
}
