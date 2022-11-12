using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectElearning.DTO;
using ProjectElearning.IRepository;
using ProjectElearning.Models;

namespace ProjectElearning.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseRepository courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet("/GetAllCourse")]
        public IActionResult getAllCourese()
        {
            List<Course> list = courseRepository.getAllCourse();
            return Ok(list);
        }

        [HttpPost("CreateNewCourse")]
        public IActionResult createNewCourse(IFormFile? formFile, [FromForm] CourseDTO courseDTO)
        {
            DateTime now = DateTime.Now;
            var formatDateTime = now.ToString("dd/MM/yyyy HH:mm:ss");
            DateTime getDateTime = DateTime.Parse(formatDateTime);
            Course course = new Course
            {
                Id = courseDTO.Id,
                Title = courseDTO.Title,
                Image = "",
                LecturesCount = courseDTO.LecturesCount,
                HourCount = courseDTO.HourCount,
                ViewCount = courseDTO.ViewCount,
                Price = courseDTO.Price,
                Discount = courseDTO.Discount,
                PromotionPrice = courseDTO.PromotionPrice,
                Description = courseDTO.Description,
                CourseContent = courseDTO.CourseContent,
                CategoryId = courseDTO.CategoryId,
                LastUpdate = getDateTime

            };
            courseRepository.createNewCourse(course);
            return Ok(course);
        }
    }
}
