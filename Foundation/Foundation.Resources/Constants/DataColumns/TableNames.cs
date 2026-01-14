//-----------------------------------------------------------------------
// <copyright file="TableNames.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Table Names
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class TableNames
    {
        /// <summary>
        /// 
        /// </summary>
        public class Specialised
        {
            /// <summary>
            /// Gets the database schema table.
            /// </summary>
            /// <value>
            /// The database schema table.
            /// </value>
            public static String DbSchemaTable => "[INFORMATION_SCHEMA].[TABLES]";

            /// <summary>
            /// Gets the database schema column.
            /// </summary>
            /// <value>
            /// The database schema column.
            /// </value>
            public static String DbSchemaColumn => "[INFORMATION_SCHEMA].[COLUMNS]";
        }

        // Application Tables

        /// <summary>
        /// Gets the menu item.
        /// </summary>
        /// <value>
        /// The menu item.
        /// </value>
        public static String MenuItem => "[app].[MenuItem]";

        /// <summary>
        /// Gets the catalogue.
        /// </summary>
        /// <value>
        /// The catalogue.
        /// </value>
        public static String Catalogue => "[dbo].[Catalogue]";

        /// <summary>
        /// Gets the catalogue item.
        /// </summary>
        /// <value>
        /// The catalogue item.
        /// </value>
        public static String CatalogueItem => "[dbo].[CatalogueItem]";

        // Core Tables

        /// <summary>
        /// Gets the application configuration.
        /// </summary>
        /// <value>
        /// The application configuration.
        /// </value>
        public static String ApplicationConfiguration => "[core].[ApplicationConfiguration]";

        /// <summary>
        /// Gets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public static String ApprovalStatus => "[core].[ApprovalStatus]";

        /// <summary>
        /// Gets the configuration scope.
        /// </summary>
        /// <value>
        /// The configuration scope.
        /// </value>
        public static String ConfigurationScope => "[core].[ConfigurationScope]";

        /// <summary>
        /// Gets the contact detail.
        /// </summary>
        /// <value>
        /// The contact detail.
        /// </value>
        public static String ContactDetail => "[core].[ContactDetail]";

        /// <summary>
        /// Gets the type of the contact.
        /// </summary>
        /// <value>
        /// The type of the contact.
        /// </value>
        public static String ContactType => "[core].[ContactType]";

        /// <summary>
        /// Gets the contract.
        /// </summary>
        /// <value>
        /// The contract.
        /// </value>
        public static String Contract => "[core].[Contract]";

        /// <summary>
        /// Gets the type of the contract.
        /// </summary>
        /// <value>
        /// The type of the contract.
        /// </value>
        public static String ContractType => "[core].[ContractType]";

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public static String Country => "[core].[Country]";

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public static String Currency => "[core].[Currency]";

        /// <summary>
        /// Gets the data status.
        /// </summary>
        /// <value>
        /// The data status.
        /// </value>
        public static String DataStatus => "[core].[DataStatus]";

        /// <summary>
        /// Gets the date period.
        /// </summary>
        /// <value>
        /// The date period.
        /// </value>
        public static String DatePeriod => "[core].[DatePeriod]";

        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public static String Department => "[core].[Department]";

        /// <summary>
        /// Gets the entity status.
        /// </summary>
        /// <value>
        /// The entity status.
        /// </value>
        public static String EntityStatus => "[core].[EntityStatus]";

        /// <summary>
        /// Gets the id generator.
        /// </summary>
        /// <value>
        /// The id generator.
        /// </value>
        public static String IdGenerator => "[core].[IdGenerator]";

        /// <summary>
        /// Gets the type of the image.
        /// </summary>
        /// <value>
        /// The type of the image.
        /// </value>
        public static String ImageType => "[core].[ImageType]";

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public static String Language => "[core].[Language]";

        /// <summary>
        /// Gets the national region.
        /// </summary>
        /// <value>
        /// The national region.
        /// </value>
        public static String NationalRegion => "[core].[NationalRegion]";

        /// <summary>
        /// Gets the non-working day.
        /// </summary>
        /// <value>
        /// The non-working day.
        /// </value>
        public static String NonWorkingDay => "[core].[NonWorkingDay]";

        /// <summary>
        /// Gets the office.
        /// </summary>
        /// <value>
        /// The office.
        /// </value>
        public static String Office => "[core].[Office]";

        /// <summary>
        /// Gets the office week calendar.
        /// </summary>
        /// <value>
        /// The office week calendar.
        /// </value>
        public static String OfficeWeekCalendar => "[core].[OfficeWeekCalendar]";

        /// <summary>
        /// Gets the scheduled job.
        /// </summary>
        /// <value>
        /// The scheduled job.
        /// </value>
        public static String ScheduledJob => "[core].[ScheduledJob]";

        /// <summary>
        /// Gets the schedule interval.
        /// </summary>
        /// <value>
        /// The schedule interval.
        /// </value>
        public static String ScheduleInterval => "[core].[ScheduleInterval]";

        /// <summary>
        /// Gets the schedule interval multiplier matrix.
        /// </summary>
        /// <value>
        /// The schedule interval.
        /// </value>
        public static String ScheduleIntervalMultiplierMatrix => "[core].[ScheduleIntervalMultiplierMatrix]";

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public static String Status => "[core].[Status]";

        /// <summary>
        /// Gets the task status.
        /// </summary>
        /// <value>
        /// The task status.
        /// </value>
        public static String TaskStatus => "[core].[TaskStatus]";

        /// <summary>
        /// Gets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        public static String TimeZone => "[core].[TimeZone]";

        /// <summary>
        /// Gets the world region.
        /// </summary>
        /// <value>
        /// The world region.
        /// </value>
        public static String WorldRegion => "[core].[WorldRegion]";

        // Log tables

        /// <summary>
        /// Gets the event log.
        /// </summary>
        /// <value>
        /// The event log.
        /// </value>
        public static String EventLog => "[log].[EventLog]";

        /// <summary>
        /// Gets the event log application.
        /// </summary>
        /// <value>
        /// The event log application.
        /// </value>
        public static String EventLogApplication => "[log].[EventLogApplication]";

        /// <summary>
        /// Gets the event log attachment.
        /// </summary>
        /// <value>
        /// The event log attachment.
        /// </value>
        public static String EventLogAttachment => "[log].[EventLogAttachment]";

        /// <summary>
        /// Gets the import export control.
        /// </summary>
        /// <value>
        /// The import export control.
        /// </value>
        public static String ImportExportControl => "[log].[ImportExportControl]";

        /// <summary>
        /// Gets the scheduled data status.
        /// </summary>
        /// <value>
        /// The scheduled data status.
        /// </value>
        public static String ScheduledDataStatus => "[log].[ScheduledDataStatus]";

        /// <summary>
        /// Gets the log severity.
        /// </summary>
        /// <value>
        /// The log severity.
        /// </value>
        public static String LogSeverity => "[log].[LogSeverity]";

        // Security tables

        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>
        /// The application.
        /// </value>
        public static String Application => "[sec].[Application]";

        /// <summary>
        /// Gets the type of the application/application.
        /// </summary>
        /// <value>
        /// The type of the application/application.
        /// </value>
        public static String ApplicationApplicationType => "[sec].[ApplicationApplicationType]";

        /// <summary>
        /// Gets the application role.
        /// </summary>
        /// <value>
        /// The application role.
        /// </value>
        public static String ApplicationRole => "[sec].[ApplicationRole]";

        /// <summary>
        /// Gets the type of the application.
        /// </summary>
        /// <value>
        /// The type of the application.
        /// </value>
        public static String ApplicationType => "[sec].[ApplicationType]";

        /// <summary>
        /// Gets the application/user/role.
        /// </summary>
        /// <value>
        /// The application/user/role.
        /// </value>
        public static String ApplicationUserRole => "[sec].[ApplicationUserRole]";

        /// <summary>
        /// Gets the authentication token.
        /// </summary>
        /// <value>
        /// The authentication token.
        /// </value>
        public static String AuthenticationToken => "[sec].[AuthenticationToken]";

        /// <summary>
        /// Gets the logged on user.
        /// </summary>
        /// <value>
        /// The logged on user.
        /// </value>
        public static String LoggedOnUser => "[sec].[LoggedOnUser]";

        /// <summary>
        /// Gets the permission matrix.
        /// </summary>
        /// <value>
        /// The permission matrix.
        /// </value>
        public static String PermissionMatrix => "[sec].[PermissionMatrix]";

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public static String Role => "[sec].[Role]";

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <value>
        /// The user profile.
        /// </value>
        public static String UserProfile => "[sec].[UserProfile]";

        // Staging tables

        /// <summary>
        /// Gets the active directory user.
        /// </summary>
        /// <value>
        /// The active directory user.
        /// </value>
        public static String ActiveDirectoryUser => "[stg].[ActiveDirectoryUser]";
    }
}
