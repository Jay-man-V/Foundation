//-----------------------------------------------------------------------
// <copyright file="SharedVariablesTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Core;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Core
{
    /// <summary>
    /// The Shared Variables Tests
    /// </summary>
    public class SharedVariablesTests // Do not inherit from UnitTestBase
    {
        private ISharedVariables? SharedVariables { get; set; }

        [SetUp]
        public void Setup()
        {
            SharedVariables = new SharedVariables();
        }

        [TearDown]
        public void Teardown()
        {
            SharedVariables = null;
        }

        [TestCase]
        public void Test_Get_NonExisting()
        {
            String key = Guid.NewGuid().ToString();
            Object? retrievedValue = SharedVariables!.Get<Object>(key);

            Assert.That(retrievedValue, Is.EqualTo(null));
        }

        private void TestFunction<T>(String key, T valueToAdd1, T valueToAdd2)
        {
            SharedVariables!.Set(key, valueToAdd1);
            T? retrievedValue1 = SharedVariables.Get<T>(key);
            Assert.That(retrievedValue1, Is.EqualTo(valueToAdd1));

            SharedVariables.Set(key, valueToAdd2);
            T? retrievedValue2 = SharedVariables.Get<T>(key);
            Assert.That(retrievedValue2, Is.EqualTo(valueToAdd2));

            Assert.That(retrievedValue2, Is.Not.EqualTo(retrievedValue1));
        }

        [TestCase]
        public void Test_Boolean()
        {
            String key = LocationUtils.GetFunctionName();

            Boolean valueToAdd1 = false;
            Boolean valueToAdd2 = true;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_TimeSpan()
        {
            String key = LocationUtils.GetFunctionName();

            TimeSpan valueToAdd1 = new TimeSpan(00, 00, 00);
            TimeSpan valueToAdd2 = new TimeSpan(23, 59, 59);

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_DateTime()
        {
            String key = LocationUtils.GetFunctionName();

            DateTime valueToAdd1 = new DateTime(2025, 01, 01, 00, 00, 00);
            DateTime valueToAdd2 = new DateTime(2025, 12, 31, 23, 59, 59);

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Guid()
        {
            String key = LocationUtils.GetFunctionName();

            Guid valueToAdd1 = Guid.NewGuid();
            Guid valueToAdd2 = Guid.NewGuid();

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Char()
        {
            String key = LocationUtils.GetFunctionName();

            Char valueToAdd1 = 'A';
            Char valueToAdd2 = 'Z';

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_String()
        {
            String key = LocationUtils.GetFunctionName();

            String valueToAdd1 = Guid.NewGuid().ToString();
            String valueToAdd2 = Guid.NewGuid().ToString();

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Int16()
        {
            String key = LocationUtils.GetFunctionName();

            Int16 valueToAdd1 = Int16.MinValue;
            Int16 valueToAdd2 = Int16.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_UInt16()
        {
            String key = LocationUtils.GetFunctionName();

            UInt16 valueToAdd1 = UInt16.MinValue;
            UInt16 valueToAdd2 = UInt16.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Int32()
        {
            String key = LocationUtils.GetFunctionName();

            Int32 valueToAdd1 = Int32.MinValue;
            Int32 valueToAdd2 = Int32.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_UInt32()
        {
            String key = LocationUtils.GetFunctionName();

            UInt32 valueToAdd1 = UInt32.MinValue;
            UInt32 valueToAdd2 = UInt32.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Int64()
        {
            String key = LocationUtils.GetFunctionName();

            Int64 valueToAdd1 = Int64.MinValue;
            Int64 valueToAdd2 = Int64.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_UInt64()
        {
            String key = LocationUtils.GetFunctionName();

            UInt64 valueToAdd1 = UInt64.MinValue;
            UInt64 valueToAdd2 = UInt64.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Int128()
        {
            String key = LocationUtils.GetFunctionName();

            Int128 valueToAdd1 = Int128.MinValue;
            Int128 valueToAdd2 = Int128.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_UInt128()
        {
            String key = LocationUtils.GetFunctionName();

            UInt128 valueToAdd1 = UInt128.MinValue;
            UInt128 valueToAdd2 = UInt128.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Decimal()
        {
            String key = LocationUtils.GetFunctionName();

            Decimal valueToAdd1 = Decimal.MinValue;
            Decimal valueToAdd2 = Decimal.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Double()
        {
            String key = LocationUtils.GetFunctionName();

            Double valueToAdd1 = Double.MinValue;
            Double valueToAdd2 = Double.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Single()
        {
            String key = LocationUtils.GetFunctionName();

            Single valueToAdd1 = Single.MinValue;
            Single valueToAdd2 = Single.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_Byte()
        {
            String key = LocationUtils.GetFunctionName();

            Byte valueToAdd1 = Byte.MinValue;
            Byte valueToAdd2 = Byte.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_SByte()
        {
            String key = LocationUtils.GetFunctionName();

            SByte valueToAdd1 = SByte.MinValue;
            SByte valueToAdd2 = SByte.MaxValue;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_IntPtr()
        {
            String key = LocationUtils.GetFunctionName();

            IntPtr valueToAdd1 = (IntPtr)123456789L;
            IntPtr valueToAdd2 = (IntPtr)987654321L;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }

        [TestCase]
        public void Test_UIntPtr()
        {
            String key = LocationUtils.GetFunctionName();

            UIntPtr valueToAdd1 = (UIntPtr)123456789L;
            UIntPtr valueToAdd2 = (UIntPtr)987654321L;

            TestFunction(key, valueToAdd1, valueToAdd2);
        }
    }
}