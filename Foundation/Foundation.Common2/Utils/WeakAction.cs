//-----------------------------------------------------------------------
// <copyright file="WeakAction.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Reflection;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the WeakAction class.
    /// Stores a <see cref="Action"/> without causing a hard reference to be
    /// created to the Actions owner. The owner can then be cleaned up at any time.
    /// </summary>
    public class WeakAction
    {
        /// <summary>
        /// Initialises an empty instance of the <see cref="WeakAction"/> class
        /// </summary>
        protected WeakAction() { }

        /// <summary>
        /// Initialises an empty instance of the <see cref="WeakAction"/> class
        /// </summary>
        /// <param name="action">The action will be associated to this instance.</param>
        public WeakAction(Action action)
        : this(action.IsNull() ? null : action.Target, action)
        {
        }

        /// <summary>
        /// Initialises an empty instance of the <see cref="WeakAction"/> class
        /// </summary>
        /// <param name="target">The action's owner.</param>
        /// <param name="action">The action will be associated to this instance.</param>
        public WeakAction(Object target, Action action)
        {
#if NETFX_CORE
            if (action.GetMethodInfo().IsStatic)
#else
            if (action.Method.IsStatic)
#endif
            {
                StaticAction = action;
                if (target.IsNull())
                {
                    // Keep a reference to the target to control the WeakAction's lifetime
                    Reference = new WeakReference(target);
                }
            }
            else
            {
#if NETFX_CORE
                Method = action.GetMethodInfo();
#else
                Method = action.Method;
#endif
                ActionReference = new WeakReference(action.Target);
                Reference = new WeakReference(target);
            }
        }

        private Action StaticAction { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MethodInfo"/> corresponding to this <see cref="WeakAction"/>'s method passed in the constructor
        /// </summary>
        protected MethodInfo Method { get; set; }

        /// <summary>
        /// Gets the name of the method that this WeakAction represents
        /// </summary>
        public String MethodName
        {
            get
            {
                String retVal = Method.Name;
                if (StaticAction.IsNotNull())
                {
#if NETFX_CORE
                    return StaticAction.GetMethodInfo().Name;
#else
                    return StaticAction.Method.Name;
#endif
                }

                return retVal;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WeakReference"/> to this <see cref="WeakAction"/>'s Actions target 
        /// This is not necessarily the same as <see cref="Reference"/>. For example if the method is anonymous
        /// </summary>
        protected WeakReference ActionReference { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WeakReference"/> to the target passed when constructing the <see cref="WeakAction"/>.
        /// This is not necessarily the same as <see cref="ActionReference"/>. For example if the method is anonymous
        /// </summary>
        protected WeakReference Reference { get; set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="WeakAction"/> is static or not
        /// </summary>
        public Boolean IsStatic => StaticAction.IsNotNull();

        /// <summary>
        /// Gets a value indicating whether the Action's owner is still alive, or it was cleaned up
        /// by the Garbage Collector already
        /// </summary>
        public Boolean IsAlive
        {
            get
            {
                Boolean retVal = false;
                //if (StaticAction.IsNull() &&
                //    Reference.IsNull())
                //{
                //    retVal = false;
                //}

                if (StaticAction.IsNotNull())
                {
                    if (Reference.IsNotNull())
                    {
                        retVal = Reference.IsAlive;
                    }
                    else
                    {
                        retVal = true;
                    }
                }

                return retVal;
            }
        }

        /// <summary>
        /// Gets the Actions owner.
        /// This will be stored as a <see cref="WeakReference"/>
        /// </summary>
        public Object Target
        {
            get
            {
                Object retVal = null;
                if (Reference.IsNotNull())
                {
                    retVal = Reference.Target;
                }

                return retVal;
            }
        }

        /// <summary>
        /// The target of the Weak Reference
        /// </summary>
        protected Object ActionTarget
        {
            get
            {
                Object retVal = null;
                if (ActionReference.IsNotNull())
                {
                    retVal = ActionReference.Target;
                }

                return retVal;
            }
        }

        /// <summary>
        /// Executes the Action.
        /// This only happens if the actions owner is still alive
        /// </summary>
        public void Execute()
        {
            if (StaticAction.IsNotNull())
            {
                StaticAction();
                return;
            }

            Object actionTarget = ActionTarget;

            if (IsAlive)
            {
                if (Method.IsNotNull() &&
                    ActionReference.IsNotNull() &&
                    ActionTarget.IsNotNull())
                {
                    const Object[] parameters = null;
                    Method.Invoke(actionTarget, parameters);
                }
            }
        }

        /// <summary>
        /// Sets the reference that this instance stores to null
        /// </summary>
        public void MarkForDeletion()
        {
            Reference = null;
            ActionReference = null;
            Method = null;
            StaticAction = null;
        }
    }
}
