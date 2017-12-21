using System.Collections.Generic;
using Mailler.Model;

namespace Mailler.UI.Data.Repositories   
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetById(int contactId);
        void Save(Contact contact);
    }
}