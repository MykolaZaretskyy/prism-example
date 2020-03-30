using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Threading;
using Prism.Navigation;
using Prism.Test.Managers.Abstract;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ILeftViewModelPropertyChangedHandler leftViewModelPropertyChangedHandler;
        private readonly ICenterViewModelPropertyChangedHandler centerViewModelPropertyChangedHandler;
        private readonly IRightViewModelPropertyChangedHandler rightViewModelPropertyChangedHandler;

        public HomeViewModel(INavigationService navigationService,
            ILeftViewModel leftViewModel,
            ICenterViewModel centerViewModel,
            IRightViewModel rightViewModel,
            ILeftViewModelPropertyChangedHandler leftViewModelPropertyChangedHandler,
            ICenterViewModelPropertyChangedHandler centerViewModelPropertyChangedHandler,
            IRightViewModelPropertyChangedHandler rightViewModelPropertyChangedHandler) : base(navigationService)
        {
            this.leftViewModelPropertyChangedHandler = leftViewModelPropertyChangedHandler;
            this.centerViewModelPropertyChangedHandler = centerViewModelPropertyChangedHandler;
            this.rightViewModelPropertyChangedHandler = rightViewModelPropertyChangedHandler;

            LeftViewModel = (LeftViewModel)leftViewModel;
            CenterViewModel = (CenterViewModel)centerViewModel;
            RightViewModel = (RightViewModel)rightViewModel;
        }

        public LeftViewModel LeftViewModel { get; }

        public CenterViewModel CenterViewModel { get; }

        public RightViewModel RightViewModel { get; }

        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();

            //Add composite disposables and unsubscriptions
            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => LeftViewModel.PropertyChanged += h,
                    h => LeftViewModel.PropertyChanged -= h)
                //.ObserveOn(SynchronizationContext.Current)
                .Subscribe(async p =>
                {
                    await leftViewModelPropertyChangedHandler.OnPropertyChanged(p.EventArgs.PropertyName);
                });

            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => CenterViewModel.PropertyChanged += h,
                    h => CenterViewModel.PropertyChanged -= h)
                //.ObserveOn(SynchronizationContext.Current)
                .Subscribe(async p =>
                    await centerViewModelPropertyChangedHandler.OnPropertyChanged(p.EventArgs.PropertyName));

            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => RightViewModel.PropertyChanged += h,
                    h => RightViewModel.PropertyChanged -= h)
                //.ObserveOn(SynchronizationContext.Current)
                .Subscribe(async p =>
                    await rightViewModelPropertyChangedHandler.OnPropertyChanged(p.EventArgs.PropertyName));
        }
    }
}
