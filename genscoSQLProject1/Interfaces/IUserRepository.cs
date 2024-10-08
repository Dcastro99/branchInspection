using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userId);
        ICollection<User> GetUsersByRoleId(int roleId);
        bool UserExists(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();

    }
}
