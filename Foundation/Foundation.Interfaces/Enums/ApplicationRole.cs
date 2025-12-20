//-----------------------------------------------------------------------
// <copyright file="ApplicationRoles.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Available Application Roles
    /// </summary>
    [Browsable(true),
     Category("Permissions"),
     Description("Specifies the available or required application role")]
    public enum ApplicationRole
    {
        /// <summary>
        /// No Access
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        None = 0,

        /// <summary>
        /// Read only
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Read only")]
        ReadOnly = 1,

        /// <summary>
        /// Reporting only
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Reporter")]
        Reporter = 2,

        /// <summary>
        /// Can create records
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Creator")]
        Creator = 3,

        /// <summary>
        /// Edit their own data only
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Own editor")]
        OwnEditor = 4,

        /// <summary>
        /// Can edit all records
        /// </summary>
        [Id(5), Display(Order = 5, Name = "All editor")]
        AllEditor = 5,

        /// <summary>
        /// Delete their own data only
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Own delete")]
        OwnDelete = 6,

        /// <summary>
        /// Can edit all records
        /// </summary>
        [Id(7), Display(Order = 7, Name = "All delete")]
        AllDelete = 7,

        /// <summary>
        /// Approver
        /// </summary>
        [Id(8), Display(Order = 8, Name = "Approver")]
        Approver = 8,

        /// <summary>
        /// Team Supervisor
        /// </summary>
        [Id(9), Display(Order = 9, Name = "Team supervisor")]
        TeamSupervisor = 9,

        /// <summary>
        /// Deputy Team Manager
        /// </summary>
        [Id(10), Display(Order = 10, Name = "Deputy team manager")]
        DeputyTeamManager = 10,

        /// <summary>
        /// Primary Team Manager
        /// </summary>
        [Id(11), Display(Order = 11, Name = "Primary team manager")]
        PrimaryTeamManager = 11,

        /// <summary>
        /// System Supervisor
        /// </summary>
        [Id(998), Display(Order = 12, Name = "System supervisor")]
        SystemSupervisor = 998,

        /// <summary>
        /// System Supervisor
        /// </summary>
        [Id(999), Display(Order = 13, Name = "System data administrator")]
        SystemDataAdministrator = 999,

        /// <summary>
        /// System Administrator
        /// </summary>
        [Id(1000), Display(Order = 14, Name = "System administrator")]
        SystemAdministrator = 1000
    }
}
