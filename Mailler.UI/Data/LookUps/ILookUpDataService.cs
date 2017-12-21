using System.Collections.Generic;
using Mailler.Model;

namespace Mailler.UI.Data.LookUps
{
    public interface ILookUpContactDataService
    {
        IEnumerable<LookUpItem> GetContactLookUp();
    }
}