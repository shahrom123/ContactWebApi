
using Dapper;
using Npgsql;
public class ProductService
{
   private string _connectionString = "Server=127.0.0.1; Port=5432;Database=hometask7 ; User Id=postgres; Password=233223;";
    
    public List<Product> GetProducts()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Products";
            var result = connection.Query<Product>(sql).ToList();
            return result;
        }
    }
    public bool AddProduct(Product product)
    {
     
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" insert into Products(ProductName, Company, ProductCount, Price)" +
                    $"values ('{product.ProductName}', '{product.Company}', " +
                    $"{product.ProductCount}, {product.Price})"; 
                var added = connection.Execute(sql);
                if (added > 0) return true;
                else return false; 
            }
    }
    public bool UpdateProduct(Product product)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $" update products set ProductName = '{product.ProductName}'," +
                $" Company = '{product.Company}', ProductCount = {product.ProductCount}," +
                $" Price = {product.Price} where id = {product.Id}";
            var updeted = connection.Execute(sql);
            if (updeted > 0) return true;
            else return false; 
        }
    }
    public bool DeleteProduct(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $" delete from products  where id = {id}";
            var deleted = connection.Execute(sql);
            if (deleted > 0) return true;
            else return false;
        }
    }
}