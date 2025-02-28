

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


        public bool CreateRole(RoleModel role)
        {
            _context.Roles.Add(role);
            return Save();
        }

        public bool DeleteRole(RoleModel role)
        {
            _context.Roles.Remove(role);
            return Save();
        }

        public RoleModel GetRole(string roleDescription)
        {
            return _context.Roles.FirstOrDefault(r => r.Role == roleDescription);
        }

        public ICollection<RoleModel> GetRoles()
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

        public bool UpdateRole(RoleModel role)
        {
            _context.Roles.Update(role);
            return Save();
        }
    }
}
