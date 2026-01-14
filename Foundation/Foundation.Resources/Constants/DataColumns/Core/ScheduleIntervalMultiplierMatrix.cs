//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalMultiplierMatrix.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Schedule Interval Multiplier Matrix data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ScheduleIntervalMultiplierMatrix : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            ///// <summary>
            ///// The code
            ///// </summary>
            //public const Int32 Code = 6;

            /// <summary>
            /// The description
            /// </summary>
            public const Int32 Description = 500;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(ScheduleIntervalMultiplierMatrix);

        /// <summary>
        /// Gets the from schedule interval id.
        /// </summary>
        /// <value>
        /// The from schedule interval id.
        /// </value>
        public static String FromScheduleIntervalId => "FromScheduleIntervalId";

        /// <summary>
        /// Gets the to schedule interval id.
        /// </summary>
        /// <value>
        /// The to schedule interval id.
        /// </value>
        public static String ToScheduleIntervalId => "ToScheduleIntervalId";

        /// <summary>
        /// Gets the multiplier.
        /// </summary>
        /// <value>
        /// The multiplier.
        /// </value>
        public static String Multiplier => "Multiplier";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";
    }
}
