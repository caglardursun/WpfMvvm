using Mailler.Model;
using Mailler.UI.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mailler.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {        
        public MainViewModel(INavigationViewModel navigationViewModel,IContactDetailViewModel contactDetailModel)
        {
            NavigationViewModel = navigationViewModel;
            ContactDetailViewModel = contactDetailModel;
        }

        public void Load()
        {
            NavigationViewModel.Load();
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IContactDetailViewModel ContactDetailViewModel { get; }
    }
    
}
