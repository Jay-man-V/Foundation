//-----------------------------------------------------------------------
// <copyright file="LocationUtils.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;

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
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(stackOffset);

            String retVal = sf.GetMethod().ReflectedType.Namespace;

            return retVal;
        }

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <param name="stackOffset">The stack offset.</param>
        /// <returns></returns>
        public static String GetClassName(Int32 stackOffset = 1)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(stackOffset);

            String retVal = sf.GetMethod().ReflectedType.Name;

            return retVal;
        }

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        /// <param name="stackOffset">The stack offset.</param>
        /// <returns></returns>
        public static String GetFunctionName(Int32 stackOffset = 0)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1 + stackOffset);

            String retVal = sf.GetMethod().Name;

            return retVal;
        }

        /// <summary>
        /// Gets the name of the function including the class and namespace.
        /// </summary>
        /// <param name="stackOffset">The stack offset.</param>
        /// <returns></returns>
        public static String GetFullyQualifiedFunctionName(Int32 stackOffset = 0)
        {
            String retVal = $"{GetNamespace(stackOffset + 2)}.{GetClassName(stackOffset + 2)}.{GetFunctionName(stackOffset + 1)}";

            return retVal;
        }
    }
}
