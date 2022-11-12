using ProjectElearning.Data;
using ProjectElearning.IRepository;
using ProjectElearning.Models;

namespace ProjectElearning.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private ElearningContext elearningContext;
        public CategoryRepository(ElearningContext elearningContext)
        {
            this.elearningContext = elearningContext;
        }


        public List<Category> getAllCategory()
        {
            return  elearningContext.Categories.ToList();
         
        }

        public Category findCategoryById(int id)
        {
            Category category = elearningContext.Categories.FirstOrDefault(x => x.Id == id);
            if(category == null)
            {
                return null;
            }
            return category;
        }

        public void AddNewCategory(Category category)
        {
            elearningContext.Categories.Add(category);
            elearningContext.SaveChanges();
           
        }

        public void UpdateCategory(Category category)
        {
            elearningContext.Categories.Update(category);
            elearningContext.SaveChanges();
        }
    }
}
