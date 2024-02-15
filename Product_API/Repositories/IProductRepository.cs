using Product_API.Models;

namespace Product_API.Repositories
{
    public interface IProductRepository
    {
        ProductDTO Add(ProductDTO product);
        List<Product> GetAll();
    }
}
