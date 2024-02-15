using Npgsql;
using Product_API.Models;

namespace Product_API.Repositories
{
    public class ProductPostgressRepository : IProductRepository
    {
        public string connectionString = "Host=localhost; Port = 5432; Database = Users; User Id = postgres; Password = Maqsudkhan;";
        public NpgsqlConnection connection;
        public ProductPostgressRepository()
        {
            connection = new NpgsqlConnection(connectionString);
        }
        public ProductDTO Add(ProductDTO product)
        {
            connection.Open();
            string query = $"insert into products(Name,Description,PhotoPath) values('{product.Name}','{product.Description}','{product.PhotoPath}');";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return product;
        }
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            connection.Open();

            string query = $"select * from products;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                products.Add(new Product { Id = Convert.ToInt32(result["Id"]), Name = Convert.ToString(result["Name"]), Description = Convert.ToString(result["Description"]), PhotoPath = Convert.ToString(result["PhotoPath"]) });
            }
            connection.Close();
            return products;
        }
    }
}
