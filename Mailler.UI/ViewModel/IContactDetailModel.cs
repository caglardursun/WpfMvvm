using System.Threading.Tasks;

namespace Mailler.UI.ViewModel
{
    public interface IContactDetailViewModel
    {
        Task LoadAsync(int contactId);
    }
}