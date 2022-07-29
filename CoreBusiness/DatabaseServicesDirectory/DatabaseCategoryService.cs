using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;

namespace CoreBusiness.DatabaseServicesDirectory
{
    public class DatabaseCategoryService : IDatabaseService
    {
        public DatabaseCategoryService()
        {
            //Add some default categories

            categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage"},
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery"},
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat"}
            };
        }
             private readonly List<Category> categories;

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            //if (categories != null && categories.Count > 0)
            //{
            //    //var maxId = categories.Max(x => x.CategoryId);
            //    //category.CategoryId = maxId;
            //}
            //else
            //{
            //    category.CategoryId = 1;
            //}


            categories.Add(category);
        }

        public void AddCategory(int categoryId, string name, string description)
        {
            categories.Add(new Category
            {
                CategoryId = categoryId,
                Name = name,
                Description = description
            });
        }


        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }


        public void DeleteCategory(int categoryId)
        {
            categories?.Remove(GetCategoryById(categoryId));
        }

    }
}
