//-----------------------------------------------------------------------
// <copyright file="IExecuteWithObject.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// This interface is meant for the <see cref="WeakAction{T}"/> class and can be
    /// useful if you store multiple WeakAction{T} instances but don't know in advance
    /// what type T represents
    /// </summary>
    public interface IExecuteWithObject
    {
        /// <summary>
        /// The target of the WeakAction
        /// </summary>
        Object Target { get; }

        /// <summary>
        /// Executes an action
        /// </summary>
        /// <param name="parameter">Parameter to be passed during execution</param>
        void ExecuteWithObject(Object parameter);

        /// <summary>
        /// Deletes all references, which notifies the cleanup method that this entry must be deleted
        /// </summary>
        void MarkForDeletion();
    }
}
