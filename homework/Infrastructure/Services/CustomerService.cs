
using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Services
{

   public class CustomerService 
   {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=hometask ;User Id=postgres;Password=233223;";

        public List<Customer> GetProducts()
        {
             using (var connection = new NpgsqlConnection(_connectionString))
             {
                 string sql = "SELECT * FROM Products";
                 var result = connection.Query<Customer>(sql);
                 return result.ToList(); 
             }
        }
   }
}
