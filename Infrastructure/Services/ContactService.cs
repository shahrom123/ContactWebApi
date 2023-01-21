using Dapper;
using Npgsql;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class ContactService
    {
        private string _connectionString = "Server=127.0.0.1; Port=5432;Database=ContactDb ; User Id=postgres; Password=233223;";

        public List<Contact> GetContact()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Contacts";
                var result = connection.Query<Contact>(sql).ToList();
                return result; 
            }
        }
        public List<Contact> GetContactByName(string name)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"SELECT c.Id, c.Name, c.Address, c.Telephone FROM Contacts c where Name = '{name}';";
                var result = connection.Query<Contact>(sql).ToList();
                return result;
            }
        }
        public bool AddContact(Contact contact)
        {

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" insert into Contacts (id, Name, Address, Telephone)" +
                    $" values ({contact.Id}, '{contact.Name}', '{contact.Address}',{contact.Telephone})";
                var added = connection.Execute(sql);
                if (added > 0) return true;
                else return false;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" update Contacts set Name = '{contact.Name}'," +
                    $" Address = '{contact.Address}', Telephone = {contact.Telephone}" +
                    $" where id = {contact.Id}";
                var updated = connection.Execute(sql);
                if (updated > 0) return true;
                else return false;
            }
        }

        public bool DeleteContact(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" delete from Contacts  where id = {id}";
                var deleted = connection.Execute(sql);
                if (deleted > 0) return true;
                else return false;
            }
        }
    } 
}
