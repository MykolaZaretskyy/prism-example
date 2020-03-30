using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Test.Managers.Abstract;
using Prism.Test.ViewModels.Abstract;

namespace Prism.Test.Managers
{
    public class LeftViewModelPropertyChangedHandler : ILeftViewModelPropertyChangedHandler
    {
        private readonly ILeftViewModel leftViewModel;
        private readonly ICenterViewModel centerViewModel;
        private readonly IRightViewModel rightViewModel;

        public LeftViewModelPropertyChangedHandler(ILeftViewModel leftViewModel, ICenterViewModel centerViewModel,
            IRightViewModel rightViewModel)
        {
            this.leftViewModel = leftViewModel;
            this.centerViewModel = centerViewModel;
            this.rightViewModel = rightViewModel;
        }

        public Task<bool> OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine($"CurrentThreadId = {Environment.CurrentManagedThreadId}");
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
