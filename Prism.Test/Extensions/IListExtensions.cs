using System.Collections.Generic;

namespace Prism.Test.Extensions
{
    public static class IListExtensions
    {
        public static void ReplaceWith<T>(this IList<T> source, IEnumerable<T> replacement)
        {
            source.Clear();
            foreach (var item in replacement)
            {
                source.Add(item);
            }
        }
    }
}
