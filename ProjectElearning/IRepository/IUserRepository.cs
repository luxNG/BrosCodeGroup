using ProjectElearning.Models;

namespace ProjectElearning.IRepository
{
    public interface IUserRepository
    {
        public List<User> getAllUserInformation();

        public User getUserById(int id);

        public Boolean deleteUserById(int id);

        public void updateUserInformation(User user);

        public void createUser(User user);

        
    }
}
