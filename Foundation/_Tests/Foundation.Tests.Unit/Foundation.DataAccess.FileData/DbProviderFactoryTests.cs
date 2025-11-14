//-----------------------------------------------------------------------
// <copyright file="DbProviderFactoryTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Database.DataLogicProviders;
using Foundation.DataAccess.FileData;
using Foundation.Tests.Unit.BaseClasses;

using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace Foundation.Tests.Unit.Foundation.DataAccess.FileData
{
    /// <summary>
    /// DbProviderFactoryTests
    /// </summary>
    [TestFixture]
    public class DbProviderFactoryTests : UnitTestBase
    {
        private const String FileDataFactoryInvariantName = "Foundation.FileData.Client";
        private const String FileDataFactoryAssemblyQualifiedName = "Foundation.DataAccess.FileData.FileClientFactory, Foundation.DataAccess.FileData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        public override void TestInitialise()
        {
            base.TestInitialise();
            _ = new FoundationFileDataProvider();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_EnumerateProviders()
        {
            DataTable allFactories = DbProviderFactories.GetFactoryClasses();
            Debug.WriteLine("Name,Description,InvariantName,AssemblyQualifiedName");
            foreach (DataRow dr in allFactories.Rows)
            {
                Debug.WriteLine($"{dr["Name"]},{dr["Description"]},{dr["InvariantName"]},{dr["AssemblyQualifiedName"]}");
            }

            Assert.That(allFactories.Rows.Count, Is.GreaterThanOrEqualTo(0));
            DataRow fileDataClient = allFactories.Select($"[InvariantName] = '{DataProviders.FoundationFileClient[0]}'")[0];

            Assert.That(fileDataClient["Name"], Is.EqualTo(""));
            Assert.That(fileDataClient["Description"], Is.EqualTo(""));
            Assert.That(fileDataClient["InvariantName"], Is.EqualTo(FileDataFactoryInvariantName));
            Assert.That(fileDataClient["AssemblyQualifiedName"], Is.EqualTo(FileDataFactoryAssemblyQualifiedName));
        }

        [TestCase]
        public void Test_GetFileDataClientFactory()
        {
            DbProviderFactory fileClientFactory = DbProviderFactories.GetFactory(FileDataFactoryInvariantName);

            Assert.That(fileClientFactory, Is.Not.Null);
            Assert.That(fileClientFactory, Is.TypeOf<FileClientFactory>());

            DbConnection? connection = fileClientFactory.CreateConnection();
            Assert.That(connection, Is.Not.Null);
            Assert.That(connection, Is.TypeOf<FileConnection>());

            DbCommand? command = fileClientFactory.CreateCommand();
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.TypeOf<FileCommand>());

            DbDataAdapter? adapter = fileClientFactory.CreateDataAdapter();
            Assert.That(adapter, Is.Not.Null);
            Assert.That(adapter, Is.TypeOf<FileAdapter>());

            DbParameter? parameter = fileClientFactory.CreateParameter();
            Assert.That(parameter, Is.Not.Null);
            Assert.That(parameter, Is.TypeOf<FileParameter>());
        }

        [TestCase]
        public void Test_FileConnection()
        {
            DbProviderFactory fileClientFactory = DbProviderFactories.GetFactory(FileDataFactoryInvariantName);
            using (DbConnection? connection = fileClientFactory.CreateConnection())
            {
                connection!.ConnectionString = "";
            }
        }
    }
}
