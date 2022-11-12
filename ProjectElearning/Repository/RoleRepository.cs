using ProjectElearning.Data;
using ProjectElearning.IRepository;
using ProjectElearning.Models;

namespace ProjectElearning.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private ElearningContext elearningContext;
        public RoleRepository(ElearningContext elearningContext)
        {
            this.elearningContext = elearningContext;
        }

        public void addNewRole(Role role)
        {
            elearningContext.Roles.Add(role);
            elearningContext.SaveChanges();
        }

        public List<Role> getRole()
        {
            List<Role> roles = elearningContext.Roles.ToList();
            return roles;
        }
    }
}
