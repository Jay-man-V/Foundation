//-----------------------------------------------------------------------
// <copyright file="CreateParameterTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database
{
    /// <summary>
    /// Create Parameter Tests
    /// </summary>
    /// <see cref="UnitTestBase" />
    [TestFixture]
    public class CreateParameterTests : UnitTestBase
    {
        private IMockFoundationModelRepository? TheRepository { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ICore core = Substitute.For<ICore>();

            IUnitTestingDatabaseProvider databaseProvider = new UnitTestingDatabaseProvider();

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Microsoft Sql Server Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("System.Data.SqlClient");

            TheRepository = new MockFoundationModelRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, databaseProvider, DateTimeService);
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_String_Valid_1()
        {
            String parameterName = LocationUtils.GetFunctionName();
            String parameterValue = "parameter Value";
            String useThisValueForNull = String.Empty;
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_String_Valid_2()
        {
            String parameterName = LocationUtils.GetFunctionName();
            String parameterValue = "parameter Value";
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_String_Empty_1()
        {
            String parameterName = LocationUtils.GetFunctionName();
            String parameterValue = String.Empty;
            String useThisValueForNull = String.Empty;
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_String_Empty_2()
        {
            String parameterName = LocationUtils.GetFunctionName();
            String parameterValue = String.Empty;
            DbType dbType = DbType.Object;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_String_Null_1()
        {
            String parameterName = LocationUtils.GetFunctionName();
            const String? parameterValue = null;
            String useThisValueForNull = String.Empty;
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_String_Null_2()
        {
            String parameterName = LocationUtils.GetFunctionName();
            const String? parameterValue = null;
            DbType dbType = DbType.Object;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Boolean_True_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            const Boolean parameterValue = true;
            DbType dbType = DbType.Boolean;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Boolean_False_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            const Boolean parameterValue = false;
            DbType dbType = DbType.Boolean;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Boolean_Empty()
        {
            // Boolean types cannot be empty, therefore there is no test
        }

        [TestCase]
        public void Test_Boolean_Null()
        {
            // Boolean types cannot be null, therefore there is no test
        }

        [TestCase]
        public void Test_Int16_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int16 parameterValue = 123;
            Int16 useThisValueForNull = -1;
            DbType dbType = DbType.Int16;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Int16_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int16 parameterValue = -1;
            Int16 useThisValueForNull = -1;
            DbType dbType = DbType.Int16;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Int32_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int32 parameterValue = 123;
            Int32 useThisValueForNull = -1;
            DbType dbType = DbType.Int32;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Int32_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int32 parameterValue = -1;
            Int32 useThisValueForNull = -1;
            DbType dbType = DbType.Int32;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Int64_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 parameterValue = 123;
            Int64 useThisValueForNull = -1;
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Int64_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 parameterValue = -1;
            Int64 useThisValueForNull = -1;
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Decimal_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Decimal parameterValue = 123.456m;
            Decimal useThisValueForNull = -1m;
            DbType dbType = DbType.Decimal;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Decimal_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Decimal parameterValue = -1m;
            Decimal useThisValueForNull = -1m;
            DbType dbType = DbType.Decimal;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Single_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Single parameterValue = 123.456f;
            Single useThisValueForNull = -1f;
            DbType dbType = DbType.Single;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Single_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Single parameterValue = -1f;
            Single useThisValueForNull = -1f;
            DbType dbType = DbType.Single;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Byte_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Byte parameterValue = 123;
            Byte useThisValueForNull = 0;
            DbType dbType = DbType.Byte;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Byte_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Byte parameterValue = 0;
            Byte useThisValueForNull = 0;
            DbType dbType = DbType.Byte;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_ByteArray_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Byte[] parameterValue = [1, 2, 3, 4, 5];
            Byte[] useThisValueForNull = [0];
            DbType dbType = DbType.Binary;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_ByteArray_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            const Byte[]? parameterValue = null;
            Byte[] useThisValueForNull = [0];
            DbType dbType = DbType.Binary;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_DateTime_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            DateTime parameterValue = new DateTime(2020, 10, 16, 22, 0, 0);
            DateTime useThisValueForNull = DateTime.MinValue;
            DbType dbType = DbType.DateTime;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_DateTime_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            DateTime parameterValue = DateTime.MinValue;
            DateTime useThisValueForNull = DateTime.MinValue;
            DbType dbType = DbType.DateTime;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_TimeSpan_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            TimeSpan parameterValue = new TimeSpan(22, 10, 10);
            TimeSpan useThisValueForNull = TimeSpan.MinValue;
            DbType dbType = DbType.Time;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_TimeSpan_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            TimeSpan parameterValue = TimeSpan.MinValue;
            TimeSpan useThisValueForNull = TimeSpan.MinValue;
            DbType dbType = DbType.Time;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\32BitColour_16x16.bmp", @".Support\SampleDocuments\")]
        public void Test_Image_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Image parameterValue = LoadImage();
            DbType dbType = DbType.Binary;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Byte[] byteArray = parameterValue.ToByteArray();

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That((Byte[])dataParameter.Value!, Is.EquivalentTo(byteArray));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Image_Valid_With_ValueForNull()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Image parameterValue = MakeBitmap(10, 10);
            Image useThisValueForNull = new Bitmap(1, 1);
            DbType dbType = DbType.Binary;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Byte[] byteArray = parameterValue.ToByteArray();

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That((Byte[])dataParameter.Value!, Is.EquivalentTo(byteArray));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Image_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Image parameterValue = MakeBitmap(1, 1);
            Image useThisValueForNull = new Bitmap(1, 1);
            DbType dbType = DbType.Binary;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Bitmap_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Image parameterValue = MakeBitmap(10, 10);
            Bitmap useThisValueForNull = new Bitmap(1, 1);
            DbType dbType = DbType.Binary;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Byte[] byteArray = parameterValue.ToByteArray();

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That((Byte[])dataParameter.Value!, Is.EquivalentTo(byteArray));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Bitmap_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Image parameterValue = MakeBitmap(1, 1);
            Bitmap useThisValueForNull = new Bitmap(1, 1);
            DbType dbType = DbType.Binary;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_EntityId_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 value = 456789;
            EntityId parameterValue = new EntityId(value);
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue.TheEntityId));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_EntityId_Null()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 value = 0;
            EntityId parameterValue = new EntityId(value);
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_EntityId_NotSet()
        {
            String parameterName = LocationUtils.GetFunctionName();
            EntityId parameterValue = new EntityId();
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_AppId_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 value = 456789;
            AppId parameterValue = new AppId(value);
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue.ToInteger()));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_AppId_Null()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 value = 0;
            AppId parameterValue = new AppId(value);
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_AppId_NotSet()
        {
            String parameterName = LocationUtils.GetFunctionName();
            AppId parameterValue = new AppId();
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_LogId_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 value = 456789;
            LogId parameterValue = new LogId(value);
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue.TheLogId));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_LogId_Null()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Int64 value = 0;
            LogId parameterValue = new LogId(value);
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_LogId_NotSet()
        {
            String parameterName = LocationUtils.GetFunctionName();
            LogId parameterValue = new LogId();
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase(EntityStatus.Incomplete)]
        [TestCase(EntityStatus.Active)]
        [TestCase(EntityStatus.Approved)]
        [TestCase(EntityStatus.PendingApproval)]
        [TestCase(EntityStatus.Incomplete)]
        public void Test_EntityStatus_Valid(EntityStatus entityStatus)
        {
            String parameterName = LocationUtils.GetFunctionName();
            EntityStatus parameterValue = entityStatus;
            DbType dbType = DbType.Int32;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo((Int32)parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_EntityStatus_Empty()
        {
            // EntityStatus types cannot be empty, therefore there is no test
        }

        [TestCase]
        public void Test_EntityStatus_Null()
        {
            // EntityStatus types cannot be null, therefore there is no test
        }

        [TestCase(LogSeverity.NotSet)]
        [TestCase(LogSeverity.Trace)]
        [TestCase(LogSeverity.Information)]
        [TestCase(LogSeverity.Success)]
        [TestCase(LogSeverity.Audit)]
        [TestCase(LogSeverity.Warning)]
        [TestCase(LogSeverity.Error)]
        public void Test_LogSeverity_Valid(LogSeverity logSeverity)
        {
            String parameterName = LocationUtils.GetFunctionName();
            LogSeverity parameterValue = logSeverity;
            DbType dbType = DbType.Int32;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue.Id()));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_LogSeverity_Empty()
        {
            // LogSeverity types cannot be empty, therefore there is no test
        }

        [TestCase]
        public void Test_LogSeverity_Null()
        {
            // LogSeverity types cannot be null, therefore there is no test
        }

        [TestCase]
        public void Test_EmailAddress_Valid_1()
        {
            String parameterName = LocationUtils.GetFunctionName();
            EmailAddress parameterValue = new EmailAddress("Test@Domain.name");
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_EmailAddress_Valid_2()
        {
            String parameterName = LocationUtils.GetFunctionName();
            EmailAddress? parameterValue = new EmailAddress("Test@Domain.name");
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_EmailAddress_Null()
        {
            String parameterName = LocationUtils.GetFunctionName();
            EmailAddress? parameterValue = null;
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_EmailAddress_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            EmailAddress parameterValue = new EmailAddress();
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Entity_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            IFoundationModel parameterValue = new MockFoundationModel();
            MockFoundationModel mockFoundationModel = (MockFoundationModel)parameterValue;
            mockFoundationModel.Id = new EntityId(1234);
            DbType dbType = DbType.Int64;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue.Id.TheEntityId));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Entity_Null()
        {
            String parameterName = LocationUtils.GetFunctionName();
            const IFoundationModel? parameterValue = null;
            DbType dbType = DbType.Int32;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Object_Valid()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Object parameterValue = "parameter Value";
            const Object? useThisValueForNull = null;
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(parameterValue));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Object_Empty()
        {
            String parameterName = LocationUtils.GetFunctionName();
            Object parameterValue = String.Empty;
            Object useThisValueForNull = String.Empty;
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        [TestCase]
        public void Test_Object_Null()
        {
            String parameterName = LocationUtils.GetFunctionName();
            const Object? parameterValue = null;
            Object useThisValueForNull = String.Empty;
            DbType dbType = DbType.String;
            IDataParameter dataParameter = TheRepository!.FoundationDataAccess.CreateParameter(parameterName, parameterValue, useThisValueForNull);

            Assert.That(dataParameter.ParameterName, Is.EqualTo(parameterName));
            Assert.That(dataParameter.Value, Is.EqualTo(DBNull.Value));
            Assert.That(dataParameter.DbType, Is.EqualTo(dbType));
        }

        private Image LoadImage()
        {
            Image retVal = Image.FromFile(@".Support\SampleDocuments\32BitColour_16x16.bmp");

            return retVal;
        }

        private Image MakeBitmap(Int32 width, Int32 height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.FillRectangle(Brushes.Transparent, 0, 0, width, height);
            }

            MemoryStream ms = new MemoryStream();

            bmp.Save(ms, ImageFormat.Bmp);

            Image retVal = Bitmap.FromStream(ms);

            return retVal;
        }
    }
}
