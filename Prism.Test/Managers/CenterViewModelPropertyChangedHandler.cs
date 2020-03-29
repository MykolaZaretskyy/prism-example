using System.Threading.Tasks;

namespace Prism.Test
{
    public class CenterViewModelPropertyChangedHandler : ICenterViewModelPropertyChangedHandler
    {
        public CenterViewModelPropertyChangedHandler()
        {
        }

        public Task<bool> OnPropertyChanged(string propertyName)
        {
            return Task.FromResult(false);
        }
    }
}
