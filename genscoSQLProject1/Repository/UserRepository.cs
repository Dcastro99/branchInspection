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

        public User GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public ICollection<User> GetUsers()
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

        public bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.UserId == userId);
        }
    }
}
