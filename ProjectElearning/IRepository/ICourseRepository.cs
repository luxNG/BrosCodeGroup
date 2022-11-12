using ProjectElearning.Models;

namespace ProjectElearning.IRepository
{
    public interface ICourseRepository
    {
        public List<Course> getAllCourse();
        public void createNewCourse(Course course);

    }
}
