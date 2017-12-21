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
        private IContactRepository _dataService;

        private IEventAggregator _eventAggregator;

        private ContactWrapper _contact;

        public ContactDetailViewModel(IContactRepository dataService, 
            IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenContactDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public async Task LoadAsync(int contactId)
        {
            var contact = await _dataService.GetByIdAsync(contactId);
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

        private async void OnOpenFriendDetailView(int contactId)
        {
           await LoadAsync(contactId);
        }

    }
}
