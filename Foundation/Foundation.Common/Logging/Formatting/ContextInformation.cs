//-----------------------------------------------------------------------
// <copyright file="ContextInformation.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Foundation.Common
{
    /// <summary>
    /// Internal class used to obtain context information for the Logging routines.
    /// Provides easy access to information such as method name, namespace, source file
    /// name, etc.
    /// </summary>
    internal class ContextInformation
    {
        /// <summary>
        /// The capture file information
        /// Parameter to StackTrace constructor to make code more readable
        /// </summary>
        private const Boolean CaptureFileInfo = true;

        /// <summary>
        /// The default text
        /// Default text for all of the properties
        /// </summary>
        private const String DefaultText = "<unknown>";

        /// <summary>
        /// The target stack frame
        /// The StackFrame within StackTrace that contains the details I want
        /// <remarks>
        ///      frame[0] = Current method, i.e. ContextInformation constructor
        ///      frame[1] = The caller, i.e. the trace method trying to get the context
        ///      frame[2] = The method we actually want, i.e. the method which called Trace...().
        /// </remarks>
        /// </summary>
        private const Int32 TargetStackFrame = 2;

        /// <summary>
        /// Initialises a new instance of the <see cref="ContextInformation"/> class.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        public ContextInformation(params Object[]? parameterValues)
        {
            // Initialise private members
            ClassName = DefaultText;
            FileLineNumber = DefaultText;
            FileName = DefaultText;
            MethodArguments = DefaultText;
            MethodName = DefaultText;
            Namespace = DefaultText;

            // Get a reference to the stack trace which will contain a number of stack frames:
            StackTrace stack = new (CaptureFileInfo);
            if (stack.FrameCount >= TargetStackFrame + 1)
            {
                StackFrame targetStackFrame = stack.GetFrame(TargetStackFrame);
                MethodBase callingMethod = targetStackFrame.GetMethod();
                if (callingMethod.IsNotNull() && callingMethod.ReflectedType.IsNotNull())
                {
                    ClassName = callingMethod.ReflectedType.Name;
                    FileLineNumber = targetStackFrame.GetFileLineNumber().ToString();
                    FileName = targetStackFrame.GetFileName() ?? DefaultText;
                    MethodName = callingMethod.Name;
                    Namespace = callingMethod.ReflectedType.Namespace ?? DefaultText;

                    ParameterInfo[] methodParameters = callingMethod.GetParameters();
                    StringBuilder methodArguments = new ();
                    for (Int16 parameterIndex = 0; parameterIndex < methodParameters.Length; parameterIndex++)
                    {
                        ParameterInfo methodParam = methodParameters[parameterIndex];

                        String paramType = methodParam.ParameterType.Name;
                        String paramName = methodParam.Name;
                        methodArguments.Append($"{paramType} {paramName}");

                        if (parameterValues.IsNotNull() &&
                            parameterValues.GetUpperBound(0) >= parameterIndex)
                        {
                            String objectValue = MessageFormatter.RenderObjectValue(parameterValues[parameterIndex]);
                            //String objectValue = MessageFormatter.RenderObjectValue(parameterValues);
                            methodArguments.Append($" = '{objectValue}'");
                        }

                        if (parameterIndex < methodParameters.Length - 1)
                        {
                            methodArguments.Append(", ");
                        }
                    }

                    MethodArguments = methodArguments.ToString();
                }
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public String FileName { get; }

        /// <summary>
        /// Gets the file line number.
        /// </summary>
        /// <value>
        /// The file line number.
        /// </value>
        public String FileLineNumber { get; }

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        /// <value>
        /// The namespace.
        /// </value>
        public String Namespace { get; }

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        public String ClassName { get; }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        /// <value>
        /// The name of the method.
        /// </value>
        public String MethodName { get; }

        /// <summary>
        /// Gets the method arguments.
        /// </summary>
        /// <value>
        /// The method arguments.
        /// </value>
        public String MethodArguments { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            String retVal = $"{ClassName}.{MethodName}({MethodArguments})";

            return retVal;
        }

        /// <summary>
        /// To the string.
        /// </summary>
        /// <param name="outputLevel">The output level.</param>
        /// <returns>
        /// A string that represents the current object formatted to a pre-defined format.
        /// </returns>
        public String ToString(Int32 outputLevel)
        {
            String retVal = outputLevel switch
            {
                0 => $"{ClassName}.{MethodName}()",
                _ => ToString()
            };

            return retVal;
        }
    }
}
