using Mailler.DataAccess.LiteDB;
using Mailler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        
        public IEnumerable<Contact> GetById(int contactId)
        {
            DataProvider provider= DataProvider.Instance;
            return provider.GetContactsById(contactId);
        }

        public void Save(Contact contact)
        {
            DataProvider provider = DataProvider.Instance;
            provider.Save(contact);
        }
    }
}
