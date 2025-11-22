//-----------------------------------------------------------------------
// <copyright file="SerialisationHelpers.CustomTypes.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Common.HelpersTests
{
    /// <summary>
    /// The Serialisation Helpers Tests class
    /// </summary>
    [TestFixture]
    public class SerialisationHelpersCustomTypes : UnitTestBase
    {
        private SerialiseTest CreateObjectForTesting()
        {
            SerialiseTest retVal = new SerialiseTest
            {
                StringList = ["One", "Two", "Three", "Four"],
                Int32List = [1, 2, 3, 4]
            };

            return retVal;
        }

        [TestCase]
        [DeploymentItem(@"\.ExpectedResults\Foundation.Common\HelpersTests\Test_Serialise_CustomType.txt")]
        public void Test_Serialise_CustomType()
        {
            SerialiseTest value = CreateObjectForTesting();

            String actual = SerialisationHelpers.Serialise(value);

            String sourceFile = @".ExpectedResults\Foundation.Common\HelpersTests\Test_Serialise_CustomType.txt";
            String expected = File.ReadAllText(sourceFile, Encoding.Default);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        [DeploymentItem(@"\.ExpectedResults\Foundation.Common\HelpersTests\Test_Serialise_CustomType.txt")]
        public void Test_Deserialise_CustomType()
        {
            SerialiseTest expected = CreateObjectForTesting();

            String sourceFile = @".ExpectedResults\Foundation.Common\HelpersTests\Test_Serialise_CustomType.txt";
            String fileContent = File.ReadAllText(sourceFile, Encoding.Default);

            SerialiseTest actual = SerialisationHelpers.Deserialise<SerialiseTest>(fileContent);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Null()
        {
            String parameterName = "value";
            String errorMessage = String.Format(StandardErrorMessages.ArgumentNullExpectedErrorMessage, parameterName);

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = SerialisationHelpers.Deserialise<SerialiseTest>("");
            });

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }
    }
}
