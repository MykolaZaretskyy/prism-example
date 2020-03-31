using System.Threading.Tasks;

namespace Prism.Test.Managers.Abstract
{
    public interface ILeftViewModelPropertyChangedHandler : IViewModelPropertyChangedHandler
    {
        Task<bool> OnSelfPropertyChanged(string propertyName);
    }
}
