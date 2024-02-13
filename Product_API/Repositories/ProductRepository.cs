using Npgsql;
using Product_API.Models;

namespace Product_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public string connectionString = "Host=localhost; Port = 5432; Database = Users; User Id = postgres; Password = Maqsudkhan;";
        public NpgsqlConnection connection;
        public ProductRepository()
        {
            connection = new NpgsqlConnection(connectionString);
        }
        public Product Add(Product product)
        {
            connection.Open();
            string query = $"insert into products(Id,Name,Description,PhotoPath) values({product.Id},'{product.Name}','{product.Description}','{product.PhotoPath}');";
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
