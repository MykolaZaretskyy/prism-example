using System;
using System.ComponentModel;
using System.Reactive.Linq;
using Prism.Navigation;
using Prism.Test.Extensions;
using Prism.Test.Helpers.EventRaiser;
using Prism.Test.Managers.Abstract;
using Prism.Test.Models.Events;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ILeftViewModelPropertyChangedHandler _leftViewModelPropertyChangedHandler;
        private readonly ICenterViewModelPropertyChangedHandler _centerViewModelPropertyChangedHandler;
        private readonly IRightViewModelPropertyChangedHandler _rightViewModelPropertyChangedHandler;
        private readonly IEventRaiser _eventRaiser;

        public HomeViewModel(INavigationService navigationService,
            ILeftViewModel leftViewModel,
            ICenterViewModel centerViewModel,
            IRightViewModel rightViewModel,
            IEventRaiser eventRaiser,
            ILeftViewModelPropertyChangedHandler leftViewModelPropertyChangedHandler,
            ICenterViewModelPropertyChangedHandler centerViewModelPropertyChangedHandler,
            IRightViewModelPropertyChangedHandler rightViewModelPropertyChangedHandler) : base(navigationService)
        {
            _leftViewModelPropertyChangedHandler = leftViewModelPropertyChangedHandler;
            _centerViewModelPropertyChangedHandler = centerViewModelPropertyChangedHandler;
            _rightViewModelPropertyChangedHandler = rightViewModelPropertyChangedHandler;
            _eventRaiser = eventRaiser;

            LeftViewModel = (LeftViewModel) leftViewModel;
            CenterViewModel = (CenterViewModel) centerViewModel;
            RightViewModel = (RightViewModel) rightViewModel;
        }

        public LeftViewModel LeftViewModel { get; }

        public CenterViewModel CenterViewModel { get; }

        public RightViewModel RightViewModel { get; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _leftViewModelPropertyChangedHandler.Initialize(LeftViewModel);
            _centerViewModelPropertyChangedHandler.Initialize(CenterViewModel);
            _rightViewModelPropertyChangedHandler.Initialize(RightViewModel);
        }

        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();

            //Add composite disposables and unsubscriptions
            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => LeftViewModel.PropertyChanged += h,
                    h => LeftViewModel.PropertyChanged -= h)
                .Subscribe(p => _eventRaiser.RaiseLeftEvent(EventPayload.Create(p.EventArgs.PropertyName,
                    LeftViewModel.GetPropValue(p.EventArgs.PropertyName))));

            Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => CenterViewModel.PropertyChanged += h,
                    h => CenterViewModel.PropertyChanged -= h)
                .Subscribe(p => _eventRaiser.RaiseCenterEvent(EventPayload.Create(p.EventArgs.PropertyName,
                    CenterViewModel.GetPropValue(p.EventArgs.PropertyName))));

            //Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
            //        h => RightViewModel.PropertyChanged += h,
            //        h => RightViewModel.PropertyChanged -= h)
            //    //.ObserveOn(SynchronizationContext.Current)
            //    .Subscribe(async p => await _propertyChangedDispatcher.DispatchRightViewModelChanged(p.EventArgs.PropertyName));
        }
    }
}
