using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        User GetUserByEmpNum(int empNum);
        User GetUserById(int empId);
        User GetUserByEmailAndPassword(string email, string passwordHash);
        ICollection<User> GetUsersByRoleId(int roleId);
        bool UserExists(int empId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();

    }
}
