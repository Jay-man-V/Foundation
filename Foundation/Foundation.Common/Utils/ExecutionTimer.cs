//-----------------------------------------------------------------------
// <copyright file="ExecutionTimer.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the ExecutionTimer class.
    /// Used to track how long a Process takes to execute
    /// </summary>
    public class ExecutionTimer : IDisposable
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ExecutionTimer"/> class.
        /// </summary>
        public ExecutionTimer() :
            this
            (
                new StackFrame(1).GetMethod()?.Name ?? String.Empty
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
        private Stopwatch TimerStopwatch { get; } = new Stopwatch();

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
            TimerStopwatch.Reset();
            TimerStopwatch.Start();

            String message = $"Start: {ProcessName} => {DateTime.Now:yyyy MMM dd HH:mm:ss.fff}";
            Debug.WriteLine(message);
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            TimerStopwatch.Stop();
            Duration = TimerStopwatch.Elapsed;

            String message = $"Stop: {ProcessName} => {DateTime.Now:yyyy MMM dd HH:mm:ss.fff}";
            Debug.WriteLine(message);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
        {
            String retVal = $"{ProcessName} {Duration:c}";
            return retVal;
        }

        public void Dispose()
        {
            StopTimer();
            String message = $"Duration: {ProcessName} => {ToString()}";
            Debug.WriteLine(message);
        }
    }
}
