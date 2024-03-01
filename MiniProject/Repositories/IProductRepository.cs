using MiniProject.Model;

namespace MiniProject.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<int> AddProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int id);


       
    }
}
