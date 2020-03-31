using System;
using System.Threading.Tasks;
using Prism.Test.Managers.Abstract;

namespace Prism.Test.Managers
{
    public class RightViewModelPropertyChangedHandler : IRightViewModelPropertyChangedHandler, ILeftViewModelPropertyChangedListener, ICenterViewModelPropertyChangedListener
    {
        public RightViewModelPropertyChangedHandler()
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

        Task<bool> ICenterViewModelPropertyChangedListener.OnPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
