using System.Threading.Tasks;

namespace Prism.Test.Infrastracture
{
    public interface IPropertyChangedDipatcher
    {
        Task DispatchLeftViewModelChanged(string propertyName);

        Task DispatchCenterViewModelChanged(string propertyName);

        Task DispatchRightViewModelChanged(string propertyName);
    }
}
