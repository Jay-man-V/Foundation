//-----------------------------------------------------------------------
// <copyright file="RelayCommandFactory.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Foundation.Common
{
    /// <summary>
    /// The Relay Command Factory
    /// </summary>
    [DebuggerStepThrough]
    public static class RelayCommandFactory
    {
        /// <summary>
        /// Always true.
        /// </summary>
        /// <returns></returns>
        public static Boolean AlwaysTrue() { return true; }

        /// <summary>
        /// Always true.
        /// </summary>
        /// <param name="_">The .</param>
        /// <returns></returns>
        public static Boolean AlwaysTrue(Object _) { return true; }

        /// <summary>
        /// Always false.
        /// </summary>
        /// <returns></returns>
        public static Boolean AlwaysFalse() { return false; }

        /// <summary>
        /// Always false.
        /// </summary>
        /// <param name="_">The .</param>
        /// <returns></returns>
        public static Boolean AlwaysFalse(Object _) { return false; }

        /// <summary>
        /// News the specified method to execute.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <returns></returns>
        public static ICommand New(Action methodToExecute)
        {
            ICommand retVal = new RelayCommand<Object>(_ => methodToExecute(), AlwaysTrue);

            return retVal;
        }

        /// <summary>
        /// News the specified method to execute.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="canExecuteEvaluator">The can execute evaluator.</param>
        /// <returns></returns>
        public static ICommand New(Action methodToExecute, Func<Boolean> canExecuteEvaluator)
        {
            ICommand retVal = new RelayCommand<Object>(_ => methodToExecute(), canExecuteEvaluator);

            return retVal;
        }

        /// <summary>
        /// News the specified method to execute.
        /// </summary>
        /// <typeparam name="TExecute">The type of the parameter to execute with.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <returns></returns>
        public static ICommand New<TExecute>(Action<TExecute?> methodToExecute)
        {
            ICommand retVal = new RelayCommand<TExecute?>(methodToExecute, AlwaysTrue);

            return retVal;
        }

        /// <summary>
        /// News the specified method to execute.
        /// </summary>
        /// <typeparam name="TExecute">The type of the parameter to execute with.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="canExecuteEvaluator">The can execute evaluator.</param>
        /// <returns></returns>
        public static ICommand New<TExecute>(Action<TExecute?> methodToExecute, Func<Boolean> canExecuteEvaluator)
        {
            ICommand retVal = new RelayCommand<TExecute>(methodToExecute, canExecuteEvaluator);

            return retVal;
        }

        /// <summary>
        /// News the specified method to execute.
        /// </summary>
        /// <typeparam name="TExecute">The type of the parameter to execute with.</typeparam>
        /// <typeparam name="TFunction">The type of the function.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="canExecuteEvaluator">The can execute evaluator.</param>
        /// <returns></returns>
        public static ICommand New<TExecute, TFunction>(Action<TExecute?> methodToExecute, Func<TFunction?, Boolean> canExecuteEvaluator)
        {
            ICommand retVal = new RelayCommand<TExecute, TFunction>(methodToExecute, canExecuteEvaluator);

            return retVal;
        }
    }
}
