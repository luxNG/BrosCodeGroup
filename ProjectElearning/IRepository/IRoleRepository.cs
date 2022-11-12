using ProjectElearning.Models;

namespace ProjectElearning.IRepository
{
    public interface IRoleRepository
    {
        public List<Role> getRole();

        public void addNewRole(Role role);
    }
}
