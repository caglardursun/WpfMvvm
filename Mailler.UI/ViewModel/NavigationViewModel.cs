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
            var lookupItem = Contacts.SingleOrDefault(l => l.Id == obj.Id);
            if (lookupItem == null)
            {
                Contacts.Add(new NavigationItemViewModel(obj.Id,obj.DisplayMember,_eventAggregator));
            }
            else
            {
                lookupItem.DisplayMember = obj.DisplayMember;
            }
            
            
        }

        public async Task LoadAsync()
        {
            var lookUp = await _contactLookupService.GetContactLookUpAsync();
            Contacts.Clear();
            foreach (var item in lookUp)
            {
                Contacts.Add(new NavigationItemViewModel(item.Id, item.DisplayMember,_eventAggregator));
            }
        }


        public ObservableCollection<NavigationItemViewModel> Contacts { get; }


    }
}
