using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Xml.Linq;
using kursach.Views;

namespace kursach.ViewModels
{
    public partial class MenuShellViewModel : ObservableObject
    {
        [ObservableProperty] public string _userEmail;

        public MenuShellViewModel()
        {
        }

    }
}
