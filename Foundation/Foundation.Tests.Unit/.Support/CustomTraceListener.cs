//-----------------------------------------------------------------------
// <copyright file="CustomTraceListener.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Text;

namespace Foundation.Tests.Unit.Support
{
    public class CustomTraceListener : TraceListener
    {
        public String Message => MessageBuilder.ToString();

        private StringBuilder MessageBuilder { get; } = new StringBuilder();

        public override void Write(String? message)
        {
            MessageBuilder.Append(message);
        }

        public override void WriteLine(String? message)
        {
            MessageBuilder.AppendLine(message);
        }
    }
}