using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface ICategoryRepository
    {
        public List<Category> getAllCategory();
        public Category getCategoryById(int id);
        public void addCategory(Category category);
        public void updateCategory(Category category);
       
    }
}
