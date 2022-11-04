using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class RoleRepository:IRoleRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public RoleRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public int addRole(Role role)
        {

            furnitureCompanyContext.Roles.Add(role);
            int success =  furnitureCompanyContext.SaveChanges();
            return success;
        }

        public int deleteRole(int roleId)
        {
            Role r = furnitureCompanyContext.Roles.FirstOrDefault(r => r.Id == roleId);
            if(r != null)
            {
                furnitureCompanyContext.Roles.Remove(r);
                furnitureCompanyContext.SaveChanges();
                return 1;
            }
            return -1;
        }

        public List<Role> getAllRole()
        {
            List<Role> roles = furnitureCompanyContext.Roles.ToList();
            return roles;
        }


    }
}
