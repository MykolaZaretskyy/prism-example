using System;

namespace Prism.Test.Models.Abstract
{
    [Flags]
    public enum ListItemState
    {
        None = 0,
        Focused = 0x1,
        Selected = 0x2,
    }
}
