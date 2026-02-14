//-----------------------------------------------------------------------
// <copyright file="ILottoNumbers.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace NationalLottery.Interfaces
{
    /// <summary>
    /// Lotto Numbers model interface definition
    /// </summary>
    /// <seealso cref="INationalLotteryModel" />
    public interface ILottoNumbers : INationalLotteryModel
    {
        /// <summary>
        /// Gets or sets the draw date.
        /// </summary>
        /// <value>
        /// The draw date.
        /// </value>
        DateTime DrawDate { get; set; }

        /// <summary>
        /// Gets or sets the ball1.
        /// </summary>
        /// <value>
        /// The ball1.
        /// </value>
        Int32 Ball1 { get; set; }

        /// <summary>
        /// Gets or sets the ball2.
        /// </summary>
        /// <value>
        /// The ball2.
        /// </value>
        Int32 Ball2 { get; set; }

        /// <summary>
        /// Gets or sets the ball3.
        /// </summary>
        /// <value>
        /// The ball3.
        /// </value>
        Int32 Ball3 { get; set; }

        /// <summary>
        /// Gets or sets the ball4.
        /// </summary>
        /// <value>
        /// The ball4.
        /// </value>
        Int32 Ball4 { get; set; }

        /// <summary>
        /// Gets or sets the ball5.
        /// </summary>
        /// <value>
        /// The ball5.
        /// </value>
        Int32 Ball5 { get; set; }

        /// <summary>
        /// Gets or sets the ball6.
        /// </summary>
        /// <value>
        /// The ball6.
        /// </value>
        Int32 Ball6 { get; set; }

        /// <summary>
        /// Gets or sets the bonus ball1.
        /// </summary>
        /// <value>
        /// The bonus ball1.
        /// </value>
        Int32 BonusBall1 { get; set; }

        /// <summary>
        /// Gets or sets the jackpot.
        /// </summary>
        /// <value>
        /// The jackpot.
        /// </value>
        Decimal Jackpot { get; set; }
    }
}
