using System.Collections.Generic;
using Mailler.Model;

namespace Mailler.UI.Data
{
    public interface ILookUpContactDataService
    {
        IEnumerable<LookUpItem> GetContactLookUp();
    }
}