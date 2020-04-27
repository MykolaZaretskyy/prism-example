using System.Collections.Generic;
using System.Linq;
using Prism.Test.Models.Abstract;
using Xamarin.Forms;

namespace Prism.Test.Models.Items
{
    public class CategoryItemModel : MultiStateItemModel
    {
        public CategoryItemModel(string displayName)
        {
            Text = displayName;
            SubCategories = new List<CategoryItemModel>();
            MenuOptions = new List<MenuOptionItemModel>();
        }

        public IList<CategoryItemModel> SubCategories { get; private set; }

        public IList<MenuOptionItemModel> MenuOptions { get; private set; }

        public CategoryItemModel PopulateWithData(int category, int level, bool includeSubCategories)
        {
            if (includeSubCategories)
            {
                for (var i = 0; i < 3; i++)
                {
                    SubCategories.Add(new CategoryItemModel($"Sub {i} of Category {category}, Level {level}"));
                }
            }

            for (var i = 0; i < 5; i++)
            {
                MenuOptions.Add(new MenuOptionItemModel($"Menu option {i} of Category {category}, Level {level}"));
            }

            return this;
        }
    }
}
