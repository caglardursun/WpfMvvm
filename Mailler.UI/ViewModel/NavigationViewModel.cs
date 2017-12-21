using Mailler.Model;
using Mailler.UI.Data;
using Mailler.UI.Data.LookUps;
using Mailler.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ILookUpContactDataService _contactLookupService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(ILookUpContactDataService contactLookupService, 
            IEventAggregator eventAggregator)
        {
            _contactLookupService = contactLookupService;
            _eventAggregator = eventAggregator;
            Contacts = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterContactSaveEvent>().Subscribe(AfterContactSave);
        }

        private void AfterContactSave(AfterContactSaveEventArgs obj)
        {
            var lookupItem = Contacts.Single(l => l.Id == obj.Id);
            lookupItem.DisplayMember = obj.DisplayMember;
            
        }

        public async Task LoadAsync()
        {
            var lookUp = await _contactLookupService.GetContactLookUpAsync();
            Contacts.Clear();
            foreach (var item in lookUp)
            {
                Contacts.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }


        public ObservableCollection<NavigationItemViewModel> Contacts { get; }

        private NavigationItemViewModel _selectedContact;

        public NavigationItemViewModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
                if (_selectedContact != null)
                {
                    _eventAggregator
                        .GetEvent<OpenContactDetailViewEvent>()
                        .Publish(_selectedContact.Id);
                }
            }
        }


    }
}
