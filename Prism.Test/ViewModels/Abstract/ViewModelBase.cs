using Prism.Mvvm;
using Prism.Navigation;

namespace Prism.Test
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        // INavigationAware
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        // INavigationAware
        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        // INavigationAware
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        // IDestructible
        public virtual void Destroy()
        {
        }
    }
}
