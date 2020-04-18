using Prism.Mvvm;

namespace Prism.Test.Models.Abstract
{
    public class MultiStateItemModel : BindableBase
    {
        private ListItemState _state;
        private string _text;

        public ListItemState State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
