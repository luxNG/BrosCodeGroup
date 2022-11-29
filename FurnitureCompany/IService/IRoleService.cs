using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface IRoleService
    {
        public List<Role> getAllRole();
        public RoleGetCustomInforDto getRoleByRoleId(int id);
        public RoleDto addNewRole(RoleDto roleDto);
    }
}
