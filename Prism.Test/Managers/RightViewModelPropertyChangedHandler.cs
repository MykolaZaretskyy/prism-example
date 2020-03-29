using System;
using System.Threading.Tasks;

namespace Prism.Test
{
    public class RightViewModelPropertyChangedHandler : IRightViewModelPropertyChangedHandler
    {
        public RightViewModelPropertyChangedHandler()
        {
        }

        public Task<bool> OnPropertyChanged(string propertyName)
        {
            return Task.FromResult(false);
        }
    }
}
