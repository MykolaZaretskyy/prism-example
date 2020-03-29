using System.Threading.Tasks;

namespace Prism.Test
{
    public class LeftViewModelPropertyChangedHandler : ILeftViewModelPropertyChangedHandler
    {
        private readonly ILeftViewModel leftViewModel;
        private readonly ICenterViewModel centerViewModel;
        private readonly IRightViewModel rightViewModel;

        public LeftViewModelPropertyChangedHandler(ILeftViewModel leftViewModel,
            ICenterViewModel centerViewModel,
            IRightViewModel rightViewModel)
        {
            this.leftViewModel = leftViewModel;
            this.centerViewModel = centerViewModel;
            this.rightViewModel = rightViewModel;
        }

        public Task<bool> OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(ILeftViewModel.InputText):
                    centerViewModel.CenterText = leftViewModel.InputText;
                    return Task.FromResult(true);
                default:
                    return Task.FromResult(false);
            }
        }
    }
}
