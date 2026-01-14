//-----------------------------------------------------------------------
// <copyright file="IScheduleIntervalMultiplierMatrixProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Schedule Interval Multiplier Matrix process
    /// </summary>
    public interface IScheduleIntervalMultiplierMatrixProcess : ICommonBusinessProcess<IScheduleIntervalMultiplierMatrix>
    {
        /// <summary>
        /// Applies the given filter criteria (<paramref name="fromScheduleInterval"/> and <paramref name="toScheduleInterval"/>) to the supplied
        /// <paramref name="scheduleIntervalMultiplierMatrices"/> and returns the result
        /// </summary>
        /// <param name="scheduleIntervalMultiplierMatrices">The full list of <see cref="IScheduleIntervalMultiplierMatrix"/></param>
        /// <param name="fromScheduleInterval">The <see cref="IScheduleInterval"/> to filter by</param>
        /// <param name="toScheduleInterval">The <see cref="IScheduleInterval"/> to filter by</param>
        /// <returns>Filtered <see cref="List{TValue}"/></returns>
        List<IScheduleIntervalMultiplierMatrix> ApplyFilter(List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices, IScheduleInterval? fromScheduleInterval, IScheduleInterval? toScheduleInterval);

        /// <summary>
        /// Given the <paramref name="scheduleIntervalMultiplierMatrices"/> function will create a new list of <see cref="IScheduleInterval"/> that are From Intervals
        /// </summary>
        /// <param name="scheduleIntervalMultiplierMatrices">The full list of schedule interval multiplier matrices</param>
        /// <returns>List of <see cref="IContactDetail"/> that are Parents</returns>
        List<IScheduleInterval> MakeListOfFromSchedulerIntervals(List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices);

        /// <summary>
        /// Given the <paramref name="scheduleIntervalMultiplierMatrices"/> function will create a new list of <see cref="IScheduleInterval"/> that are To Intervals
        /// </summary>
        /// <param name="scheduleIntervalMultiplierMatrices">The full list of schedule interval multiplier matrices</param>
        /// <returns>List of <see cref="IContactDetail"/> that are Parents</returns>
        List<IScheduleInterval> MakeListOfToSchedulerIntervals(List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices);
    }
}
