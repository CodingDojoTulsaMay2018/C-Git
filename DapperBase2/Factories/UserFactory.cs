using System.Collections.Generic;
using System.Linq;
using DapperBase2;
using System.Data;
using MySql.Data.MySqlClient;
using DapperBase2.Models;
 
namespace DapperBase2.Factory
{
    public class UserFactory : IFactory<Users>
    {
        private MySqlOptions _options;
        public UserFactory(IOptions<MySqlOptions> config)
        {
            _options = config.Value;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(_options.ConnectionString);
            }
        }
    }
}
