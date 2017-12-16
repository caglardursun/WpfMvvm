using Mailler.Model;
using Mailler.UI.Data;
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
            Contacts = new ObservableCollection<LookUpItem>();
        }

        public void Load()
        {
            var lookUp = _contactLookupService.GetContactLookUp();
            Contacts.Clear();
            foreach (var item in lookUp)
            {
                Contacts.Add(item);
            }
        }

        public ObservableCollection<LookUpItem> Contacts { get; }
        private LookUpItem _selectedContact;

        public LookUpItem SelectedContact
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
