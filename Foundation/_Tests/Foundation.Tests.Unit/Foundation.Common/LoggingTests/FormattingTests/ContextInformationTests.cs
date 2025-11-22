//-----------------------------------------------------------------------
// <copyright file="ContextInformationTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests.FormattingTests
{
    /// <summary>
    /// The Context Information Tests
    /// </summary>
    [TestFixture]
    public class ContextInformationTests : UnitTestBase
    {
        const String Parameter1 = "parameter1 Value";
        const Int32 Parameter2 = 100;
        const Boolean Parameter3False = false;
        const Boolean Parameter3True = true;

        /// <summary>
        /// Tests the constructor default.
        /// </summary>
        [TestCase]
        public void TestConstructorDefault()
        {
            Object contextInformationObject = new ContextInformation();

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));
            Assert.That(contextInformationObject, Is.InstanceOf<ContextInformation>());
        }

        [TestCase]
        public void TestProperties()
        {
            ExecuteTestProperties("StringParameter", 132, false);
        }

        /// <summary>
        /// Tests to string override default no parameters.
        /// </summary>
        [TestCase]
        public void TestToStringOverrideDefaultNoParameters()
        {
            CheckTestToStringOverrideDefaultNoParameters();
        }

        /// <summary>
        /// Tests to string override default with parameters.
        /// </summary>
        [TestCase]
        public void TestToStringOverrideDefaultWithParameters()
        {
            Object parameter4 = new ContextInformationTests();
            ExecuteTestToStringOverrideDefaultWithParameters(Parameter1, Parameter2, Parameter3False, parameter4);
        }

        /// <summary>
        /// Tests to string override default with parameters no values.
        /// </summary>
        [TestCase]
        public void TestToStringOverrideDefaultWithParametersNoValues()
        {
            Object parameter4 = new ContextInformationTests();
            ExecuteTestToStringOverrideDefaultWithParametersNoValues(Parameter1, Parameter2, Parameter3False, parameter4);
        }

        /// <summary>
        /// Tests to string override0 no parameters.
        /// </summary>
        [TestCase]
        public void TestToStringOverride0NoParameters()
        {
            CheckTestToStringOverride0NoParameters();
        }

        /// <summary>
        /// Tests to string override0 with parameters.
        /// </summary>
        [TestCase]
        public void TestToStringOverride0WithParameters()
        {
            Object parameter4 = new ContextInformationTests();
            ExecuteTestToStringOverride0WithParameters(Parameter1, Parameter2, Parameter3False, parameter4);
        }

        /// <summary>
        /// Tests to string override0 with parameters no values.
        /// </summary>
        [TestCase]
        public void TestToStringOverride0WithParametersNoValues()
        {
            Object parameter4 = new ContextInformationTests();
            ExecuteTestToStringOverride0WithParametersNoValues(Parameter1, Parameter2, Parameter3False, parameter4);
        }

        /// <summary>
        /// Tests to string override1 no parameters.
        /// </summary>
        [TestCase]
        public void TestToStringOverride1NoParameters()
        {
            CheckTestToStringOverride1NoParameters();
        }

        /// <summary>
        /// Tests to string override1 with parameters.
        /// </summary>
        [TestCase]
        public void TestToStringOverride1WithParameters()
        {
            Object parameter4 = new ContextInformationTests();
            ExecuteTestToStringOverride1WithParameters(Parameter1, Parameter2, Parameter3False, parameter4);
        }

        /// <summary>
        /// Tests to string override1 with parameters no values.
        /// </summary>
        [TestCase]
        public void TestToStringOverride1WithParametersNoValues()
        {
            Object parameter4 = new ContextInformationTests();
            ExecuteTestToStringOverride1WithParametersNoValues(Parameter1, Parameter2, Parameter3False, parameter4);
        }

        [ExcludeFromCodeCoverage]
        private void ExecuteTestProperties(String parameter1, Int32 parameter2, Boolean parameter3)
        {
            CheckTestParameters();
        }

        private void CheckTestParameters()
        {
            String expectedClassName = this.GetType().Name;
            String expectedFileLineNumber = "134";
            String expectedFilename = "<<Output Folder>>ContextInformationTests.cs";
            String expectedMethodArguments = "String parameter1, Int32 parameter2, Boolean parameter3";
            String expectedMethodName = nameof(ExecuteTestProperties);
            String expectedNamespace = this.GetType().Namespace!;

            ContextInformation contextInformationObject = new ContextInformation();

            String actualClassName = contextInformationObject.ClassName;
            String actualFileLineNumber = contextInformationObject.FileLineNumber;
            String actualFilename = ReplaceFilePathWithConstant(contextInformationObject.FileName);
            String actualMethodArguments = contextInformationObject.MethodArguments;
            String actualMethodName = contextInformationObject.MethodName;
            String actualNamespace = contextInformationObject.Namespace;

            Assert.That(actualClassName, Is.EqualTo(expectedClassName));
            Assert.That(actualFileLineNumber, Is.EqualTo(expectedFileLineNumber));
            Assert.That(actualFilename, Is.EqualTo(expectedFilename));
            Assert.That(actualMethodArguments, Is.EqualTo(expectedMethodArguments));
            Assert.That(actualMethodName, Is.EqualTo(expectedMethodName));
            Assert.That(actualNamespace, Is.EqualTo(expectedNamespace));
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// ExecuteTestToStringOverrideDefaultWithParameters
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        private void CheckTestToStringOverrideDefaultWithParameters(params Object[] parameterValues)
        {
            ContextInformation contextInformationObject = new ContextInformation(parameterValues);

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString();
            String typeName = typeof(ContextInformationTests).ToString();
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(ExecuteTestToStringOverrideDefaultWithParameters)}";
            String expectedToString = $"{methodName}(String parameter1 = 'parameter1 Value', Int32 parameter2 = '100', Boolean parameter3 = 'False', Object parameter4 = '{typeName}')";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// Executes the test to string override0 with parameters no values.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">if set to <c>true</c> [parameter3].</param>
        /// <param name="parameter4">The parameter4.</param>
        private void ExecuteTestToStringOverride0WithParametersNoValues(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)
        {
            CheckTestToStringOverride0WithParametersNoValues();
        }

        /// <summary>
        /// Executes the test to string override0 with parameters.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">if set to <c>true</c> [parameter3].</param>
        /// <param name="parameter4">The parameter4.</param>
        private void ExecuteTestToStringOverride0WithParameters(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)
        {
            CheckTestToStringOverride0WithParameters(parameter1, parameter2, parameter3, parameter4);
        }

        /// <summary>
        /// Executes the test to string override1 with parameters.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">if set to <c>true</c> [parameter3].</param>
        /// <param name="parameter4">The parameter4.</param>
        private void ExecuteTestToStringOverride1WithParameters(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)
        {
            CheckTestToStringOverride1WithParameters(parameter1, parameter2, parameter3, parameter4);
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// ExecuteTestToStringOverride1WithParameters
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        private void CheckTestToStringOverride1WithParameters(params Object[] parameterValues)
        {
            ContextInformation contextInformationObject = new ContextInformation(parameterValues);

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString(1);
            String typeName = typeof(ContextInformationTests).ToString();
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(ExecuteTestToStringOverride1WithParameters)}";
            String expectedToString = $"{methodName}(String parameter1 = 'parameter1 Value', Int32 parameter2 = '100', Boolean parameter3 = 'False', Object parameter4 = '{typeName}')";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// TestToStringOverrideDefaultNoParameters
        /// </summary>
        private void CheckTestToStringOverrideDefaultNoParameters()
        {
            ContextInformation contextInformationObject = new ContextInformation();

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString();
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(TestToStringOverrideDefaultNoParameters)}";
            String expectedToString = $"{methodName}()";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// Executes the test to string override default with parameters.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">if set to <c>true</c> [parameter3].</param>
        /// <param name="parameter4">The parameter4.</param>
        private void ExecuteTestToStringOverrideDefaultWithParameters(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)
        {
            CheckTestToStringOverrideDefaultWithParameters(parameter1, parameter2, parameter3, parameter4);
        }

        /// <summary>
        /// Executes the test to string override default with parameters no values.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">if set to <c>true</c> [parameter3].</param>
        /// <param name="parameter4">The parameter4.</param>
        private void ExecuteTestToStringOverrideDefaultWithParametersNoValues(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)
        {
            CheckTestToStringOverrideDefaultWithParametersNoValues();
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// ExecuteTestToStringOverrideDefaultWithParametersNoValues
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        private void CheckTestToStringOverrideDefaultWithParametersNoValues(params Object[] parameterValues)
        {
            ContextInformation contextInformationObject = new ContextInformation(parameterValues);

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString();
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(ExecuteTestToStringOverrideDefaultWithParametersNoValues)}";
            String expectedToString = $"{methodName}(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// TestToStringOverride0NoParameters
        /// </summary>
        private void CheckTestToStringOverride0NoParameters()
        {
            ContextInformation contextInformationObject = new ContextInformation();

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString(0);
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(TestToStringOverride0NoParameters)}";
            String expectedToString = $"{methodName}()";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// ExecuteTestToStringOverride0WithParametersNoValues
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        private void CheckTestToStringOverride0WithParametersNoValues(params Object[] parameterValues)
        {
            ContextInformation contextInformationObject = new ContextInformation(parameterValues);

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString(0);
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(ExecuteTestToStringOverride0WithParametersNoValues)}";
            String expectedToString = $"{methodName}()";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// ExecuteTestToStringOverride0WithParameters
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        private void CheckTestToStringOverride0WithParameters(params Object[] parameterValues)
        {
            ContextInformation contextInformationObject = new ContextInformation(parameterValues);

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString(0);
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(ExecuteTestToStringOverride0WithParameters)}";
            String expectedToString = $"{methodName}()";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// TestToStringOverride1NoParameters
        /// </summary>
        private void CheckTestToStringOverride1NoParameters()
        {
            ContextInformation contextInformationObject = new ContextInformation();

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString(1);
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(TestToStringOverride1NoParameters)}";
            String expectedToString = $"{methodName}()";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// Executes the test to string override1 with parameters no values.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="parameter3">if set to <c>true</c> [parameter3].</param>
        /// <param name="parameter4">The parameter4.</param>
        private void ExecuteTestToStringOverride1WithParametersNoValues(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)
        {
            CheckTestToStringOverride1WithParametersNoValues();
        }

        /// <summary>
        /// ContextInformation will return the information about the calling method
        /// ExecuteTestToStringOverride1WithParametersNoValues
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        private void CheckTestToStringOverride1WithParametersNoValues(params Object[] parameterValues)
        {
            ContextInformation contextInformationObject = new ContextInformation(parameterValues);

            Assert.That(contextInformationObject, Is.Not.EqualTo(null));

            String actualToString = contextInformationObject.ToString(1);
            String methodName = $"{nameof(ContextInformationTests)}.{nameof(ExecuteTestToStringOverride1WithParametersNoValues)}";
            String expectedToString = $"{methodName}(String parameter1, Int32 parameter2, Boolean parameter3, Object parameter4)";

            Assert.That(actualToString, Is.EqualTo(expectedToString));
        }
    }
}
