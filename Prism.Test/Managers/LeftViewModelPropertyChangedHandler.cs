using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Test.Managers.Abstract;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.Managers
{
    public class LeftViewModelPropertyChangedHandler : ILeftViewModelPropertyChangedHandler, ICenterViewModelPropertyChangedListener, IRightViewModelPropertyChangedListener
    {
        private readonly ILeftViewModel leftViewModel;

        public LeftViewModelPropertyChangedHandler(ILeftViewModel leftViewModel)
        {
            this.leftViewModel = leftViewModel;
        }

        public Task<bool> OnSelfPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICenterViewModelPropertyChangedListener.OnPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRightViewModelPropertyChangedListener.OnPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
