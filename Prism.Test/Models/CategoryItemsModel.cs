using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Features.GeneratedFactories;
using Prism.Mvvm;
using Prism.Test.Extensions;
using Prism.Test.Helpers;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;

namespace Prism.Test.Models
{
    public class CategoryItemsModel : BindableBase, ICategoryItemsModel
    {
        private MultiStateItemModel _focusedItem;

        public CategoryItemsModel()
        {
            
        }

        public MultiStateItemModel FocusedItem
        {
            get => _focusedItem;
            set => SetProperty(ref _focusedItem, value);
        }
    }
}
