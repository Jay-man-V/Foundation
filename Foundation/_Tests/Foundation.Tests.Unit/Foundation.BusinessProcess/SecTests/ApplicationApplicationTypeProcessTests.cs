//-----------------------------------------------------------------------
// <copyright file="ApplicationApplicationTypeProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FModels = Foundation.Models.Sec;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for ApplicationApplicationTypeProcessTests
    /// </summary>
    [TestFixture]
    public class ApplicationApplicationTypeProcessTests : CommonBusinessProcessTests<IApplicationApplicationType, IApplicationApplicationTypeProcess, IApplicationApplicationTypeRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 9;
        protected override String ExpectedScreenTitle => "Application/Application Types";
        protected override String ExpectedStatusBarText => "Number of Application/Application Types:";

        protected override IApplicationApplicationTypeRepository CreateRepository()
        {
            IApplicationApplicationTypeRepository retVal = Substitute.For<IApplicationApplicationTypeRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IApplicationApplicationTypeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            IApplicationTypeProcess applicationTypeProcess = Substitute.For<IApplicationTypeProcess>();

            SetProperties(applicationProcess);
            SetProperties(applicationTypeProcess);

            IApplicationApplicationTypeProcess process = new ApplicationApplicationTypeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!, applicationProcess, applicationTypeProcess);

            return process;
        }

        protected override IApplicationApplicationType CreateBlankEntity(Int32 entityId)
        {
            IApplicationApplicationType retVal = new FModels.ApplicationApplicationType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationApplicationType CreateEntity(IApplicationApplicationTypeProcess process, Int32 entityId)
        {
            IApplicationApplicationType retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.ApplicationTypeId = new EntityId(1);

            return retVal;
        }

        protected override void CheckBlankEntry(IApplicationApplicationType entity)
        {
            Assert.That(entity.ApplicationId, Is.EqualTo(new AppId(0)));
            Assert.That(entity.ApplicationTypeId, Is.EqualTo(new EntityId(0)));
        }

        protected override void CheckAllEntry(IApplicationApplicationType entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        protected override void CheckNoneEntry(IApplicationApplicationType entity)
        {
            Assert.Fail($"{LocationUtils.GetFunctionName()} should not be called as it is not implemented for the Business Process");
        }

        [TestCase]
        public override void Test_GetAllEntry()
        {
            String paramName = nameof(IApplicationApplicationTypeProcess.ComboBoxDisplayMember);
            String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheProcess!.GetAllEntry();
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public override void Test_GetNoneEntry()
        {
            String paramName = nameof(IApplicationApplicationTypeProcess.ComboBoxDisplayMember);
            String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, paramName, TheProcess!.GetType(), paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheProcess!.GetNoneEntry();
            });

            Assert.That(actualException, Is.Not.Null);
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        protected override void CompareEntityProperties(IApplicationApplicationType entity1, IApplicationApplicationType entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.ApplicationTypeId, Is.EqualTo(entity1.ApplicationTypeId));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Application,Type" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IApplicationApplicationType entity)
        {
            entity.ApplicationId = new AppId(2);
            entity.ApplicationTypeId = new EntityId(2);
        }
    }
}
