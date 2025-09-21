//-----------------------------------------------------------------------
// <copyright file="StaticDataKeysTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Static Data Keys class
    /// </summary>
    [TestFixture]
    public class StaticDataKeysTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="StaticDataKeys"/>
        /// </summary>
        [TestCase]
        public void Test_AllMembers()
        {
            // This test exists to ensure all the class members are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(StaticDataKeys));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(StaticDataKeys.ApplicationDefinition)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(StaticDataKeys.Statuses)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(StaticDataKeys.UserProfiles)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter3)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter4)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Keys()
        {
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(StaticDataKeys));
            Int32 index = 0;

            index++; Assert.That(StaticDataKeys.ApplicationDefinition, Is.EqualTo(nameof(StaticDataKeys.ApplicationDefinition)));
            index++; Assert.That(StaticDataKeys.Statuses, Is.EqualTo(nameof(StaticDataKeys.Statuses)));
            index++; Assert.That(StaticDataKeys.UserProfiles, Is.EqualTo(nameof(StaticDataKeys.UserProfiles)));
            index++; Assert.That(StaticDataKeys.DropDownParameter1, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter1)));
            index++; Assert.That(StaticDataKeys.DropDownParameter2, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter2)));
            index++; Assert.That(StaticDataKeys.DropDownParameter3, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter3)));
            index++; Assert.That(StaticDataKeys.DropDownParameter4, Is.EqualTo(nameof(StaticDataKeys.DropDownParameter4)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }
    }
}
