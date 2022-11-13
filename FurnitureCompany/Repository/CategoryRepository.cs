using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public CategoryRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public void addCategory(Category category)
        {
            furnitureCompanyContext.Categories.Add(category);
            furnitureCompanyContext.SaveChanges();
           
        }

        public List<Category> getAllCategory()
        {
             List<Category> listCategory = furnitureCompanyContext.Categories.ToList();
             return listCategory;
        }

        public Category getCategoryById(int id)
        {
            Category category = furnitureCompanyContext.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            return category;
        }

        public void updateCategory(Category category)
        {
            furnitureCompanyContext.Categories.Update(category);
            furnitureCompanyContext.SaveChanges();            
        }
    }
}
