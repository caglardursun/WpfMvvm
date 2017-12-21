using Mailler.Model;
using Mailler.UI.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Mailler.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {        
        public MainViewModel(INavigationViewModel navigationViewModel,
            IContactDetailViewModel contactDetailModel)
        {
            NavigationViewModel = navigationViewModel;
            ContactDetailViewModel = contactDetailModel;
        }

        public async Task Load()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IContactDetailViewModel ContactDetailViewModel { get; }
    }
    
}
