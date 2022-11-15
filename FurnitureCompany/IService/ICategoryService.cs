using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface ICategoryService
    {
        public List<Category> getAllCategory();

        public Category getCategoryById(int id);
    }
}
