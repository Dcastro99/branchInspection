using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class UserRepository : IUserRepository
    {
        DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();

        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public User GetUserByEmpNum(int empNum)
        {
            return _context.Users.FirstOrDefault(u => u.Contact_id == empNum);
        }
        public User GetUserById(int empId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == empId);
        }


        public ICollection<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public ICollection<User> GetUsersByRoleId(int roleId)
        {
            return _context.Users.Where(u => u.RoleId == roleId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool UserExists(int empId)
        {
            return _context.Users.Any(u => u.Contact_id == empId);
        }

        public User GetUserByEmailAndPassword(string email, string passwordHash)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.Password == passwordHash);

            return user;
        }
    }
}
