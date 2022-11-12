using ProjectElearning.Models;

namespace ProjectElearning.IRepository
{
    public interface ICategoryRepository
    {
        public List<Category> getAllCategory();

        public void AddNewCategory(Category category);

        public Category findCategoryById(int id);
        public void UpdateCategory(Category category);


    }
}
