using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using DapperBase.Models;
 
namespace DapperBase.Factory
{
    public class UserFactory : IFactory<Users> 
    
    {
        // private string connectionString; Old Way
        private MySqlOptions _options;
        public UserFactory(IOptions<MySqlOptions> config)
        {
            _options = config.Value;
            // connectionString = "server=localhost;userid=root;password=root;port=3306;database=dapperDB;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(_options.ConnectionString);
            }
        }

        public void Add(Users item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO users (name, email, password) VALUES (@Name, @Email, @Password)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Users> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Users>("SELECT * FROM users");
            }
        }








    }









}
