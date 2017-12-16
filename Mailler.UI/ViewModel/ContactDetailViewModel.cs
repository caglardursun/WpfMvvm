using Mailler.Model;
using Mailler.UI.Data;
using Mailler.UI.Event;
using Mailler.UI.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.ViewModel
{
    public class ContactDetailViewModel : ViewModelBase, IContactDetailViewModel
    {
        private IContactDataService _dataService;

        private IEventAggregator _eventAggregator;

        private Contact _contact;

        public ContactDetailViewModel(IContactDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenContactDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);
        }

        private void OnOpenFriendDetailView(int contactId)
        {
            Load(contactId);
        }

        public void Load(int contactId)
        {
            Contact = _dataService.GetById(contactId).First();
        }
        
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                OnPropertyChanged();
            }
        }

    }
}
