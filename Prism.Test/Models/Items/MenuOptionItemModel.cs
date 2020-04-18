using Prism.Test.Models.Abstract;

namespace Prism.Test.Models.Items
{
    public class MenuOptionItemModel : MultiStateItemModel
    {
        public MenuOptionItemModel(string displayName)
        {
            Text = displayName;
        }
    }
}
