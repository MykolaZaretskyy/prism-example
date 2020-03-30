using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Test.Managers.Abstract;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.Managers
{
    public class CenterViewModelPropertyChangedHandler : ICenterViewModelPropertyChangedHandler
    {
        public CenterViewModelPropertyChangedHandler()
        {
        }

        public Task<bool> OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine($"CurrentThreadId = {Environment.CurrentManagedThreadId}");
            return Task.FromResult(false);
        }
    }
}
