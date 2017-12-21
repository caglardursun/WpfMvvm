using Mailler.DataAccess;
using Mailler.DataAccess.LiteDB;
using Mailler.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private Func<ContactOrganizerDbContext> _contextCreator;

        public ContactRepository(Func<ContactOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<Contact> GetByIdAsync(int contactId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Contacts.AsNoTracking().SingleAsync(h=>h.Id == contactId);
            }
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Contacts.AsNoTracking().ToListAsync();
            }
        }

        public void Save(Contact contact)
        {

            
        }
    }
}
