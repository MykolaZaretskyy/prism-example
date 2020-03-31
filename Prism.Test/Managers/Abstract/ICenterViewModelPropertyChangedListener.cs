using System.Threading.Tasks;

namespace Prism.Test.Managers.Abstract
{
    public interface ICenterViewModelPropertyChangedListener : IViewModelPropertyChangedListener
    {
        Task<bool> OnPropertyChanged(string propertyName);
    }
}
