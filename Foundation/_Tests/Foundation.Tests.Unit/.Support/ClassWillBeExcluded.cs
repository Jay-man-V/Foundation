//-----------------------------------------------------------------------
// <copyright file="ClassWillBeExcluded.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

// This class purposefully has a different namespace to the one the folder hierarchy suggests it should have
namespace Foundation.Tests.Unit.Support.ExcludedMe
{
    public interface IClassWillBeExcluded
    {
        Int32 CountAndGet();
    }

    public class ClassWillBeExcluded : IClassWillBeExcluded
    {
        private Int32 Count { get; set; } = 0;

        public Int32 CountAndGet()
        {
            Count++;

            return Count;
        }
    }
}