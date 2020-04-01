using Prism.Autofac;
using Prism.Ioc;
using Prism.Test.ViewModels;
using Prism.Test.ViewModels.Abstract;
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

            await NavigationService.NavigateAsync("HomeView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();

            containerRegistry.RegisterSingleton<ILeftViewModel, LeftViewModel>();
            containerRegistry.RegisterSingleton<ICenterViewModel, CenterViewModel>();
            containerRegistry.RegisterSingleton<IRightViewModel, RightViewModel>();
        }
    }
}
