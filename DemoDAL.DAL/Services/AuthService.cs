using ADOLibrary;
using DemoDAL.DAL.Models;
using System.Data;
using System.Linq;

namespace DemoDAL.DAL.Services
{
    public class AuthService
    {
        private User Convert(IDataReader reader)
        {
            return new User()
            {
                Id = (int)reader["Id"],
                LastName = (string)reader["LastName"],
                FirstName = (string)reader["FirstName"],
                Email = (string)reader["Email"]
            };
        }

        private readonly Connection _connection;

        public AuthService(Connection connection)
        {
            _connection = connection;
        }

        public void Register(User user)
        {
            Command command = new Command("RegisterUser", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);
            _connection.ExecuteNonQuery(command);
            user.Passwd = null;
        }

        public User Login(User user)
        {
            Command command = new Command("CheckUser", true);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);
            return _connection.ExecuteReader(command, Convert).SingleOrDefault();
        }
    }
}
