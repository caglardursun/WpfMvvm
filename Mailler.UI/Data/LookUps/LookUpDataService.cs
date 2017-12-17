using Mailler.DataAccess;
using Mailler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.Data
{
    public class LookUpContactDataService : ILookUpContactDataService
    {
        private DataProvider _dataProvider;

        public LookUpContactDataService()
        {
            _dataProvider = DataProvider.Instance;
        }

        public IEnumerable<LookUpItem> GetContactLookUp()
        {
            return _dataProvider.GetAll().Select(f => new LookUpItem()
                    {
                        Id = f.Id,
                        DisplayMember = f.Name + " " + f.Surname
                    });
        }

        public ObservableCollection<LookUpItem> Contacs { get; }
    }
}
