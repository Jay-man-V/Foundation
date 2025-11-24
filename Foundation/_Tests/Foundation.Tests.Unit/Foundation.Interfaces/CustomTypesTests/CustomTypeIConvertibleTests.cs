//-----------------------------------------------------------------------
// <copyright file="CustomTypeIConvertibleTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests
{
    /// <summary>
    /// Unit Tests for the Authentication Token type
    /// </summary>
    public class CustomTypeIConvertibleTests
    {
        public void Test_TypeCode(Object valueTypeToTest, TypeCode expectedTypeCode)
        {
            IConvertible convertible = (IConvertible)valueTypeToTest;
            TypeCode actualTypeCode = convertible.GetTypeCode();
            Assert.That(expectedTypeCode, Is.EqualTo(actualTypeCode));
        }

        public void Test_ToBoolean(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToBoolean(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToBoolean(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToByte(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToByte(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToByte(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToChar(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToChar(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToChar(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToDateTime(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToDateTime(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToDateTime(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToDecimal(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToDecimal(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToDecimal(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToDouble(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToDouble(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToDouble(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToInt16(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToInt16(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToInt16(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToInt32(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToInt32(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToInt32(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToInt64(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToInt64(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToInt64(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToSByte(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToSByte(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToSByte(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToSingle(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToSingle(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToSingle(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToString(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToString(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToString(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToType(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToType(typeof(Object), null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToType(typeof(Object), null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToUInt16(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToUInt16(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToUInt16(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToUInt32(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToUInt32(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToUInt32(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }

        public void Test_ToUInt64(Object valueTypeToTest, Object? expectedValue, Boolean canWork)
        {
            if (canWork)
            {
                IConvertible convertible = (IConvertible)valueTypeToTest;
                Object actualValue = convertible.ToUInt64(null);
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
            else
            {
                NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
                {
                    IConvertible convertible = (IConvertible)valueTypeToTest;
                    _ = convertible.ToUInt64(null);
                });
                Assert.That(actualException, Is.Not.EqualTo(null));
            }
        }
    }
}
