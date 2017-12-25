using Mailler.UI.Event;
using Mailler.UI.View.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mailler.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {


        
        private Func<IContactDetailViewModel> _contactDetailModelCreator;
        private IMessageDialogServices _messageDialogServices;
        private IContactDetailViewModel contactDetailViewModel;
        private IEventAggregator _eventAggregator;

        public INavigationViewModel NavigationViewModel { get; }
        public IContactDetailViewModel ContactDetailViewModel
        {
            get { return contactDetailViewModel; }
            private set { contactDetailViewModel = value; OnPropertyChanged(); }
        }


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

            CreateNewContactCommand = new DelegateCommand(OnCreateNewContact);

            NavigationViewModel = navigationViewModel;
        }

        public ICommand CreateNewContactCommand { get; }
        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
        
        private async void OnOpenFriendDetailView(int? contactId)
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

        private void OnCreateNewContact()
        {
            OnOpenFriendDetailView(null);
        }
    }
    
}
