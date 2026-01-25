//-----------------------------------------------------------------------
// <copyright file="IoCTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.System.BaseClasses;

namespace Foundation.Tests.System.Foundation.Core
{
    /// <summary>
    /// System Tests for CalendarService
    /// </summary>
    [TestFixture]
    public class IoCTests : SystemTestBase
    {
        [Test]
        public void Test_InheritedInterfaceReturnsMultipleObjects()
        {
            IEnumerable<IInjectionIdentifier> services = CoreInstance.IoC.GetAll<IInjectionIdentifier>();

            Assert.That(services.Count(), Is.GreaterThanOrEqualTo(2));
        }

        [Test]
        public void Test_IInjectionIdentifier()
        {
            ICrossSiteScriptingIdentifier service1 = CoreInstance.IoC.Get<ICrossSiteScriptingIdentifier>();
            Assert.That(service1, Is.Not.EqualTo(null));

            ISqlInjectionIdentifier service2 = CoreInstance.IoC.Get<ISqlInjectionIdentifier>();
            Assert.That(service2, Is.Not.EqualTo(null));

            IEnumerable<IInjectionIdentifier> services = CoreInstance.IoC.GetAll<IInjectionIdentifier>();
            Assert.That(services.Count(), Is.GreaterThanOrEqualTo(2));
        }
    }
}
