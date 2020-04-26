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
        
        public CategoryItemModel PopulateWithData(string text)
        {
            SubCategories = new List<CategoryItemModel>
            {
                new CategoryItemModel($"Subcategory 1 of {text}"),
                new CategoryItemModel($"Subcategory 2 of {text}"),
                new CategoryItemModel($"Subcategory 3 of {text}"),
            };

            MenuOptions = new List<MenuOptionItemModel>
            {
                new MenuOptionItemModel($"Menu option 1 of {text}"),
                new MenuOptionItemModel($"Menu option 2 of {text}"),
                new MenuOptionItemModel($"Menu option 3 of {text}"),
                new MenuOptionItemModel($"Menu option 4 of {text}"),
                new MenuOptionItemModel($"Menu option 5 of {text}"),
            };

            return this;
        }
    }
}
