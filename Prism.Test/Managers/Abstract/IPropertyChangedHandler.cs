namespace Prism.Test.Managers.Abstract
{
    public interface IPropertyChangedHandler<in TViewModel>
    {
        void Initialize(TViewModel source);
    }
}
