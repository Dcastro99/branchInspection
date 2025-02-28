using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<RoleModel> GetRoles();
        RoleModel GetRole(string roleDescription);
        bool RoleExists(int roleId);
        bool CreateRole(RoleModel role);
        bool UpdateRole(RoleModel role);
        bool DeleteRole(RoleModel role);
        bool Save();
    }
}
