using Prism.Autofac;
using Prism.Ioc;
using Prism.Test.Managers;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models;
using Prism.Test.Models.Abstract;
using Prism.Test.ViewModels;
using Prism.Test.Views;
using Xamarin.Forms;

namespace Prism.Test
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("MenuOrderingPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MenuOrderingPage, MenuOrderingPageViewModel>();

            containerRegistry.RegisterSingleton<ICategoriesModel, CategoriesModel>();
            containerRegistry.RegisterSingleton<IYourOrderModel, YourOrderModel>();
            containerRegistry.RegisterSingleton<ICategoriesManager, CategoriesManager>();
            containerRegistry.RegisterSingleton<IOrderManager, OrderManager>();
            
            containerRegistry.Register<CategoriesViewModel>();
            containerRegistry.Register<CategoryItemsViewModel>();
            containerRegistry.Register<YourOrderViewModel>();
        }
    }
}
