//-----------------------------------------------------------------------
// <copyright file="ExecutionTimer.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the ExecutionTimer class.
    /// Used to track how long a Process takes to execute
    /// </summary>
    public class ExecutionTimer
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ExecutionTimer"/> class.
        /// </summary>
        public ExecutionTimer() :
            this
            (
                new StackFrame(1).GetMethod().Name
            )
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ExecutionTimer"/> class.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        public ExecutionTimer(String processName)
        {
            ProcessName = processName;
            StartTimer();
        }

        /// <summary>
        /// Gets the duration as seconds.
        /// </summary>
        /// <value>
        /// The duration as seconds.
        /// </value>
        public Double DurationAsSeconds => Duration.TotalSeconds;

        /// <summary>
        /// Gets or sets the name of the Process.
        /// </summary>
        /// <value>
        /// The name of the Process.
        /// </value>
        public String ProcessName { get; }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Gets or sets the timer stopwatch.
        /// </summary>
        /// <value>
        /// The timer stopwatch.
        /// </value>
        private Stopwatch TimerStopwatch { get; set; } = default;

        /// <summary>
        /// Gets or sets the size of the indent.
        /// </summary>
        /// <value>
        /// The size of the indent.
        /// </value>
        private Int32 IndentSize { get; set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ExecutionTimer"/> to <see cref="String"/>.
        /// </summary>
        /// <param name="timer">The timer.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator String(ExecutionTimer timer)
        {
            String retVal = timer.ToString();
            return retVal;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            TimerStopwatch = new Stopwatch();
            TimerStopwatch.Start();

            IndentSize += 4;

            Debug.WriteLine($"Start:{ProcessName.PadLeft(IndentSize, ' ')} => {ToString()}");
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            TimerStopwatch.Stop();
            Duration = TimerStopwatch.Elapsed;

            IndentSize -= 4;

            Debug.WriteLine($"Stop: {ProcessName.PadLeft(IndentSize, ' ')} => {ToString()}");
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
        {
            String retVal = $"{ProcessName} {Duration}";
            return retVal;
        }
    }
}
