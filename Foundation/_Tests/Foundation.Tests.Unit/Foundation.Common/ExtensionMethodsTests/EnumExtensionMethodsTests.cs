//-----------------------------------------------------------------------
// <copyright file="EnumExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Enum Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class EnumExtensionMethodsTests : UnitTestBase
    {
        private enum EnumForTesting
        {
            [DefaultValue("EnumOne DefaultValue")]
            [Description("Enum One Description")]
            [Display(Order = 1, Name = "Enum One Name")]
            [DisplayFormat(DataFormatString = "A1B1C1")]
            [Index(1)]
            [Id(1)]
            Enum1,

            [DefaultValue("EnumTwo DefaultValue")]
            [Description("Enum Two Description")]
            [Display(Order = 2, Name = "Enum Two Name")]
            [DisplayFormat(DataFormatString = "A2B2C2")]
            [Index(2)]
            [Id(2)]
            Enum2,

            Enum3,
        }

        [TestCase]
        public void Test_GetDefaultValue()
        {
            Assert.That(EnumForTesting.Enum1.DefaultValue(), Is.EqualTo("EnumOne DefaultValue"));
            Assert.That(EnumForTesting.Enum2.DefaultValue(), Is.EqualTo("EnumTwo DefaultValue"));
            Assert.That(EnumForTesting.Enum3.DefaultValue(), Is.EqualTo(null));
            Assert.That(EnumForTesting.Enum1.DefaultValue("ABC"), Is.EqualTo("EnumOne DefaultValue"));
            Assert.That(EnumForTesting.Enum2.DefaultValue("DEF"), Is.EqualTo("EnumTwo DefaultValue"));
            Assert.That(EnumForTesting.Enum3.DefaultValue("GHI"), Is.EqualTo("GHI"));
        }

        [TestCase]
        public void Test_GetDisplayFormat()
        {
            Assert.That(EnumForTesting.Enum1.DisplayFormat(), Is.EqualTo("A1B1C1"));
            Assert.That(EnumForTesting.Enum2.DisplayFormat(), Is.EqualTo("A2B2C2"));
            Assert.That(EnumForTesting.Enum3.DisplayFormat(), Is.EqualTo(String.Empty));
            Assert.That(EnumForTesting.Enum1.DisplayFormat("ABC"), Is.EqualTo("A1B1C1"));
            Assert.That(EnumForTesting.Enum2.DisplayFormat("DEF"), Is.EqualTo("A2B2C2"));
            Assert.That(EnumForTesting.Enum3.DisplayFormat("GHI"), Is.EqualTo("GHI"));
        }

        [TestCase]
        public void Test_GetDisplayOrder()
        {
            Assert.That(EnumForTesting.Enum1.DisplayOrder(), Is.EqualTo(1));
            Assert.That(EnumForTesting.Enum2.DisplayOrder(), Is.EqualTo(2));
            Assert.That(EnumForTesting.Enum3.DisplayOrder(), Is.EqualTo(0));
            Assert.That(EnumForTesting.Enum1.DisplayOrder(4), Is.EqualTo(1));
            Assert.That(EnumForTesting.Enum2.DisplayOrder(5), Is.EqualTo(2));
            Assert.That(EnumForTesting.Enum3.DisplayOrder(6), Is.EqualTo(6));
        }

        [TestCase]
        public void Test_GetDisplayName()
        {
            Assert.That(EnumForTesting.Enum1.DisplayName(), Is.EqualTo("Enum One Name"));
            Assert.That(EnumForTesting.Enum2.DisplayName(), Is.EqualTo("Enum Two Name"));
            Assert.That(EnumForTesting.Enum3.DisplayName(), Is.EqualTo("Enum3"));
            Assert.That(EnumForTesting.Enum1.DisplayName("4"), Is.EqualTo("Enum One Name"));
            Assert.That(EnumForTesting.Enum2.DisplayName("5"), Is.EqualTo("Enum Two Name"));
            Assert.That(EnumForTesting.Enum3.DisplayName("6"), Is.EqualTo("6"));
        }

        [TestCase]
        public void Test_GetDescription()
        {
            Assert.That(EnumForTesting.Enum1.Description(), Is.EqualTo("Enum One Description"));
            Assert.That(EnumForTesting.Enum2.Description(), Is.EqualTo("Enum Two Description"));
            Assert.That(EnumForTesting.Enum3.Description(), Is.EqualTo("Enum3"));
            Assert.That(EnumForTesting.Enum1.Description("4"), Is.EqualTo("Enum One Description"));
            Assert.That(EnumForTesting.Enum2.Description("5"), Is.EqualTo("Enum Two Description"));
            Assert.That(EnumForTesting.Enum3.Description("6"), Is.EqualTo("6"));
        }

        [TestCase]
        public void Test_GetIndex()
        {
            Assert.That(EnumForTesting.Enum1.Index(), Is.EqualTo(1));
            Assert.That(EnumForTesting.Enum2.Index(), Is.EqualTo(2));
            Assert.That(EnumForTesting.Enum3.Index(), Is.EqualTo(0));
            Assert.That(EnumForTesting.Enum1.Index(4), Is.EqualTo(1));
            Assert.That(EnumForTesting.Enum2.Index(5), Is.EqualTo(2));
            Assert.That(EnumForTesting.Enum3.Index(6), Is.EqualTo(6));
        }

        [TestCase]
        public void Test_GetId()
        {
            Assert.That(EnumForTesting.Enum1.Index(), Is.EqualTo(1));
            Assert.That(EnumForTesting.Enum2.Index(), Is.EqualTo(2));
            Assert.That(EnumForTesting.Enum3.Index(), Is.EqualTo(0));
            Assert.That(EnumForTesting.Enum1.Index(4), Is.EqualTo(1));
            Assert.That(EnumForTesting.Enum2.Index(5), Is.EqualTo(2));
            Assert.That(EnumForTesting.Enum3.Index(6), Is.EqualTo(6));
        }
    }
}
