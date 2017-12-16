using Mailler.Model;
using Mailler.UI.Data;
using Mailler.UI.Event;
using Mailler.UI.ViewModel;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private void OnSaveExecute()
        {
            _dataService.Save(Contact);
            _eventAggregator.GetEvent<AfterContactSaveEvent>()
                .Publish(new AfterContactSaveEventArgs()
                {
                    Id = Contact.Id,
                    DisplayMember = $"{Contact.Name} {Contact.Surname}"
                });
        }

        private bool OnSaveCanExecute()
        {
            //Todo : Check if its valid
            return true;
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

        public ICommand SaveCommand { get; }
    }
}
