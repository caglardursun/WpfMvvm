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
using Mailler.UI.Data.Repositories;

namespace Mailler.UI.ViewModel
{
    public class ContactDetailViewModel : ViewModelBase, IContactDetailViewModel
    {
        private IContactRepository _contactRepository;
        private IEventAggregator _eventAggregator;
        private ContactWrapper _contact;
        private bool _hasChanges;

        public ContactDetailViewModel(IContactRepository dataService, 
            IEventAggregator eventAggregator)
        {
            _contactRepository = dataService;
            _eventAggregator = eventAggregator;

            

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public async Task LoadAsync(int? contactId)
        {
            var contact = contactId.HasValue
                ? await _contactRepository.GetByIdAsync(contactId.Value)
                : CreateNewContact();

            Contact = new ContactWrapper(contact);
            Contact.PropertyChanged += (s, e) =>
             {
                 if (!HasChanges)
                 {
                     HasChanges = _contactRepository.HasChanges();

                 }

                 if (e.PropertyName == nameof(Contact.HasErrors))
                 {
                     ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                 }
             };

            if (contact.Id == 0)
            {
                //Little trick to trigger the validation
                contact.Name = "";
            }

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

        }
        private Contact CreateNewContact()
        {
            var contact = new Contact();
            _contactRepository.Add(contact);
            return contact;
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
        public bool HasChanges
        {
            get { return _hasChanges; }
            set {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }
        public ICommand SaveCommand { get; }
        private void OnSaveExecute()
        {
            _contactRepository.SaveAsync();
            HasChanges = _contactRepository.HasChanges();
            _eventAggregator.GetEvent<AfterContactSaveEvent>()
                .Publish(new AfterContactSaveEventArgs()
                {
                    Id = Contact.Id,
                    DisplayMember = $"{Contact.Name} {Contact.Surname}"
                });
        }
        private bool OnSaveCanExecute()
        {            
            return Contact != null && !Contact.HasErrors && HasChanges;
        }
        
    }
}
