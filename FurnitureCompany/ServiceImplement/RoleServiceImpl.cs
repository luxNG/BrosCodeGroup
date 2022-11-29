using FurnitureCompany.Data;
using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class RoleServiceImpl : IRoleService
    {
        public IRoleRepository roleRepository;
        public RoleServiceImpl(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public RoleDto addNewRole(RoleDto roleDto)
        {
            //map
            Role roleMap = new Role
            {
                RoleName = roleDto.roleName,
            };
            roleRepository.addRole(roleMap);

            return roleDto;
        }

        public List<Role> getAllRole()
        {
            List<Role> listRole = roleRepository.getAllRole();
            return listRole;
        }

        public RoleGetCustomInforDto getRoleByRoleId(int id)
        {
            Role role = roleRepository.getRoleByRoleId(id);
            RoleGetCustomInforDto roleGetCustomInforDto = new RoleGetCustomInforDto()
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
            return roleGetCustomInforDto;
        }
    }
}
