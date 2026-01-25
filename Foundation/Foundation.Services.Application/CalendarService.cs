//-----------------------------------------------------------------------
// <copyright file="CalendarService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="ICalendarService" />
    [DependencyInjectionTransient]
    public class CalendarService : ServiceBase, ICalendarService
    {
        /// <summary>
        /// 
        /// </summary>
        public CalendarService
        (
            ICalendarRepository calendarRepository
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter();

            CalendarRepository = calendarRepository;

            LoggingHelpers.TraceCallReturn();
        }

        private ICalendarRepository CalendarRepository { get; }

        /// <inheritdoc cref="ICalendarService.IsHoliday(String, DateTime)"/>
        public Boolean IsHoliday(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            Boolean retVal = CalendarRepository.IsNonWorkingDay(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetNextWorkingDay(String, DateTime)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = GetNextWorkingDay(countryCode, date, ScheduleInterval.Days, 1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetNextWorkingDay(String, DateTime, TimeWindow, TimeSpan)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date, TimeWindow workingTimeWindow, TimeSpan duration)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date, workingTimeWindow, duration);

            DateTime retVal = date;
            TimeSpan adjustingTimeSpan = duration;

            // Calculate the length of a day based on the given Start and End times
            TimeSpan oneDayTimeSpan = workingTimeWindow.EndTime - workingTimeWindow.StartTime;

            // Adjust the TimeOfDay based on the Start and End times of the workingTimeWindow
            if (retVal.TimeOfDay < workingTimeWindow.StartTime)
            {
                retVal = retVal.Date + workingTimeWindow.StartTime;
            }

            retVal = CalendarRepository.CheckIsWorkingDayOrGetNextWorkingDay(countryCode, retVal);

            if (retVal.TimeOfDay > workingTimeWindow.EndTime)
            {
                retVal = retVal.Date.AddDays(1) + workingTimeWindow.StartTime;

                retVal = CalendarRepository.CheckIsWorkingDayOrGetNextWorkingDay(countryCode, retVal);
            }

            // Now adjust the calculated DateTime for the number of Working days spanned by the duration
            while (adjustingTimeSpan.TotalMilliseconds > oneDayTimeSpan.TotalMilliseconds)
            {
                adjustingTimeSpan = adjustingTimeSpan.Subtract(oneDayTimeSpan);

                retVal = retVal.AddDays(1);

                retVal = CalendarRepository.CheckIsWorkingDayOrGetNextWorkingDay(countryCode, retVal);
            }

            // Finally, add the remaining minutes
            retVal = retVal.Add(adjustingTimeSpan);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetNextWorkingDay(String, DateTime, ScheduleInterval, Int32)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date, ScheduleInterval intervalType, Int32 interval)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date, intervalType, interval);

            DateTime retVal = CalendarRepository.GetNextWorkingDay(countryCode, date, intervalType, interval);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.CheckIsWorkingDayOrGetNextWorkingDay(String, DateTime)"/>
        public DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = CalendarRepository.CheckIsWorkingDayOrGetNextWorkingDay(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
        /// <inheritdoc cref="ICalendarService.GetFirstWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = CalendarRepository.GetFirstWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetFirstWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = CalendarRepository.GetFirstWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetLastWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = CalendarRepository.GetLastWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetLastWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = CalendarRepository.GetLastWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
