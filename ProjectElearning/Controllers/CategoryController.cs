using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectElearning.DTO;
using ProjectElearning.IRepository;
using ProjectElearning.Models;

namespace ProjectElearning.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("getAllCategory")]
        public IActionResult getAllCategory()
        {
            List<Category> list = categoryRepository.getAllCategory();
            return Ok(list);
        }

        [HttpPost("/CreateNewCategory")]
        public IActionResult CreateNewCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                Id = categoryDTO.Id,
                Title = categoryDTO.Title,
                Icon = "null"
            };
            categoryRepository.AddNewCategory(category);
            return Ok(category);
        }

        [HttpPut("/UpdateCategory/{id}")]
        public IActionResult updateCategory(int id, CategoryDTO categoryDTO)
        {
            Category category = categoryRepository.findCategoryById(id);
            if(category == null)
            {
                return BadRequest("No information");
            }
            category.Title = categoryDTO.Title;
            categoryRepository.UpdateCategory(category);
            return Ok(category);
        }
    }
}
