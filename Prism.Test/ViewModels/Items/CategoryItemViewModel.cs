﻿using Prism.Mvvm;

namespace Prism.Test.ViewModels.Abstract.Items
{
    public class CategoryItemViewModel : BindableBase
    {
        private bool _isSelected;
        private string _categoryName;

        public CategoryItemViewModel()
        {
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }
    }
}