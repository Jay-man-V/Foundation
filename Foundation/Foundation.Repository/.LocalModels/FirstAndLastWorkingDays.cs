//-----------------------------------------------------------------------
// <copyright file="CalendarRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Repository.LocalModels
{
    internal class FirstAndLastWorkingDays
    {
        public DateTime FirstWorkingDay { get; set; }
        public DateTime LastWorkingDay { get; set; }
    }
}
