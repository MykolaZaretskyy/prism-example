using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Test.Helpers;
using Prism.Test.Models.Abstract;

namespace Prism.Test.Models.Items
{
    public class MenuOptionItemModel : MultiStateItemModel
    {
        public MenuOptionItemModel(string displayName)
        {
            Text = displayName;
            CheckedChangedCommand = new DelegateCommand<bool>(OnCheckedChanged);
        }

        public event EventHandler<EventArgs<MenuOptionItemModel>> CheckedChanged; 
        
        public ICommand CheckedChangedCommand { get; }
        
        private void OnCheckedChanged(bool isChecked)
        {
            CheckedChanged?.Invoke(this, new EventArgs<MenuOptionItemModel>(this));
        }
    }
}
