using System.Collections.Generic;
using System.Linq;
using Prism.Test.Models.Abstract;

namespace Prism.Test.Models.Items
{
    public class CategoryItemModel : MultiStateItemModel
    {
        public CategoryItemModel(string displayName)
        {
            Text = displayName;
        }

        public IList<CategoryItemModel> SubCategories { get; private set; }

        public IList<MenuOptionItemModel> MenuOptions { get; private set; }

        public IEnumerable<MultiStateItemModel> AllItems => SubCategories?.Concat(MenuOptions.Cast<MultiStateItemModel>());

        public CategoryItemModel PopulateWithData()
        {
            SubCategories = new List<CategoryItemModel>
            {
                new CategoryItemModel($"Subcategory 1 of {Text}"),
                new CategoryItemModel($"Subcategory 2 of {Text}"),
                new CategoryItemModel($"Subcategory 3 of {Text}"),
            };

            MenuOptions = new List<MenuOptionItemModel>
            {
                new MenuOptionItemModel($"Menu option 1 of {Text}"),
                new MenuOptionItemModel($"Menu option 2 of {Text}"),
                new MenuOptionItemModel($"Menu option 3 of {Text}"),
                new MenuOptionItemModel($"Menu option 4 of {Text}"),
                new MenuOptionItemModel($"Menu option 5 of {Text}"),
            };

            return this;
        }
    }
}
