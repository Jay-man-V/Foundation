//-----------------------------------------------------------------------
// <copyright file="ApplicationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Sec
{
    /// <summary>
    /// The Application Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class ApplicationProcess : CommonBusinessProcess<IApplication, IApplicationRepository>, IApplicationProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        public ApplicationProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IApplicationRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.NullId"/>
        public new AppId NullId => new AppId(base.NullId.ToInteger());

        /// <inheritdoc cref="ICommonBusinessProcess.NoneId"/>
        public new AppId NoneId => new AppId(base.NoneId.ToInteger());

        /// <inheritdoc cref="ICommonBusinessProcess.AllId"/>
        public new AppId AllId => new AppId(base.AllId.ToInteger());

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Applications";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Applications:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.Application.Name;

        /// <inheritdoc cref="ICommonBusinessProcess{TModel}.GetBlankEntry" />
        protected override IApplication GetBlankEntry(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter(entityId);

            IApplication retVal = Core.IoC.Get<IApplication>();
            retVal.Id = new AppId(entityId.ToInteger());

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions(idColumnType: typeof(AppId));
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Application.Name, "Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Application.Description, "Description", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Get(EntityId)"/>
        public override IApplication Get(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter(entityId);

            IApplication retVal = Get(new AppId(entityId.TheEntityId));

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IApplicationProcess.Delete(AppId)"/>
        public void Delete(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            EntityRepository.Delete(applicationId);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IApplicationProcess.Get(AppId)"/>
        public IApplication Get(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            IApplication retVal = EntityRepository.Get(applicationId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
