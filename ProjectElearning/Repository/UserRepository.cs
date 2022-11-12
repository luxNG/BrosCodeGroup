using ProjectElearning.Data;
using ProjectElearning.IRepository;
using ProjectElearning.Models;

namespace ProjectElearning.Repository
{
    public class UserRepository : IUserRepository
    {

        private ElearningContext elearningContext;

        public UserRepository(ElearningContext elearningContext)
        {
            this.elearningContext = elearningContext;
        }

        public List<User> getAllUserInformation()
        {
            return elearningContext.Users.ToList();
        }

        public User getUserById(int id)
        {
            User user = elearningContext.Users.FirstOrDefault(x => x.Id == id && x.Status == true);
            return user;
        }

        public Boolean deleteUserById(int id)
        {
            User user = getUserById(id);
            if(user != null)
            {
                user.Status = false;
                elearningContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void updateUserInformation(User user)
        {
            elearningContext.Users.Update(user);
            elearningContext.SaveChanges();
        }

        public void createUser(User user)
        {
            elearningContext.Users.Add(user);
            elearningContext.SaveChanges();
        }     
    }
}
