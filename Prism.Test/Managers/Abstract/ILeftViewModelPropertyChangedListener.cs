using System.Threading.Tasks;

namespace Prism.Test.Managers.Abstract
{
    public interface ILeftViewModelPropertyChangedListener : IViewModelPropertyChangedListener
    {
        Task<bool> OnPropertyChanged(string propertyName);
    }
}
