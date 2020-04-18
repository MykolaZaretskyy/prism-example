using System;
using Prism.Test.Models;
using Prism.Test.Models.Items;
using Xamarin.Forms;

namespace Prism.Test.Views.TemplateSelectors
{
    public class MenuItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CategoryCellDataTemplate { get; set; }
        public DataTemplate MenuOptionCellDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case CategoryItemModel _:
                    return CategoryCellDataTemplate;
                case MenuOptionItemModel _:
                    return MenuOptionCellDataTemplate;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
