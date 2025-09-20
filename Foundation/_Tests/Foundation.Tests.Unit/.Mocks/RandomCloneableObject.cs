//-----------------------------------------------------------------------
// <copyright file="RandomCloneableObject.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

namespace Foundation.Tests.Unit.Mocks
{
    public class RandomCloneableObject : ICloneable
    {
        public RandomCloneableObject() { Name = String.Empty; }
        public RandomCloneableObject(String name) { Name = name; }
        public String Name { get; set; }

        public Object Clone()
        {
            if (Activator.CreateInstance(this.GetType()) is not RandomCloneableObject retVal)
            {
                String message = $"The Type '{this.GetType()}' cannot be cloned but is calling {LocationUtils.GetFullyQualifiedFunctionName()}";
                throw new InvalidOperationException(message);
            }

            retVal.Name = this.Name;

            return retVal;
        }
    }
}
