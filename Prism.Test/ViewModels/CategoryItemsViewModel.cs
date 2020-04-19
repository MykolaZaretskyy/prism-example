using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Test.Extensions;
using Prism.Test.Helpers;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models;
using Prism.Test.Models.Abstract;
using Prism.Test.Models.Items;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class CategoryItemsViewModel : BaseSectionViewModel
    {
        private readonly ICategoriesModel _categoriesModel;
        private readonly ICategoriesManager _categoriesManager;
        private readonly List<IDisposable> _disposables;

        public CategoryItemsViewModel(ICategoriesModel categoriesModel, ICategoriesManager categoriesManager)
        {
            _categoriesModel = categoriesModel;
            _categoriesManager = categoriesManager;
            _disposables = new List<IDisposable>();
            ListItemSelectedCommand = new DelegateCommand<MultiStateItemModel>(OnItemSelected);
            MenuOptionCheckedCommand = new DelegateCommand<MenuOptionItemModel>(OnMenuOptionChecked);
            SubscribeToEvents();
        }

        public ICommand ListItemSelectedCommand { get; }

        public ICommand MenuOptionCheckedCommand { get; }

        public CustomObservableCollection<MultiStateItemModel> SubCategories { get; } = new CustomObservableCollection<MultiStateItemModel>();

        private void SubscribeToEvents()
        {
            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => _categoriesModel.PropertyChanged += h,
                    h => _categoriesModel.PropertyChanged -= h)
                .Where(x => x.EventArgs.PropertyName == nameof(ICategoriesModel.SelectedCategory))
                .Subscribe(_ => OnParentCategoryChanged())
                .DisposeWith(_disposables);
        }

        private void OnParentCategoryChanged()
        {
            SubCategories.ReplaceWith(_categoriesModel.SelectedCategory.AllItems);
        }

        private void OnItemSelected(MultiStateItemModel item)
        {
            _categoriesManager.OnFocusedItemChanged(item);
        }

        private void OnMenuOptionChecked(MenuOptionItemModel menuOption)
        {
            _categoriesManager.OnMenuOptionCheckedChanged(menuOption);
        }
    }
}
