using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Test.Extensions;
using Prism.Test.Helpers;
using Prism.Test.Managers.Abstract;
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
        private readonly List<IDisposable> _menuOptionsDisposables;
        private bool _isBackVisible;

        public CategoryItemsViewModel(ICategoriesModel categoriesModel, ICategoriesManager categoriesManager)
        {
            _categoriesModel = categoriesModel;
            _categoriesManager = categoriesManager;
            _disposables = new List<IDisposable>();
            _menuOptionsDisposables = new List<IDisposable>();
            ListItemSelectedCommand = new DelegateCommand<object>(HandleListItemSelected);
            BackCommand = new DelegateCommand(HandleBackCommand);
            SubscribeToEvents();
        }

        public ICommand ListItemSelectedCommand { get; }
        
        public ICommand BackCommand { get; }

        public CustomObservableCollection<object> CategoryItems { get; } = new CustomObservableCollection<object>();

        public bool IsBackVisible
        {
            get => _isBackVisible;
            set => SetProperty(ref _isBackVisible, value);
        }

        private void SubscribeToEvents()
        {
            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => _categoriesModel.PropertyChanged += h,
                    h => _categoriesModel.PropertyChanged -= h)
                .Where(x => x.EventArgs.PropertyName == nameof(ICategoriesModel.SelectedCategory))
                .Subscribe(_ => OnItemsChanged())
                .DisposeWith(_disposables);
            
            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => _categoriesModel.PropertyChanged += h,
                    h => _categoriesModel.PropertyChanged -= h)
                .Where(x => x.EventArgs.PropertyName == nameof(ICategoriesModel.SelectedSubCategory))
                .Subscribe(_ => OnItemsChanged())
                .DisposeWith(_disposables);
        }
        
        private void SubscribeMenuOptionsEvents()
        {
            var menuOptions = CategoryItems.OfType<MenuOptionItemModel>();
            foreach (var item in menuOptions)
            {
                Observable.FromEventPattern<EventHandler<EventArgs<MenuOptionItemModel>>, EventArgs<MenuOptionItemModel>>(
                        h => item.CheckedChanged += h,
                        h => item.CheckedChanged -= h)
                    .Subscribe(e => OnMenuOptionCheckedChanged(e.EventArgs.Data))
                    .DisposeWith(_menuOptionsDisposables);
            }
        }
        
        private void UnsubscribeMenuOptionsEvents()
        {
            _menuOptionsDisposables.DisposeAll();
        }

        private void OnItemsChanged()
        {
            IsBackVisible = _categoriesModel.SelectedSubCategory != null;
            if (CategoryItems.Any())
            {
                UnsubscribeMenuOptionsEvents();
            }
            
            CategoryItems.ReplaceWith(_categoriesModel.CategoryItems);
            SubscribeMenuOptionsEvents();
        }

        private void OnMenuOptionCheckedChanged(MenuOptionItemModel menuOption)
        {
            _categoriesManager.OnMenuOptionCheckedChanged(menuOption);
        }

        private void HandleListItemSelected(object item)
        {
            if (item is CategoryItemModel categoryItemModel)
            {
                _categoriesManager.OnSubCategorySelected(categoryItemModel);
            }
        }
        
        private void HandleBackCommand()
        {
            _categoriesManager.OnBackNavigation();
        }
    }
}
