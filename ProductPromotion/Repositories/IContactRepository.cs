using ProductPromotion.Entities;
using System.Threading.Tasks;

namespace ProductPromotion.Repositories
{
    public interface IContactRepository
    {

        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address);

    }
}
