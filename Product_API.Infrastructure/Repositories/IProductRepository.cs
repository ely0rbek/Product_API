
using Product.Domain.Entities;

namespace Product_API.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        ProductModelDTO Add(ProductModelDTO product);
        List<ProductModel> GetAll();
    }
}
