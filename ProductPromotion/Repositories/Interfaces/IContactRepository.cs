using ProductPromotion.Entities;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories.Interfaces
{
    public interface IContactRepository
    {

        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address);

    }
}
