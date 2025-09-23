//-----------------------------------------------------------------------
// <copyright file="CharacterCodesTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Character Codes Tests class
    /// </summary>
    [TestFixture]
    public class CharacterCodesTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="CharacterCodes"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(CharacterCodes);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Int32 index = 0;

            /*
             * Commonly used for file parsing
             */

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.CarriageReturn)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.DoubleQuote)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.FieldDelimiter)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.NewLine)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.SingleQuote)));

            /*
             * Commonly used for random generation
             */

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.AlphaUpperCaseOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.AlphaLowerCaseOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.NumericOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.NonAlphaChars)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.AlphaNumeric)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CharacterCodes.AllChars)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Keys()
        {
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(CharacterCodes));
            Int32 index = 0;

            index++; Assert.That(CharacterCodes.CarriageReturn, Is.EqualTo('\r'));
            index++; Assert.That(CharacterCodes.DoubleQuote, Is.EqualTo('"'));
            index++; Assert.That(CharacterCodes.FieldDelimiter, Is.EqualTo(','));
            index++; Assert.That(CharacterCodes.NewLine, Is.EqualTo('\n'));
            index++; Assert.That(CharacterCodes.SingleQuote, Is.EqualTo('\''));

            index++; Assert.That(CharacterCodes.AlphaUpperCaseOnly, Is.EqualTo("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            index++; Assert.That(CharacterCodes.AlphaLowerCaseOnly, Is.EqualTo("abcdefghijklmnopqrstuvwxyz"));
            index++; Assert.That(CharacterCodes.NumericOnly, Is.EqualTo("0123456789"));
            index++; Assert.That(CharacterCodes.NonAlphaChars, Is.EqualTo(@"!""£$%^&*() _-+={}[]#:@;'<>?,./|\"));
            index++; Assert.That(CharacterCodes.AlphaNumeric, Is.EqualTo("ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "0123456789"));
            index++; Assert.That(CharacterCodes.AllChars, Is.EqualTo("ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "0123456789" + @"!""£$%^&*() _-+={}[]#:@;'<>?,./|\"));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }
    }
}
