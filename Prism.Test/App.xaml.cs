using Prism.Autofac;
using Prism.Ioc;
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

            //containerRegistry.RegisterSingleton<ICategoriesViewModel, CategoriesViewModel>();
            //containerRegistry.RegisterSingleton<ICategoryItemsViewModel, CategoryItemsViewModel>();
            //containerRegistry.RegisterSingleton<INutritionViewModel, YourOrderViewModel>();

            containerRegistry.RegisterSingleton<ICategoriesModel, CategoriesModel>();
            containerRegistry.RegisterSingleton<ICategoryItemsModel, CategoryItemsModel>();
        }
    }
}
