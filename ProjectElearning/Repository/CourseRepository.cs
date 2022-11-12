using ProjectElearning.Data;
using ProjectElearning.IRepository;
using ProjectElearning.Models;

namespace ProjectElearning.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private ElearningContext elearningContext;
        public CourseRepository(ElearningContext elearningContext)
        {
            this.elearningContext = elearningContext;
        }

        public List<Course> getAllCourse()
        {
            return elearningContext.Courses.ToList();
        }

        public void createNewCourse(Course course)
        {
            elearningContext.Courses.Add(course);
            elearningContext.SaveChanges();
        }
    }
}
