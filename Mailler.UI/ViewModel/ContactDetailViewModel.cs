using Mailler.Model;
using Mailler.UI.Data;
using Mailler.UI.Event;
using Mailler.UI.Wrapper;
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

        private ContactWrapper _contact;

        public ContactDetailViewModel(IContactDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenContactDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public void Load(int contactId)
        {
            var contact = _dataService.GetById(contactId).First();
            Contact = new ContactWrapper(contact);
            Contact.PropertyChanged += (s, e) =>
             {
                 if (e.PropertyName == nameof(Contact.HasErrors))
                 {
                     ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                 }
             };
            
        }

        public ContactWrapper Contact
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

        private void OnSaveExecute()
        {
            _dataService.Save(Contact.Model);
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
            return Contact!= null && !Contact.HasErrors;
        }

        private void OnOpenFriendDetailView(int contactId)
        {
            Load(contactId);
        }

    }
}
