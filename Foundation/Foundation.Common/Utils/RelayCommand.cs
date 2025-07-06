//-----------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Windows.Input;

namespace Foundation.Common
{
    /// <summary>
    /// Relay command
    /// </summary>
    /// <typeparam name="TFunction">The type of the function.</typeparam>
    /// <seealso cref="ICommand" />
    [DebuggerStepThrough]
    public sealed class RelayCommand<TFunction> : ICommand
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RelayCommand{TFunction}"/> class.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        public RelayCommand(Action<TFunction> methodToExecute) : this(methodToExecute, default) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="RelayCommand{TFunction}"/> class.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="canExecuteEvaluator">The can execute evaluator.</param>
        /// <exception cref="System.ArgumentNullException">methodToExecute</exception>
        public RelayCommand(Action<TFunction> methodToExecute, Func<Boolean> canExecuteEvaluator)
        {
            MethodToExecute = methodToExecute ?? throw new ArgumentNullException(nameof(methodToExecute));
            CanExecuteEvaluator = canExecuteEvaluator;
        }

        /// <summary>
        /// Gets the method to execute.
        /// </summary>
        /// <value>
        /// The method to execute.
        /// </value>
        private Action<TFunction> MethodToExecute { get; }

        /// <summary>
        /// Gets the can execute evaluator.
        /// </summary>
        /// <value>
        /// The can execute evaluator.
        /// </value>
        private Func<Boolean> CanExecuteEvaluator { get; }

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { if (CanExecuteEvaluator.IsNotNull()) { CommandManager.RequerySuggested += value; } }
            remove { if (CanExecuteEvaluator.IsNotNull()) { CommandManager.RequerySuggested -= value; } }
        }

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <returns>
        ///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
        /// </returns>
        public Boolean CanExecute(Object? parameter)
        {
            Boolean retVal = true;

            if (CanExecuteEvaluator.IsNotNull())
            {
                retVal = CanExecuteEvaluator();
            }

            return retVal;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <exception cref="ArgumentException">parameter</exception>
        public void Execute(Object? parameter)
        {
            if (MethodToExecute.IsNotNull())
            {
                if (parameter.IsNotNull() &&
                    !(parameter is TFunction))
                {
                    String message = $"The supplied parameter is not of the correct type. Expected Type: {typeof(TFunction)}. Supplied parameter type: {parameter.GetType()}";
                    throw new ArgumentException(message, nameof(parameter));
                }

                MethodToExecute.Invoke((TFunction)parameter);
            }
        }
    }

    /// <summary>
    /// Relay Command
    /// </summary>
    /// <typeparam name="TFunction">The type of the function.</typeparam>
    /// <typeparam name="TCanExecute">The type of the can execute.</typeparam>
    /// <seealso cref="ICommand" />
    [DebuggerStepThrough]
    public sealed class RelayCommand<TFunction, TCanExecute> : ICommand
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RelayCommand{TFunction, TCanExecute}"/> class.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        public RelayCommand(Action<TFunction> methodToExecute) : this(methodToExecute, default) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="RelayCommand{TFunction, TCanExecute}"/> class.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="canExecuteEvaluator">The can execute evaluator.</param>
        /// <exception cref="ArgumentNullException">methodToExecute</exception>
        public RelayCommand(Action<TFunction> methodToExecute, Func<TCanExecute, Boolean>? canExecuteEvaluator)
        {
            MethodToExecute = methodToExecute ?? throw new ArgumentNullException(nameof(methodToExecute));
            CanExecuteEvaluator = canExecuteEvaluator;
        }

        /// <summary>
        /// Gets the method to execute.
        /// </summary>
        /// <value>
        /// The method to execute.
        /// </value>
        private Action<TFunction> MethodToExecute { get; }

        /// <summary>
        /// Gets the can execute evaluator.
        /// </summary>
        /// <value>
        /// The can execute evaluator.
        /// </value>
        private Func<TCanExecute, Boolean>? CanExecuteEvaluator { get; }

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { if (CanExecuteEvaluator.IsNotNull()) { CommandManager.RequerySuggested += value; } }
            remove { if (CanExecuteEvaluator.IsNotNull()) { CommandManager.RequerySuggested -= value; } }
        }

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <returns>
        ///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="ArgumentException">parameter</exception>
        public Boolean CanExecute(Object? parameter)
        {
            Boolean retVal = true;

            if (CanExecuteEvaluator.IsNotNull())
            {
                if (parameter.IsNotNull() &&
                    !(parameter is TCanExecute))
                {
                    String message = $"The supplied parameter is not of the correct type. Expected Type: {typeof(TCanExecute)}. Supplied parameter type: {parameter.GetType()}";
                    throw new ArgumentException(message, nameof(parameter));
                }

                retVal = CanExecuteEvaluator.Invoke((TCanExecute)parameter);
            }

            return retVal;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <exception cref="ArgumentException">parameter</exception>
        public void Execute(Object? parameter)
        {
            if (MethodToExecute.IsNotNull())
            {
                if (parameter.IsNotNull() &&
                    !(parameter is TFunction))
                {
                    String message = $"The supplied parameter is not of the correct type. Expected Type: {typeof(TFunction)}. Supplied parameter type: {parameter.GetType()}";
                    throw new ArgumentException(message, nameof(parameter));
                }

                MethodToExecute.Invoke((TFunction)parameter);
            }
        }
    }
}
