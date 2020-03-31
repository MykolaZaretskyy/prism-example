using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Test.Managers.Abstract;

namespace Prism.Test.Infrastracture
{
    public class PropertyChangedDipatcher : IPropertyChangedDipatcher
    {
        private readonly ILeftViewModelPropertyChangedHandler leftViewModelPropertyChangedHandler;
        private readonly ICenterViewModelPropertyChangedHandler centerViewModelPropertyChangedHandler;
        private readonly IRightViewModelPropertyChangedHandler rightViewModelPropertyChangedHandler;
        private readonly List<ILeftViewModelPropertyChangedListener> leftViewModelListeners;
        private readonly List<ICenterViewModelPropertyChangedListener> centerViewModelListeners;
        private readonly List<IRightViewModelPropertyChangedListener> rightViewModelListeners;

        public PropertyChangedDipatcher(ILeftViewModelPropertyChangedHandler leftViewModelPropertyChangedHandler,
            ICenterViewModelPropertyChangedHandler centerViewModelPropertyChangedHandler,
            IRightViewModelPropertyChangedHandler rightViewModelPropertyChangedHandler)
        {
            this.leftViewModelPropertyChangedHandler = leftViewModelPropertyChangedHandler;
            this.centerViewModelPropertyChangedHandler = centerViewModelPropertyChangedHandler;
            this.rightViewModelPropertyChangedHandler = rightViewModelPropertyChangedHandler;

            leftViewModelListeners = new List<IViewModelPropertyChangedHandler>
            {
                centerViewModelPropertyChangedHandler,
                rightViewModelPropertyChangedHandler
            }.Cast<ILeftViewModelPropertyChangedListener>().ToList();

            centerViewModelListeners = new List<IViewModelPropertyChangedHandler>
            {
                leftViewModelPropertyChangedHandler,
                rightViewModelPropertyChangedHandler
            }.Cast<ICenterViewModelPropertyChangedListener>().ToList();

            rightViewModelListeners = new List<IViewModelPropertyChangedHandler>
            {
                leftViewModelPropertyChangedHandler,
                centerViewModelPropertyChangedHandler
            }.Cast<IRightViewModelPropertyChangedListener>().ToList();
        }

        public async Task DispatchLeftViewModelChanged(string propertyName)
        {
            await centerViewModelPropertyChangedHandler.OnSelfPropertyChanged(propertyName);
            centerViewModelListeners.ForEach(a => a.OnPropertyChanged(propertyName));
        }

        public async Task DispatchCenterViewModelChanged(string propertyName)
        {
            await leftViewModelPropertyChangedHandler.OnSelfPropertyChanged(propertyName);
            leftViewModelListeners.ForEach(a => a.OnPropertyChanged(propertyName));
        }

        public async Task DispatchRightViewModelChanged(string propertyName)
        {
            await rightViewModelPropertyChangedHandler.OnSelfPropertyChanged(propertyName);
            rightViewModelListeners.ForEach(a => a.OnPropertyChanged(propertyName));
        }
    }
}
