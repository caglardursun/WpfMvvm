using System.Collections.Generic;
using System.Threading.Tasks;
using Mailler.Model;

namespace Mailler.UI.Data.Repositories   
{
    public interface IContactRepository
    {
        Task<Contact> GetByIdAsync(int contactId);
        Task<List<Contact>> GetAllAsync();
        Task SaveAsync();
        bool HasChanges();
        void Add(Contact contact);
    }
}