using Mailler.DataAccess;
using Mailler.DataAccess.LiteDB;
using Mailler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.Data.LookUps
{
    public class LookUpContactDataService : ILookUpContactDataService
    {
        private Func<ContactOrganizerDbContext> _contextCreator;

        public LookUpContactDataService(Func<ContactOrganizerDbContext> contextCreator)
        {

            _contextCreator = contextCreator;
        }

    

        public async Task<List<LookUpItem>> GetContactLookUpAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Contacts.Select(f => new LookUpItem()
                {
                    Id = f.Id,
                    DisplayMember = f.Name + " " + f.Surname
                }).ToListAsync();
            }
        }

        public ObservableCollection<LookUpItem> Contacs { get; }
    }
}
