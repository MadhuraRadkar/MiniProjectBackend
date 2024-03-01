using MiniProject.Model;

namespace MiniProject.Services
{
    public interface ICartService
    {
        Task<int> AddToCart(Cart cart);
        Task<IEnumerable<Cart>> GetCart(int Rid);
        Task<int> DeleteFromCart(int id);
    }
}
