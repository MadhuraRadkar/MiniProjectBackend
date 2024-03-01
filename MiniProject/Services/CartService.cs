using MiniProject.Model;
using MiniProject.Repositories;

namespace MiniProject.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepo repo;
        public CartService(ICartRepo repo)
        {
            this.repo = repo;
        }

        public Task<int> AddToCart(Cart cart)
        {
          return repo.AddToCart(cart);
        }

        public Task<int> DeleteFromCart(int id)
        {
            return repo.DeleteFromCart(id);
        }

        public Task<IEnumerable<Cart>> GetCart(int Rid)
        {
            return repo.GetCart(Rid);
        }
    }
}
