using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Test.Managers.Abstract;

namespace Prism.Test.Managers
{
    public class RightViewModelPropertyChangedHandler : IRightViewModelPropertyChangedHandler
    {
        public RightViewModelPropertyChangedHandler()
        {
        }

        public Task<bool> OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine($"CurrentThreadId = {Environment.CurrentManagedThreadId}");
            return Task.FromResult(false);
        }
    }
}
