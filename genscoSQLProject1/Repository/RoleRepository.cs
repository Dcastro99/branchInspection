

using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class RoleRepository : IRoleRepository
    {
        DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;
        }


        public bool CreateRole(Role role)
        {
            _context.Roles.Add(role);
            return Save();
        }

        public bool DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            return Save();
        }

        public Role GetRole(string roleDescription)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleDescription == roleDescription);
        }

        public ICollection<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public bool RoleExists(int roleId)
        {
            return _context.Roles.Any(r => r.RoleId == roleId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            return Save();
        }
    }
}
