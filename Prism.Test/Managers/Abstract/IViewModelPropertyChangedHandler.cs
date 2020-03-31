using System.Threading.Tasks;

namespace Prism.Test.Managers.Abstract
{
    public interface IViewModelPropertyChangedHandler
    {
        Task<bool> OnSelfPropertyChanged(string propertyName);
    }
}