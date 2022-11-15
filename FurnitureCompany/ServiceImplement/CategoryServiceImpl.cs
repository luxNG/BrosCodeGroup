using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class CategoryServiceImpl : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        public CategoryServiceImpl(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public List<Category> getAllCategory()
        {
            List<Category> listCategory = categoryRepository.getAllCategory();
            return listCategory;
        }

        public Category getCategoryById(int id)
        {
            Category category = categoryRepository.getCategoryById(id);
            return category;
        }
    }
}
