//-----------------------------------------------------------------------
// <copyright file="Common.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests
{
    /// <summary>
    /// The Message Formatter Tests
    /// </summary>
    public static class Common
    {
        internal static void NestedExceptionFirstMethod(Boolean throwAsNew)
        {
            try
            {
                NestedExceptionSecondMethod(throwAsNew);
            }
            catch (Exception exception)
            {
                if (throwAsNew)
                {
                    throw new Exception(nameof(NestedExceptionFirstMethod), exception);
                }
                else
                {
                    throw;
                }
            }
        }

        internal static void NestedExceptionSecondMethod(Boolean throwAsNew = true)
        {
            try
            {
                NestedExceptionThirdMethod(throwAsNew);
            }
            catch (Exception exception)
            {
                if (throwAsNew)
                {
                    throw new Exception(nameof(NestedExceptionSecondMethod), exception);
                }
                else
                {
                    throw;
                }
            }
        }

        internal static void NestedExceptionThirdMethod(Boolean throwAsNew = true)
        {
            try
            {
                throw new Exception("Something has broken.");
            }
            catch (Exception exception)
            {
                if (throwAsNew)
                {
                    throw new Exception("Ex3. P0:{0}. P1:{1}. P2:{2}.", exception);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
