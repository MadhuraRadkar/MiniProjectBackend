using MiniProject.Model;

namespace MiniProject.Repositories
{
    public interface ICartRepo
    {
        Task<int> AddToCart(Cart cart);
        Task<IEnumerable<Cart>> GetCart(int Rid);
        Task<int> DeleteFromCart (int id);
    }
}
