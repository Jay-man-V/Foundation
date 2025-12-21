//-----------------------------------------------------------------------
// <copyright file="DateTimeService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="IDateTimeService" />
    [DependencyInjectionTransient]
    public class DateTimeService : ServiceBase, IDateTimeService
    {
#if (DEBUG)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="injectedSystemUtcDateTime"></param>
        /// <param name="injectedSystemLocalDateTime"></param>
        internal DateTimeService
        (
            DateTime injectedSystemUtcDateTime,
            DateTime injectedSystemLocalDateTime
        ) :
            this()
        {
            LoggingHelpers.TraceCallEnter();

            InjectedSystemUtcDateTime = injectedSystemUtcDateTime;
            InjectedSystemLocalDateTime = injectedSystemLocalDateTime;
            UseInjectedSystemDateTime = true;

            LoggingHelpers.TraceCallReturn();
        }

        private Boolean UseInjectedSystemDateTime { get; }
        private DateTime InjectedSystemUtcDateTime { get; }
        private DateTime InjectedSystemLocalDateTime { get; }
#endif

        /// <summary>
        /// 
        /// </summary>
        public DateTimeService
        (
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IDateTimeService.StartOfWeek"/>
        public DayOfWeek StartOfWeek => DayOfWeek.Monday;

        /// <inheritdoc cref="IDateTimeService.SystemUtcDateTimeNow"/>
        public DateTime SystemUtcDateTimeNow
        {
            get
            {
                DateTime retVal = DateTime.UtcNow;

#if (DEBUG)
                if (UseInjectedSystemDateTime)
                {
                    retVal = InjectedSystemUtcDateTime;
                }
#endif

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.SystemLocalDateTimeNow"/>
        public DateTime SystemLocalDateTimeNow
        {
            get
            {
                DateTime retVal = DateTime.Now;

#if (DEBUG)
                if (UseInjectedSystemDateTime)
                {
                    retVal = InjectedSystemLocalDateTime;
                }
#endif

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.SystemDateTimeNowWithoutMilliseconds"/>
        public DateTime SystemDateTimeNowWithoutMilliseconds
        {
            get
            {
                DateTime retVal = SystemUtcDateTimeNow;
                retVal = retVal.AddTicks(-(retVal.Ticks % TimeSpan.TicksPerSecond));
                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.MakeUtcDateTime(DateTime)"/>
        public DateTime MakeUtcDateTime(DateTime date)
        {
            LoggingHelpers.TraceCallEnter(date);

            DateTime retVal = MakeUtcDateTime(date, date.TimeOfDay);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.MakeUtcDateTime(DateTime, TimeSpan)"/>
        public DateTime MakeUtcDateTime(DateTime date, TimeSpan time)
        {
            LoggingHelpers.TraceCallEnter(date, time);

            DateTime retVal = MakeUtcDateTime(date, time.Hours, time.Minutes, time.Seconds);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.MakeUtcDateTime(DateTime, Int32, Int32, Int32)"/>
        public DateTime MakeUtcDateTime(DateTime date, Int32 hours, Int32 minutes, Int32 seconds)
        {
            LoggingHelpers.TraceCallEnter(date, hours, minutes, seconds);

            DateTime retVal = new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds, DateTimeKind.Utc);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
