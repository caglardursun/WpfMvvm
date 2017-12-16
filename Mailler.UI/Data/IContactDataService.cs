using System.Collections.Generic;
using Mailler.Model;

namespace Mailler.UI.Data
{
    public interface IContactDataService
    {
        IEnumerable<Contact> GetById(int contactId);
    }
}