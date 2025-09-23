////-----------------------------------------------------------------------
//// <copyright file="TestApplicationConfiguration.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Linq;

//using NUnit.Framework;

//using Foundation.Common;
//using Foundation.Interfaces;
//using Foundation.Models;

//using Foundation.Tests.Unit.Support;

//using FEnums = Foundation.Interfaces;

//namespace Foundation.Tests.Unit.Foundation.Models
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [TestFixture]
//    public class TestApplicationConfiguration : UnitTestBase
//    {
//        /// <summary>
//        /// Test all the properties.
//        /// </summary>
//        [TestCase]
//        public void Test_AllProperties()
//        {
//            IApplicationConfiguration<String> applicationConfiguration = CoreInstance.IoC.Get<IApplicationConfiguration<String>>();

//            Assert.That(applicationConfiguration, Is.Not.Null);

//            Assert.That(applicationConfiguration.ConfigurationScope, Is.EqualTo(FEnums.ConfigurationScope.NotSet));
//            Assert.That(applicationConfiguration.ConfigurationScopeId, Is.EqualTo(new EntityId(0)));
//            Assert.That(applicationConfiguration.ApplicationId, Is.EqualTo(new AppId(0)));
//            Assert.That(applicationConfiguration.Key, Is.EqualTo(null));
//            Assert.That(applicationConfiguration.Value, Is.EqualTo(null));

//            AppId appId = new AppId(1);
//            EntityId entityId = new EntityId(1);
//            String value1 = Guid.NewGuid().ToString();
//            String value2 = Guid.NewGuid().ToString();

//            applicationConfiguration.ApplicationId = appId;
//            applicationConfiguration.ConfigurationScopeId = entityId;
//            applicationConfiguration.Key = value1;
//            applicationConfiguration.Value = value2;

//            Object applicationId = applicationConfiguration.GetPropertyValue(nameof(IApplicationConfiguration<String>.ApplicationId));
//            Object configurationScopeId = applicationConfiguration.GetPropertyValue(nameof(IApplicationConfiguration<String>.ConfigurationScopeId));
//            Object key = applicationConfiguration.GetPropertyValue(nameof(IApplicationConfiguration<String>.Key));
//            Object value = applicationConfiguration.GetPropertyValue(nameof(IApplicationConfiguration<String>.Value));

//            Assert.That(applicationId, Is.EqualTo(new AppId(1)));
//            Assert.That(configurationScopeId, Is.EqualTo(new EntityId(1)));
//            Assert.That(key, Is.EqualTo(value1));
//            Assert.That(value, Is.EqualTo(value2));
//        }

//        /// <summary>
//        /// Test the Clone method.
//        /// </summary>
//        [TestCase]
//        public void Test_Clone()
//        {
//            IApplicationConfiguration<String> applicationConfiguration = CoreInstance.IoC.Get<IApplicationConfiguration<String>>();
//            IApplicationConfiguration<String> cloned = (IApplicationConfiguration<String>)applicationConfiguration.Clone();

//            Assert.That(applicationConfiguration, Is.Not.Null);
//            Assert.That(cloned, Is.Not.Null);

//            Object obj = applicationConfiguration;
//            Boolean result1 = obj.Equals(cloned);
//            Assert.That(result1, Is.EqualTo(true));

//            Boolean result3 = applicationConfiguration.Equals(cloned);
//            Assert.That(result3, Is.EqualTo(true));

//            Int32 hashCode1 = obj.GetHashCode();
//            Int32 hashCode2 = cloned.GetHashCode();
//            Assert.That(hashCode1, Is.EqualTo(hashCode2));
//        }

//        /// <summary>
//        /// Test the Clone method.
//        /// </summary>
//        [TestCase]
//        public void Test_IEquatable()
//        {
//            IApplicationConfiguration applicationConfiguration1 = CoreInstance.IoC.Get<IApplicationConfiguration>();
//            IEquatable<ApplicationConfiguration> equatableAc = applicationConfiguration1 as IEquatable<ApplicationConfiguration<String>>;
//            IEquatable<IApplicationConfiguration<String>> equatableIac = applicationConfiguration1 as IEquatable<IApplicationConfiguration<String>>;

//            applicationConfiguration1.Key = Guid.NewGuid().ToString();
//            applicationConfiguration1.Value = Guid.NewGuid().ToString();

//            IApplicationConfiguration<String> applicationConfiguration2 = CoreInstance.IoC.Get<IApplicationConfiguration<String>>();
//            applicationConfiguration2.Key = Guid.NewGuid().ToString();
//            applicationConfiguration2.Value = Guid.NewGuid().ToString();

//            Boolean resultEqualsOperator = applicationConfiguration1 == applicationConfiguration2;
//            Assert.That(resultEqualsOperator, Is.EqualTo(false));

//            Boolean resultDoesNotEqualsOperator = applicationConfiguration1 != applicationConfiguration2;
//            Assert.That(resultDoesNotEqualsOperator, Is.EqualTo(true));

//            Boolean resultObjectEquals = applicationConfiguration1.Equals(applicationConfiguration2);
//            Assert.That(resultObjectEquals, Is.EqualTo(false));

//            Boolean resultIEquatableInterface1 = equatableIac.Equals(applicationConfiguration1);
//            Assert.That(resultIEquatableInterface1, Is.EqualTo(true));

//            Boolean resultIEquatableConcrete1 = equatableAc.Equals((ApplicationConfiguration<String>)applicationConfiguration1);
//            Assert.That(resultIEquatableConcrete1, Is.EqualTo(true));

//            Boolean resultIEquatableInterface2 = equatableIac.Equals(applicationConfiguration2);
//            Assert.That(resultIEquatableInterface2, Is.EqualTo(false));

//            Boolean resultIEquatableConcrete2 = equatableAc.Equals((ApplicationConfiguration<String>)applicationConfiguration2);
//            Assert.That(resultIEquatableConcrete2, Is.EqualTo(false));
//        }
//    }
//}
