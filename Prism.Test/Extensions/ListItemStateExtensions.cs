using Prism.Test.Models.Abstract;

namespace Prism.Test.Extensions
{
    public static class ListItemStateExtensions
    {
        public static void AddFlag(this ListItemState flags, ListItemState flagToAdd)
        {
            flags = flags | flagToAdd;
        }

        public static void RemoveFlag(this ListItemState flags, ListItemState flagToRemove)
        {
            flags = flags &= ~flagToRemove;
        }
    }
}
