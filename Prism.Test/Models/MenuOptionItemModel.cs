using Prism.Mvvm;
using Prism.Test.Models.Abstract;

namespace Prism.Test.Models
{
    public class MenuOptionItemModel : MultiStateItemModel
    {
        public MenuOptionItemModel(string displayName)
        {
            Text = displayName;
        }
    }
}
