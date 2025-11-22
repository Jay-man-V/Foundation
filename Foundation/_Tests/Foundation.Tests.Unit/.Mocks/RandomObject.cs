//-----------------------------------------------------------------------
// <copyright file="RandomObject.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.Unit.Mocks
{
    public class RandomObject
    {
        static RandomObject()
        {
            Index++;
        }

        public static Int32 Index { get; }

        public RandomObject() : this(String.Empty)
        {
        }

        public RandomObject(String name)
        {
            Id = Index;
            Name = name;
        }

        public Int32 Id { get; }
        public String Name { get; set; }

        public override string ToString()
        {
            String retVal = $"'{Id}' - '{Name}'";
            return retVal;
        }
    }
}
