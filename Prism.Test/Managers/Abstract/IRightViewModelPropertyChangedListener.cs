using System.Threading.Tasks;

namespace Prism.Test.Managers.Abstract
{
    public interface IRightViewModelPropertyChangedListener : IViewModelPropertyChangedListener
    {
        Task<bool> OnPropertyChanged(string propertyName);
    }
}
