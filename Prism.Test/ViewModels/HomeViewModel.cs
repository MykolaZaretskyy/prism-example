using System;
using System.ComponentModel;
using System.Reactive.Linq;
using Prism.Navigation;
using Prism.Test.Infrastracture;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IPropertyChangedDipatcher propertyChangedDipatcher;

        public HomeViewModel(INavigationService navigationService,
            ILeftViewModel leftViewModel,
            ICenterViewModel centerViewModel,
            IRightViewModel rightViewModel,
            IPropertyChangedDipatcher propertyChangedDipatcher) : base(navigationService)
        {
            LeftViewModel = (LeftViewModel)leftViewModel;
            CenterViewModel = (CenterViewModel)centerViewModel;
            RightViewModel = (RightViewModel)rightViewModel;

            this.propertyChangedDipatcher = propertyChangedDipatcher;
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
                .Subscribe(async p => await propertyChangedDipatcher.DispatchLeftViewModelChanged(p.EventArgs.PropertyName));

            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => CenterViewModel.PropertyChanged += h,
                    h => CenterViewModel.PropertyChanged -= h)
                //.ObserveOn(SynchronizationContext.Current)
                .Subscribe(async p => await propertyChangedDipatcher.DispatchCenterViewModelChanged(p.EventArgs.PropertyName));

            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => RightViewModel.PropertyChanged += h,
                    h => RightViewModel.PropertyChanged -= h)
                //.ObserveOn(SynchronizationContext.Current)
                .Subscribe(async p => await propertyChangedDipatcher.DispatchRightViewModelChanged(p.EventArgs.PropertyName));
        }
    }
}
