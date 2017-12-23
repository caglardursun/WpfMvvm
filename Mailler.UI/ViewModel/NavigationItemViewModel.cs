using Mailler.UI.Event;
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
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;

        public NavigationItemViewModel(int id,string displayMember,IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            _eventAggregator = eventAggregator;
            OpenContactDetailViewCommand = new DelegateCommand(OnOpenContactDetailView);
        }

        

        public int Id { get; }
        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; OnPropertyChanged(); }
        }

        private IEventAggregator _eventAggregator;

        public ICommand OpenContactDetailViewCommand { get; set; }

        private void OnOpenContactDetailView()
        {
            _eventAggregator
                .GetEvent<OpenContactDetailViewEvent>()
                .Publish(Id);
        }

    }
}
