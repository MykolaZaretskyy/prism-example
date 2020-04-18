using Prism.Test.Models.Abstract;

namespace Prism.Test.Models.Items
{
    public class OrderedItemModel : MultiStateItemModel
    {
        public OrderedItemModel(MenuOptionItemModel menuOption)
        {
            MenuOption = menuOption;
            Text = menuOption.Text;
        }

        public MenuOptionItemModel MenuOption { get; }
    }
}
