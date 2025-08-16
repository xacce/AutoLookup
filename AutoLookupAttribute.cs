using System;

namespace AutoLookup
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class AutoLookupsAttribute : Attribute
    {
        public AutoLookupsAttribute(bool managed = false)
        {
            
        }
    }
}