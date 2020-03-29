using System.Threading.Tasks;

namespace Prism.Test
{
    public interface IViewModelPropertyChangedHandler
    {
        Task<bool> OnPropertyChanged(string propertyName);
    }
}
