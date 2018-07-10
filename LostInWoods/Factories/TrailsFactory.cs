using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInWoods.Models;
 
namespace LostInWoods.Factory
{
    public class TrailsFactory : IFactory<Trails>
    {
        private string connectionString;
        public TrailsFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=woodsDB;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Trails item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails (trail_name, description, trail_length, elevation_change, latitude,longitude) VALUES (@Trail_Name, @Description, @Trail_Length, @Elevation_Change, @Latitude,@Longitude)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trails> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trails>("SELECT * FROM trails");
            }
        }
        public Trails FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
               dbConnection.Open(); 
               return dbConnection.Query<Trails>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }








    }
}
