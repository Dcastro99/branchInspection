using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<Role> GetRoles();
        Role GetRole(string roleDescription);
        bool RoleExists(int roleId);
        bool CreateRole(Role role);
        bool UpdateRole(Role role);
        bool DeleteRole(Role role);
        bool Save();
    }
}
