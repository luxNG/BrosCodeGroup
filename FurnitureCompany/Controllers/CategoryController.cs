using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
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
        private ICategoryService categoryService;
        public CategoryController(ICategoryRepository iCategoryRepository, ICategoryService categoryService)
        {
            this.iCategoryRepository = iCategoryRepository;
            this.categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        [Route("getallcategory")]
        public IActionResult getAllCategory()
        {
            try
            {
                List<Category> listCategory = categoryService.getAllCategory();
                return Ok(listCategory);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet]
        [Route("findcategorybyid/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                Category category = categoryService.getCategoryById(id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
          
            
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
