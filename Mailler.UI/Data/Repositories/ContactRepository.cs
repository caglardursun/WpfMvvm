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
        
        private ContactOrganizerDbContext _context;

        public ContactRepository(ContactOrganizerDbContext context)
        {
            _context = context;
        }
        public async Task<Contact> GetByIdAsync(int contactId)
        {
            
                return await _context.Contacts.SingleAsync(h=>h.Id == contactId);
            
        }

        public async Task<List<Contact>> GetAllAsync()
        {
           
                return await _context.Contacts.ToListAsync();
           
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
            
        }
    }
}
