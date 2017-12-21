using System.Collections.Generic;
using System.Threading.Tasks;
using Mailler.Model;

namespace Mailler.UI.Data.LookUps
{
    public interface ILookUpContactDataService
    {        
        Task<List<LookUpItem>> GetContactLookUpAsync();
    }
}