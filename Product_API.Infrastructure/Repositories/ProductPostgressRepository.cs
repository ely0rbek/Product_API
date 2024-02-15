
using Npgsql;
using Product.Domain.Entities;

namespace Product_API.Infrastructure.Repositories
{
    public class ProductPostgressRepository : IProductRepository
    {
        public string connectionString = "Host=localhost; Port = 5432; Database = Testdb; User Id = postgres; Password = 1234;";
        public NpgsqlConnection connection;
        public ProductPostgressRepository()
        {
            connection = new NpgsqlConnection(connectionString);
        }
        public ProductModelDTO Add(ProductModelDTO product)
        {
            connection.Open();
            string query = $"insert into products(Name,Description,PhotoPath) values('{product.Name}','{product.Description}','{product.PhotoPath}');";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return product;
        }
        public List<ProductModel> GetAll()
        {
            List<ProductModel> products = new List<ProductModel>();
            connection.Open();

            string query = $"select * from products;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                products.Add(new ProductModel { Id = Convert.ToInt32(result["Id"]), Name = Convert.ToString(result["Name"]), Description = Convert.ToString(result["Description"]), PhotoPath = Convert.ToString(result["PhotoPath"]) });
            }
            connection.Close();
            return products;
        }
    }
}
