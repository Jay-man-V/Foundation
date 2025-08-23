//-----------------------------------------------------------------------
// <copyright file="LocationUtils.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Reflection;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the LocationUtils class.
    /// </summary>
    public static class LocationUtils
    {
        /// <summary>
        /// Gets the namespace.
        /// </summary>
        /// <param name="stackOffset">The stack offset.</param>
        /// <returns></returns>
        public static String GetNamespace(Int32 stackOffset = 1)
        {
            String retVal = "<unknown>";
            
            StackTrace stackTrace = new();
            StackFrame? stackFrame = stackTrace.GetFrame(stackOffset);

            if (stackFrame != null)
            {
                MethodBase? methodBase = stackFrame.GetMethod();

                if (methodBase != null)
                {
                    Type? reflectedType = methodBase.ReflectedType;

                    if (reflectedType != null)
                    {
                        retVal = reflectedType.Namespace ?? "<unknown>";
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <param name="stackOffset">The stack offset.</param>
        /// <returns></returns>
        public static String GetClassName(Int32 stackOffset = 1)
        {
            String retVal = "<unknown>";

            StackTrace stackTrace = new();
            StackFrame? stackFrame = stackTrace.GetFrame(stackOffset);

            if (stackFrame != null)
            {
                MethodBase? methodBase = stackFrame.GetMethod();

                if (methodBase != null)
                {
                    Type? reflectedType = methodBase.ReflectedType;

                    if (reflectedType != null)
                    {
                        retVal = reflectedType.Name;
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        /// <param name="stackOffset">The stack offset.</param>
        /// <returns></returns>
        public static String GetFunctionName(Int32 stackOffset = 1)
        {
            String retVal = "<unknown>";

            StackTrace stackTrace = new();
            StackFrame? stackFrame = stackTrace.GetFrame(stackOffset);

            if (stackFrame != null)
            {
                MethodBase? methodBase = stackFrame.GetMethod();

                if (methodBase != null)
                {
                    retVal = methodBase.Name;
                }
            }

            return retVal;
        }

        /// <summary>
        /// Gets the name of the function including the class and namespace.
        /// </summary>
        /// <param name="stackOffset">The stack offset.</param>
        /// <returns></returns>
        public static String GetFullyQualifiedFunctionName(Int32 stackOffset = 1)
        {
            String retVal = $"{GetNamespace(stackOffset + 2)}.{GetClassName(stackOffset + 2)}.{GetFunctionName(stackOffset + 1)}";

            return retVal;
        }
    }
}
