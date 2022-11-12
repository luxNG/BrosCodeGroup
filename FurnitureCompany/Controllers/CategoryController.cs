using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/category/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryRepository iCategoryRepository;
        public CategoryController(ICategoryRepository iCategoryRepository)
        {
            this.iCategoryRepository = iCategoryRepository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        [Route("getall")]
        public IActionResult getAllCategory()
        {
            List<Category> list = iCategoryRepository.getAllCategory();
            return Ok(list);
        }

        // GET api/<CategoryController>/5
        [HttpGet]
        [Route("findcategoryid/{id}")]
        public IActionResult getCategoryById(int id)
        {
            Category category = iCategoryRepository.getCategoryById(id);
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [Route("addnewcategory/bymanager")]
        public void Post(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                CategoryName = categoryDto.CategoryName
            };
            iCategoryRepository.addCategory(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        [Route("updatecategory/{id}")]
        public void Put(int id, CategoryDto categoryDto)
        {
            Category category = iCategoryRepository.getCategoryById(id);
            category.CategoryName = categoryDto.CategoryName;
            iCategoryRepository.updateCategory(category);
            
        }

      
    }
}
