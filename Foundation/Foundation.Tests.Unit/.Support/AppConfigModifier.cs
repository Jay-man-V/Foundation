////-----------------------------------------------------------------------
//// <copyright file="AppConfigModifier.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Reflection;

//using Foundation.Common;

//namespace Foundation.Tests.Unit.Support
//{
//    /// <summary>
//    /// The App Config Modifier class
//    /// </summary>
//    public class AppConfigModifier : IDisposable
//    {
//        /// <summary>
//        /// Initialises a new instance of the <see cref="AppConfigModifier"/> class.
//        /// </summary>
//        /// <param name="appConfigFile">The application configuration file.</param>
//        public AppConfigModifier(String appConfigFile)
//        {
//            OldConfig = AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString();
//            TargetDomain = AppDomain.CreateDomain("UnitTesting", null, AppDomain.CurrentDomain.SetupInformation);

//            FileInfo fi = new FileInfo(OldConfig);
//            String newConfig = Path.Combine(fi.DirectoryName, appConfigFile);

//            TargetDomain.SetData("APP_CONFIG_FILE", newConfig);
//            ResetConfigMechanism();
//        }

//        /// <summary>
//        /// Gets or sets a value indicating whether [disposed value].
//        /// </summary>
//        /// <value>
//        ///   <c>true</c> if [disposed value]; otherwise, <c>false</c>.
//        /// </value>
//        private Boolean DisposedValue { get; set; }

//        /// <summary>
//        /// Gets or sets the old configuration.
//        /// </summary>
//        /// <value>
//        /// The old configuration.
//        /// </value>
//        private String OldConfig { get; }

//        /// <summary>
//        /// Gets the target domain.
//        /// </summary>
//        /// <value>
//        /// The target domain.
//        /// </value>
//        public AppDomain TargetDomain { get; }

//        /// <summary>
//        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
//        /// </summary>
//        public void Dispose()
//        {
//            if (!DisposedValue)
//            {
//                TargetDomain.SetData("APP_CONFIG_FILE", OldConfig);
//                ResetConfigMechanism();

//                AppDomain.Unload(TargetDomain);

//                DisposedValue = true;
//            }

//            GC.SuppressFinalize(this);
//        }

//        /// <summary>
//        /// Resets the configuration mechanism.
//        /// </summary>
//        private static void ResetConfigMechanism()
//        {
//            Type configurationManagerType = typeof(ConfigurationManager);
//            FieldInfo initStateFieldInfo = configurationManagerType.GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static);
//            if (initStateFieldInfo != null)
//            {
//                initStateFieldInfo.SetValue(null, 0);
//            }

//            FieldInfo configSystemFieldInfo = configurationManagerType.GetField("s_configSystem", BindingFlags.NonPublic | BindingFlags.Static);
//            if (configSystemFieldInfo != null)
//            {
//                configSystemFieldInfo.SetValue(null, null);
//            }

//            Assembly currentAssembly = configurationManagerType.Assembly;
//            Type[] allTypes = currentAssembly.GetTypes();

//            Type clientConfigPathsType = allTypes.First(x => x.FullName == "System.Configuration.ClientConfigPaths");

//            FieldInfo currentFieldInfo = clientConfigPathsType.GetField("s_current", BindingFlags.NonPublic | BindingFlags.Static);
//            if (currentFieldInfo != null)
//            {
//                currentFieldInfo.SetValue(null, null);
//            }
//        }
//    }
//}
