using System;

namespace Prism.Test.Extensions
{
    public static class ObjectExtensions
    {
        public static object GetPropValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static Type GetPropType(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).PropertyType;
        }
    }
}
