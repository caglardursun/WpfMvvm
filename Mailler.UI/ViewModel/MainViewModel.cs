using Mailler.UI.Event;
using Mailler.UI.View.Services;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace Mailler.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {        
        public MainViewModel(INavigationViewModel navigationViewModel,
            Func<IContactDetailViewModel> contactDetailModelCreator,
            IEventAggregator eventAggregator, 
            IMessageDialogServices messageDialogServices)
        {
            
            
            
            _eventAggregator = eventAggregator;
            _contactDetailModelCreator = contactDetailModelCreator;
            _messageDialogServices = messageDialogServices;
            _eventAggregator.GetEvent<OpenContactDetailViewEvent>()
                            .Subscribe(OnOpenFriendDetailView);


            NavigationViewModel = navigationViewModel;
        }

        public async Task Load()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }

        private Func<IContactDetailViewModel> _contactDetailModelCreator;
        private IMessageDialogServices _messageDialogServices;
        private IContactDetailViewModel contactDetailViewModel;

        public IContactDetailViewModel ContactDetailViewModel
        {
            get { return contactDetailViewModel; }
            private set { contactDetailViewModel = value; OnPropertyChanged(); }
        }


        private IEventAggregator _eventAggregator;


        private async void OnOpenFriendDetailView(int contactId)
        {
            if (ContactDetailViewModel != null && ContactDetailViewModel.HasChanges)
            {
                var result = _messageDialogServices.ShowOkCancelDialog("You Va made changes. Navigate away ?", "Info");
                if (result == MessageDialogResult.Cancel)
                    return;
            }

            ContactDetailViewModel = _contactDetailModelCreator();
            await ContactDetailViewModel.LoadAsync(contactId);
        }

    }
    
}
