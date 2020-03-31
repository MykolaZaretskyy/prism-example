using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Test.Managers.Abstract;

namespace Prism.Test.Managers
{
    public class CenterViewModelPropertyChangedHandler : ICenterViewModelPropertyChangedHandler, ILeftViewModelPropertyChangedListener, IRightViewModelPropertyChangedListener
    {
        public CenterViewModelPropertyChangedHandler()
        {
        }

        public Task<bool> OnSelfPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }

        Task<bool> ILeftViewModelPropertyChangedListener.OnPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRightViewModelPropertyChangedListener.OnPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
