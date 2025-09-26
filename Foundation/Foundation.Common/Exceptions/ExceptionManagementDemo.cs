//-----------------------------------------------------------------------
// <copyright file="ExceptionManagementDemo.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// Simple class to demonstrate exception handling
    /// </summary>
    public class ExceptionManagementDemo
    {
        /// <summary>
        /// Method1.
        /// </summary>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <param name="throwNew">if set to <c>true</c> [throw new].</param>
        /// <exception cref="Exception">Failed in Method1</exception>
        public void Method1(Boolean throwException, Boolean throwNew)
        {
            try
            {
                Method2(throwException, throwNew);
            }
            catch (Exception exception)
            {
                if (throwNew)
                    throw new Exception("Failed in Method1", exception);
                else
                    throw;
            }
        }

        /// <summary>
        /// Method2.
        /// </summary>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <param name="throwNew">if set to <c>true</c> [throw new].</param>
        /// <exception cref="Exception">Failed in Method2</exception>
        private void Method2(Boolean throwException, Boolean throwNew)
        {
            try
            {
                Method3(throwException, throwNew);
            }
            catch (Exception exception)
            {
                if (throwNew)
                    throw new Exception("Failed in Method2", exception);
                else
                    throw;
            }
        }

        /// <summary>
        /// Method3.
        /// </summary>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <param name="throwNew">if set to <c>true</c> [throw new].</param>
        /// <exception cref="Exception">Failed in Method3</exception>
        private void Method3(Boolean throwException, Boolean throwNew)
        {
            try
            {
                Method4(throwException);
            }
            catch (Exception exception)
            {
                if (throwNew)
                    throw new Exception("Failed in Method3", exception);
                else
                    throw;
            }
        }

        /// <summary>
        /// Method4.
        /// </summary>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <exception cref="Exception">It broke in Method 4</exception>
        private void Method4(Boolean throwException)
        {
            if (throwException)
                throw new Exception("It broke in Method 4");
        }
    }
}
