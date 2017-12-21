using Mailler.DataAccess.LiteDB;
using Mailler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.Data.LookUps
{
    public class LookUpContactDataService : ILookUpContactDataService
    {


        public LookUpContactDataService()
        {
        }

        public IEnumerable<LookUpItem> GetContactLookUp()
        {
            DataProvider _dataProvider = DataProvider.Instance;
            return _dataProvider.GetAll().Select(f => new LookUpItem()
                    {
                        Id = f.Id,
                        DisplayMember = f.Name + " " + f.Surname
                    });
        }

        public ObservableCollection<LookUpItem> Contacs { get; }
    }
}
