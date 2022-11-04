using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IRoleRepository
    {
        public List<Role> getAllRole();
        public int addRole(Role role);
        public int deleteRole(int roleId);
    }
}
