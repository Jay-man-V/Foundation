//-----------------------------------------------------------------------
// <copyright file="ExecuteTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Input;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Common.UtilsTests.RelayCommandTests
{
    [TestFixture]
    public class ExecuteTests : UnitTestBase
    {
        [TestCase]
        public void Test_Execute_NoParameter_NullEvaluator()
        {
            Boolean functionCalled = false;
            ICommand relayCommand = RelayCommandFactory.New(() => { functionCalled = true; }, null!);

            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_Null_NoEvaluator()
        {
            Boolean functionCalled = false;

            String parameterName = "methodToExecute";
            String errorMessage = String.Format(StandardErrorMessages.ArgumentNullExpectedErrorMessage, parameterName);

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = RelayCommandFactory.New<Object>(null!);
            });

            Assert.That(functionCalled, Is.EqualTo(false));

            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Null_Execute_Null_Evaluator()
        {
            String parameterName = "methodToExecute";
            String errorMessage = String.Format(StandardErrorMessages.ArgumentNullExpectedErrorMessage, parameterName);

            // First test the constructor

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new RelayCommand<Object, Object>(null!, null!);
            });

            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));

            // Now test the factory method

            ArgumentNullException actualException2 = Assert.Throws<ArgumentNullException>(() =>
            {
                RelayCommandFactory.New<Object, Object>(null!, null!);
            });

            Assert.That(actualException2.ParamName, Is.EqualTo(parameterName));
            Assert.That(actualException2.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Execute_NoParameter_NoEvaluator()
        {
            Boolean functionCalled = false;
            ICommand relayCommand = RelayCommandFactory.New(() => { functionCalled = true; });

            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_NoParameter_Evaluator_True()
        {
            Boolean functionCalled = false;
            ICommand relayCommand = RelayCommandFactory.New(() => { functionCalled = true; }, RelayCommandFactory.AlwaysTrue);

            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_NoParameter_Evaluator_False()
        {
            Boolean functionCalled = false;
            ICommand relayCommand = RelayCommandFactory.New(() => { functionCalled = true; }, RelayCommandFactory.AlwaysFalse);

            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_Parameter_NullEvaluator()
        {
            Boolean functionCalled = false;
            Object parameterValue = new Object();
            ICommand relayCommand = RelayCommandFactory.New<Object>(p1 => { functionCalled = p1 == parameterValue; }, null!);

            relayCommand.Execute(parameterValue);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_Parameter_NoEvaluator()
        {
            Boolean functionCalled = false;
            Object parameterValue = new Object();
            ICommand relayCommand = RelayCommandFactory.New<Object>(p1 => { functionCalled = p1 == parameterValue; });

            relayCommand.Execute(parameterValue);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_Parameter_Evaluator_True()
        {
            Boolean functionCalled = false;
            Object parameterValue = new Object();
            ICommand relayCommand = RelayCommandFactory.New<Object>(p1 => { functionCalled = p1 == parameterValue; }, RelayCommandFactory.AlwaysTrue);

            relayCommand.Execute(parameterValue);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_Parameter_Evaluator_False()
        {
            Boolean functionCalled = false;
            Object parameterValue = new Object();
            ICommand relayCommand = RelayCommandFactory.New<Object>(p1 => { functionCalled = p1 == parameterValue; }, RelayCommandFactory.AlwaysFalse);

            relayCommand.Execute(parameterValue);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_Parameter_Parameter_Evaluator_True()
        {
            Boolean functionCalled = false;
            const MockFoundationModel? parameterValue = null;
            ICommand relayCommand = RelayCommandFactory.New<MockFoundationModel, Object>(p1 => { functionCalled = p1 == parameterValue; }, RelayCommandFactory.AlwaysTrue);

            relayCommand.Execute(parameterValue);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Execute_Parameter_Parameter_Evaluator_False()
        {
            Boolean functionCalled = false;
            const MockFoundationModel? parameterValue = null;
            ICommand relayCommand = RelayCommandFactory.New<MockFoundationModel, Object>(p1 => { functionCalled = p1 == parameterValue; }, RelayCommandFactory.AlwaysFalse);

            relayCommand.Execute(parameterValue);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_NoEvaluator_Parameter_NoEvaluator_NullParameter()
        {
            Boolean functionCalled = false;
            const MockFoundationModel? parameterValue = null;
            ICommand relayCommand = RelayCommandFactory.New<MockFoundationModel>(p1 => { functionCalled = p1 == parameterValue; });

            relayCommand.Execute(parameterValue);

            Assert.That(functionCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_NoEvaluatorWithParameter_ParameterTypeMismatch_String()
        {
            Boolean functionCalled = false;
            ICommand relayCommand = RelayCommandFactory.New<MockFoundationModel>(_ => { functionCalled = true; });

            String parameterName = "parameter";
            String typeName = typeof(MockFoundationModel).ToString();
            String expectedMessage = $"The supplied parameter is not of the correct type. Expected Type: {typeName}. Supplied parameter type: System.String (Parameter '{parameterName}')";

            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                relayCommand.Execute("String value");
            });

            Assert.That(functionCalled, Is.EqualTo(false));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            Assert.That(actualException.Message, Is.EqualTo(expectedMessage));
        }

        [TestCase]
        public void Test_WithEvaluatorWithParameter_ParameterTypeMismatch_String()
        {
            Boolean functionCalled = false;
            ICommand relayCommand = RelayCommandFactory.New<MockFoundationModel, Object>(_ => { functionCalled = true; }, RelayCommandFactory.AlwaysFalse);

            String parameterName = "parameter";
            String typeName = typeof(MockFoundationModel).ToString();
            String expectedMessage = $"The supplied parameter is not of the correct type. Expected Type: {typeName}. Supplied parameter type: System.String (Parameter '{parameterName}')";

            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                relayCommand.Execute("String value");
            });

            Assert.That(functionCalled, Is.EqualTo(false));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            Assert.That(actualException.Message, Is.EqualTo(expectedMessage));
        }

        [TestCase]
        public void Test_NoEvaluatorWithParameter_ParameterTypeMismatch_Object_Null()
        {
            Boolean functionCalled = false;
            //Object parameterValue = new Object();
            ICommand relayCommand = RelayCommandFactory.New<MockFoundationModel>(_ => { functionCalled = true; });

            const RandomObject? randomObject = null;
            relayCommand.Execute(randomObject);

            Assert.That(functionCalled, Is.EqualTo(true));
        }
    }
}
