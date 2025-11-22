//-----------------------------------------------------------------------
// <copyright file="RequeryTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.UtilsTests.RelayCommandTests
{
    [TestFixture]
    public class RequeryTests : UnitTestBase
    {
        [TestCase]
        public void Test_ValidEvaluator_TFunction()
        {
            Boolean functionCalled = false;

            RelayCommand<Object> relayCommand = new RelayCommand<Object>(_ => { }, () => true );
            relayCommand.CanExecuteChanged += (_, _) => { functionCalled = true; };

            relayCommand.RaiseCanExecuteChanged();
            relayCommand.CanExecute(null);
            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_ValidEvaluator_TFunction_TEvaluator()
        {
            Boolean functionCalled = false;

            RelayCommand<Object, Object> relayCommand = new RelayCommand<Object, Object>(_ => { }, _ => true);
            relayCommand.CanExecuteChanged += (_, _) => { functionCalled = true; };

            relayCommand.RaiseCanExecuteChanged();
            relayCommand.CanExecute(null);
            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_CanExecuteChangedEvent_1()
        {
            Boolean functionCalled = false;

            void CanExecuteChanged(Object? s, EventArgs e)
            {
                functionCalled = true;
            }

            RelayCommand<Object> relayCommand = new RelayCommand<Object>(_ => { }, () => true );
            relayCommand.CanExecuteChanged -= CanExecuteChanged;
            relayCommand.CanExecuteChanged += CanExecuteChanged;

            relayCommand.RaiseCanExecuteChanged();
            relayCommand.CanExecute(null);
            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_CanExecuteChangedEvent_2()
        {
            Boolean functionCalled = false;
            Boolean canExecute = false;

            void CanExecuteChanged(Object? s, EventArgs e)
            {
                functionCalled = true;
            }

            RelayCommand<Object, Object> relayCommand = new RelayCommand<Object, Object>(_ => { }, _ => canExecute);
            relayCommand.CanExecuteChanged -= CanExecuteChanged;
            relayCommand.CanExecuteChanged += CanExecuteChanged;

            canExecute = true;

            relayCommand.RaiseCanExecuteChanged();
            relayCommand.CanExecute(null);
            relayCommand.Execute(null);

            Assert.That(functionCalled, Is.EqualTo(false));
        }
    }
}
