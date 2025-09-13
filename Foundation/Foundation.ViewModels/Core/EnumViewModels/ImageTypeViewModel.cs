//-----------------------------------------------------------------------
// <copyright file="ImageTypeViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core.EnumViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Image Type maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IImageType}" />
    [DependencyInjectionTransient]
    public class ImageTypeViewModel : GenericDataGridViewModelBase<IImageType>, IImageTypeViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ImageTypeViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="imageTypeProcess">The image type process.</param>
        public ImageTypeViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IImageTypeProcess imageTypeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                imageTypeProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, imageTypeProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
