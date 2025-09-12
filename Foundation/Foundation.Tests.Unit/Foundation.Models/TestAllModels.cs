//-----------------------------------------------------------------------
// <copyright file="TestAllModels.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Tests.Unit.Support;

using FEnums = Foundation.Interfaces;
using FModels = Foundation.Models;

namespace Foundation.Tests.Unit.Foundation.Models
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class TestAllModels : UnitTestBase
    {
        /// <summary>
        /// Tests each Model to ensure it has the correct base class
        /// </summary>
        [TestCase]
        public void Test_CheckModelBaseClass()
        {
            List<Type> modelTypes = GetListOfValidTypes();

            String expectedTypeName = typeof(FModels.FoundationModel).FullName!;

            foreach (Type modelType in modelTypes)
            {
                if (modelType == typeof(FModels.Specialised.GridColumnDefinition))
                {
                    continue;
                }

                String currentTypeName = modelType.FullName!;
                String modelTypeCheckErrorMessage = $"The Model: '{currentTypeName}' does not have the expected base class of '{expectedTypeName}'";

                String baseTypeName = modelType.BaseType!.FullName!;

                Assert.That(expectedTypeName, Is.EqualTo(baseTypeName), modelTypeCheckErrorMessage);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_CountModels()
        {
            List<Type> modelTypes = GetListOfValidTypes();

            Int32 index = 0;
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ActiveDirectoryUser)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Application)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ApplicationApplicationType)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ApplicationConfiguration)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ApplicationRole)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ApplicationType)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ApplicationUserRole)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ApprovalStatus)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ConfigurationScope)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ContactDetail)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ContactType)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Contract)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ContractType)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Country)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Currency)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Specialised.DatabaseSchemaColumn)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Specialised.DatabaseSchemaTable)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.DataStatus)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Department)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.EntityStatus)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.EventLog)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.EventLogApplication)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.EventLogAttachment)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Specialised.GridColumnDefinition)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.IdGenerator)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ImageType)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ImportExportControl)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Language)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.LoggedOnUser)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.LogSeverity)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.MenuItem)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.NationalRegion)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.NonWorkingDay)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Office)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.OfficeWeekCalendar)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.PermissionMatrix)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Role)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ScheduledDataStatus)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ScheduledJob)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.ScheduleInterval)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.Status)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.TaskStatus)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.TimeZone)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.UserProfile)));
            Assert.That(modelTypes[index++].Name, Is.EqualTo(nameof(FModels.WorldRegion)));

            Assert.That(modelTypes.Count, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the IEquatable interface on all Models
        /// </summary>
        [TestCase]
        public void Test_IEquatableInterface()
        {
            List<Type> modelTypes = GetListOfValidTypes();

            foreach (Type modelType in modelTypes)
            {
                if (modelType == typeof(FModels.Specialised.GridColumnDefinition))
                {
                    continue;
                }

                String currentTypeName = modelType.FullName!;
                Object modelInstance = Activator.CreateInstance(modelType)!;

                BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;

                PropertyInfo[] publicProperties = modelType.GetProperties(bindingFlags);

                foreach (PropertyInfo propertyInfo in publicProperties)
                {
                    String currentPublicProperty = propertyInfo.Name;
                    Type propertyType = propertyInfo.PropertyType;

                    if (propertyInfo.CanWrite)
                    {
                        //if (modelInstance is IDbSchemaTable)
                        {
                            // Set Property values for ones that we can handle
                            Object? expectedValue = SetPropertyValue(modelInstance, propertyInfo, propertyType);

                            Boolean ignorePropertyCheck = CanIgnorePropertyCheck(propertyType);

                            if (!ignorePropertyCheck)
                            {
                                String propertyCheckErrorMessage = $"Current Model: '{currentTypeName}'. Current Property: '{currentPublicProperty}'";
                                Assert.That(expectedValue, Is.Not.EqualTo(null), propertyCheckErrorMessage);
                            }
                        }
                    }
                }

                //if (modelInstance is FModels.EventLogAttachment)
                {
                    String errorMessage = $"Current Model: '{currentTypeName}'.";

                    ICloneable original = (ICloneable)modelInstance;
                    Object copy = original.Clone();

                    MethodInfo equatableEquals1MethodInfo = modelType.GetMethods().First(m => m.Name.Contains("Equals"));
                    Boolean equatableEquals1Result = (Boolean)equatableEquals1MethodInfo.Invoke(original, [ copy ])!;
                    Assert.That(equatableEquals1Result, Is.EqualTo(true), errorMessage);

                    MethodInfo getHashCodeMethodInfo = modelType.GetMethod(nameof(Object.GetHashCode), [])!;
                    Int32 hashCodeOriginal = (Int32)getHashCodeMethodInfo.Invoke(original, [])!;
                    Int32 hashCodeCopy = (Int32)getHashCodeMethodInfo.Invoke(copy, [])!;
                    Assert.That(hashCodeOriginal, Is.EqualTo(hashCodeCopy), errorMessage);

                    MethodInfo equalsMethodInfo1 = modelType.GetMethod(nameof(Object.Equals), [typeof(Object)])!;
                    MethodInfo equalsMethodInfo2 = modelType.GetMethod(nameof(Object.Equals), [modelType])!;

                    Boolean equalsMethod1Result = (Boolean)equalsMethodInfo1.Invoke(original, [copy])!;
                    Assert.That(equalsMethod1Result, Is.EqualTo(true), errorMessage);

                    Boolean equalsMethod2Result = (Boolean)equalsMethodInfo2.Invoke(original, [copy])!;
                    Assert.That(equalsMethod2Result, Is.EqualTo(true), errorMessage);

                    Boolean equalsMethod3Result = (Boolean)equalsMethodInfo2.Invoke(original, [null])!;
                    Assert.That(equalsMethod3Result, Is.EqualTo(false), errorMessage);
                }
            }
        }

        /// <summary>
        /// Tests the Clone method on all Models
        /// </summary>
        [TestCase]
        public void Test_CloneMethod()
        {
            List<Type> modelTypes = GetListOfValidTypes();

            foreach (Type modelType in modelTypes)
            {
                if (modelType == typeof(FModels.Specialised.GridColumnDefinition))
                {
                    continue;
                }

                String currentTypeName = modelType.FullName!;
                Object modelInstance = Activator.CreateInstance(modelType)!;

                PropertyInfo[] publicProperties = modelType.GetProperties();

                foreach (PropertyInfo propertyInfo in publicProperties)
                {
                    String currentPublicProperty = propertyInfo.Name;
                    Type propertyType = propertyInfo.PropertyType;

                    if (propertyInfo.CanWrite)
                    {
                        //if (modelInstance is IDbSchemaTable)
                        {
                            // Set Property values for ones that we can handle
                            Object? expectedValue = SetPropertyValue(modelInstance, propertyInfo, propertyType);

                            Boolean ignorePropertyCheck = CanIgnorePropertyCheck(propertyType);

                            if (!ignorePropertyCheck)
                            {
                                String errorMessage = $"Current Model: '{currentTypeName}'. Current Property: '{currentPublicProperty}'. Property Type: '{propertyType}'.";
                                Assert.That(expectedValue, Is.Not.EqualTo(null), errorMessage);
                            }
                        }
                    }
                }

                ICloneable original = (ICloneable)modelInstance;
                Object copy = original.Clone();

                Assert.That(copy, Is.EqualTo(copy));

                foreach (PropertyInfo propertyInfo in publicProperties)
                {
                    String currentPublicProperty = propertyInfo.Name;
                    Type propertyType = propertyInfo.PropertyType;

                    if (propertyInfo.CanWrite)
                    {
                        //if (modelInstance is IDbSchemaTable)
                        {
                            // Set Property values for ones that we can handle
                            Object? expectedValue = GetPropertyValue(original, propertyInfo);
                            Object? actualValue = GetPropertyValue(copy, propertyInfo);

                            String errorMessage = $"Current Model: '{currentTypeName}'. Current Property: '{currentPublicProperty}'. Property Type: '{propertyType}'.";

                            if (expectedValue is IList expectedList)
                            {
                                IList actualList = (IList)actualValue!;
                                Assert.That(expectedList, Is.EquivalentTo(actualList), errorMessage);
                            }
                            else
                            {
                                Assert.That(expectedValue, Is.EqualTo(actualValue), errorMessage);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tests the properties on all Models to make sure they are properly implemented
        /// </summary>
        [TestCase]
        public void Test_AllPropertiesInAllModels()
        {
            List<Type> modelTypes = GetListOfValidTypes();

            foreach (Type modelType in modelTypes)
            {
                if (modelType == typeof(FModels.Specialised.GridColumnDefinition))
                {
                    continue;
                }

                String currentTypeName = modelType.FullName!;

                Object modelInstance = Activator.CreateInstance(modelType)!;
                    
                IFoundationModel foundationModelInstance = (IFoundationModel)modelInstance;

                PropertyInfo[] publicProperties = modelType.GetProperties();

                foreach (PropertyInfo propertyInfo in publicProperties)
                {
                    String currentPublicProperty = propertyInfo.Name;
                    Type propertyType = propertyInfo.PropertyType;

                    String errorMessage = $"Current Model: '{currentTypeName}'. Current Property: '{currentPublicProperty}'";

                    if (errorMessage == "Current Model: 'Foundation.Models.Application'. Current Property: 'Id'")
                    {
                        Debug.Write(String.Empty);
                    }

                    // Check each property has the correct attributes
                    List<ColumnAttribute> columnAttributes = propertyInfo.GetCustomAttributes<ColumnAttribute>().ToList();
                    List<NotMappedAttribute> notMappedAttributes = propertyInfo.GetCustomAttributes<NotMappedAttribute>().ToList();

                    if (columnAttributes.Count == 1 && notMappedAttributes.Count == 0)
                    {
                        ColumnAttribute columnAttribute = columnAttributes[0];
                        Assert.That(columnAttribute.Name, Is.EqualTo(currentPublicProperty));
                    }
                    else if (columnAttributes.Count == 0 && notMappedAttributes.Count == 1)
                    {
                        // Nothing to check against
                        //NotMappedAttribute notMappedAttribute = notMappedAttributes[0];
                        //Assert.That(notMappedAttribute., Is.EqualTo(currentPublicProperty));
                    }
                    else
                    {
                        Assert.Fail($"{currentPublicProperty}. {errorMessage}. Property must have one of either the Column or NotMapped attribute applied");
                    }

                    if (propertyInfo.CanWrite)
                    {
                        // Set Property values for ones that we can handle
                        Object? expectedValue = SetPropertyValue(modelInstance, propertyInfo, propertyType);
                        Object? modelInstanceValue1 = GetPropertyValue(modelInstance, propertyInfo);
                        Object foundationInstanceValue2 = foundationModelInstance.GetPropertyValue(currentPublicProperty)!;

                        Boolean ignorePropertyCheck = CanIgnorePropertyCheck(propertyType);

                        if (!ignorePropertyCheck)
                        {
                            Assert.That(expectedValue, Is.Not.EqualTo(null), $"1 {errorMessage}");
                            Assert.That(modelInstanceValue1, Is.Not.EqualTo(null), $"2 {errorMessage}");
                            Assert.That(expectedValue, Is.EqualTo(modelInstanceValue1), $"3 {errorMessage}");

                            Boolean canIgnorePropertyCheckAgainstFoundationModel = CanIgnorePropertyCheckAgainstFoundationModel(modelInstance, propertyInfo, propertyType);

                            if (canIgnorePropertyCheckAgainstFoundationModel)
                            {
                                Assert.That(expectedValue, Is.EqualTo(foundationInstanceValue2), $"4 {errorMessage}");
                            }
                        }
                    }
                }

                if (modelInstance is IApplicationConfiguration applicationConfiguration)
                {
                    Assert.That(applicationConfiguration.ConfigurationScope, Is.EqualTo(ConfigurationScope.System));
                }

                if (modelInstance is IApplicationRole applicationRole)
                {
                    Assert.That(applicationRole.Role, Is.EqualTo(ApplicationRole.ReadOnly));
                }

                if (modelInstance is IEventLog eventLog)
                {
                    Assert.That(eventLog.LogSeverity, Is.EqualTo(LogSeverity.Trace));
                    Assert.That(eventLog.TaskStatus, Is.EqualTo(FEnums.TaskStatus.Success));
                }

                if (modelInstance is ILogSeverity logSeverity)
                {
                    Assert.That(logSeverity.Severity, Is.EqualTo(LogSeverity.Trace));
                }

                if (modelInstance is IRole role)
                {
                    Assert.That(role.ApplicationRole, Is.EqualTo(ApplicationRole.ReadOnly));
                }

                if (modelInstance is IScheduledDataStatus scheduledDataStatus)
                {
                    Assert.That(scheduledDataStatus.DataStatus, Is.EqualTo(DataStatus.InProgress));
                }

                if (modelInstance is IScheduledJob scheduledJob)
                {
                    scheduledJob.ParentScheduledJobs.AddRange([new EntityId(1), new EntityId(2), new EntityId(3), new EntityId(4), new EntityId(5), new EntityId(6)]);
                    scheduledJob.ChildScheduledJobs.AddRange([new EntityId(1), new EntityId(2), new EntityId(3), new EntityId(4), new EntityId(5), new EntityId(6)]);
                    Assert.That(scheduledJob.ScheduleInterval, Is.EqualTo(ScheduleInterval.Seconds));
                }
            }
        }

        private Boolean CanIgnorePropertyCheck(Type propertyType)
        {
            Boolean retVal = propertyType == typeof(IContractType) || propertyType == typeof(IContract);

            return retVal;
        }


        private Boolean CanIgnorePropertyCheckAgainstFoundationModel(Object modelInstance, PropertyInfo propertyInfo, Type propertyType)
        {
            Boolean typeCheck = modelInstance.GetType() == typeof(IApplication);
            Boolean propertyCheck = propertyInfo.Name == nameof(IApplication.Id);
            Boolean propertyTypeCheck = propertyType == typeof(AppId);

            Boolean retVal = typeCheck && propertyCheck && propertyTypeCheck;

            return retVal;
        }

        private List<Type> GetListOfValidTypes()
        {
            Type type = typeof(FModels.ActiveDirectoryUser);
            Assembly modelAssembly = type.Assembly;
            Type[] allModelTypes = modelAssembly.GetTypes();

            List<Type> retVal = allModelTypes.Where(t => !String.IsNullOrEmpty(t.FullName) &&
                                                         !String.IsNullOrEmpty(t.Namespace) &&
                                                         t.Namespace.StartsWith("Foundation.Models") &&
                                                         !t.FullName.Contains("DisplayClass") &&
                                                         !t.Attributes.HasFlag(TypeAttributes.Abstract)
                                                    ).OrderBy(t2 => t2.Name).ToList();

            return retVal;
        }

        private Object? SetPropertyValue(Object modelInstance, PropertyInfo propertyInfo, Type propertyType)
        {
            Object? retVal = null;

            if (propertyType == typeof(Object))
            {
                retVal = new Object();
            }
            else if (propertyType == typeof(Boolean))
            {
                retVal = false;
            }
            else if (propertyType == typeof(Byte))
            {
                retVal = 123;
            }
            else if (propertyType == typeof(Byte[]))
            {
                retVal = new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            }
            else if (propertyType == typeof(DateTime))
            {
                retVal = new DateTime(2019, 3, 15, 23, 20, 00);
            }
            else if (propertyType == typeof(DateTime?))
            {
                retVal = new DateTime(2019, 3, 15, 23, 20, 00);
            }
            else if (propertyType == typeof(Guid))
            {
                retVal = Guid.NewGuid();
            }
            else if (propertyType == typeof(Image))
            {
                retVal = new Bitmap(1, 1);
            }
            else if (propertyType == typeof(Int16))
            {
                retVal = Int16.MaxValue;
            }
            else if (propertyType == typeof(Int32))
            {
                retVal = 3; // Note: This value is also mapped to an Enum sometimes, be careful which value is selected
            }
            else if (propertyType == typeof(List<Int32>))
            {
                retVal = new List<Int32> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            }
            else if (propertyType == typeof(Int64))
            {
                retVal = Int64.MaxValue;
            }
            else if (propertyType == typeof(List<Int64>))
            {
                retVal = new List<Int64> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            }
            else if (propertyType == typeof(String))
            {
                MaxLengthAttribute? maxLengthAttribute = propertyInfo.GetCustomAttribute<MaxLengthAttribute>();
                Int32 maxLength = -1;
                if (maxLengthAttribute != null)
                {
                    maxLength = maxLengthAttribute.Length;
                }

                retVal = Guid.NewGuid().ToString();
                if (maxLength > -1)
                {
                    String tempString = retVal.ToString()!;
                    retVal = tempString.Substring(0, Math.Min(tempString.Length, maxLength));
                }
            }
            else if (propertyType == typeof(TimeSpan))
            {
                retVal = new TimeSpan(12, 34, 56);
            }
            else if (propertyType == typeof(Type))
            {
                retVal = typeof(Int32);
            }

            else if (propertyType == typeof(AppId))
            {
                retVal = new AppId(1);
            }
            else if (propertyType == typeof(EntityId))
            {
                retVal = new EntityId(1);
            }
            else if (propertyType == typeof(ApplicationRole))
            {
                retVal = ApplicationRole.Creator;
            }
            else if (propertyType == typeof(ConfigurationScope))
            {
                retVal = ConfigurationScope.System;
            }
            else if (propertyType == typeof(IContactDetail))
            {
                retVal = new FModels.ContactDetail { ShortName = Guid.NewGuid().ToString(), DisplayName = Guid.NewGuid().ToString() };
            }
            else if (propertyType == typeof(IContract))
            {
                retVal = new FModels.Contract { ContractReference = Guid.NewGuid().ToString(), ShortName = Guid.NewGuid().ToString(), FullName = Guid.NewGuid().ToString() };
            }
            else if (propertyType == typeof(IContractType))
            {
                retVal = new FModels.ContractType { Name = Guid.NewGuid().ToString(), Description = Guid.NewGuid().ToString() };
            }
            else if (propertyType == typeof(IList<IDatabaseSchemaColumn>))
            {
                retVal = new List<IDatabaseSchemaColumn>();
            }
            else if (propertyType == typeof(EmailAddress))
            {
                retVal = new EmailAddress("someone@nowhere.com");
            }
            else if (propertyType == typeof(List<EntityId>))
            {
                retVal = new List<EntityId> { new(1), new(2), new(3), new(4), new(5), new(6), new(7), new(8), new(9), new(10) };
            }
            else if (propertyType == typeof(EntityLife))
            {
                retVal = EntityLife.Deleted;
            }
            else if (propertyType == typeof(EntityState))
            {
                retVal = EntityState.Saved;
            }
            else if (propertyType == typeof(EntityStatus))
            {
                retVal = EntityStatus.Incomplete;
            }
            else if (propertyType == typeof(IFoundationModel))
            {
                retVal = new FModels.UserProfile();
            }
            else if (propertyType == typeof(LogId))
            {
                retVal = new LogId(1);
            }
            else if (propertyType == typeof(LogSeverity))
            {
                retVal = LogSeverity.Audit;
            }
            else if (propertyType == typeof(IList<IRole>))
            {
                retVal = new List<IRole>();
            }
            else if (propertyType == typeof(IEnumerable<IRole>))
            {
                retVal = new List<IRole>();
            }
            else if (propertyType == typeof(ScheduleInterval))
            {
                retVal = ScheduleInterval.Hours;
            }
            else if (propertyType == typeof(IScheduledTask))
            {
                retVal = Substitute.For<IScheduledTask>();
            }
            else if (propertyType == typeof(FEnums.TaskStatus))
            {
                retVal = FEnums.TaskStatus.Success;
            }

            propertyInfo.SetValue(modelInstance, retVal);

            return retVal;
        }

        private Object? GetPropertyValue(Object modelInstance, PropertyInfo propertyInfo)
        {
            Object? retVal = propertyInfo.GetValue(modelInstance);

            return retVal;
        }
    }
}
