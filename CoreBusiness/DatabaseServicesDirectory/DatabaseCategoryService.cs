using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using System.Collections.Generic;

namespace CoreBusiness.DatabaseServicesDirectory
{
    public class DatabaseCategoryService : IDatabaseCategoryService
    {
        public DatabaseCategoryService()
        {
            //Add some default categories
            //var categories = new List<Category>();

            //categories = new List<Category>()
            //{
            //    new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage"},
            //    new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery"},
            //    new Category { CategoryId = 3, Name = "Meat", Description = "Meat"}
            //};
        }
        private readonly List<Category> categories = new List<Category>();

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public List<Category> GetCategoryByname(int categoryId, string categoryName)
        {
            var _categories = categories.Where(x => x.CategoryId == categoryId && x.Name == categoryName);
            return categories.ToList();
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
                categories.Add(category);
            }
            else
            {
                category.CategoryId = 1;
                categories.Add(category);
            }


            
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

        public bool IsCategoryNameExist(string name)
        {
            var categoryName = categories.FirstOrDefault(x => x.Name == name);      //.FirstOrDefault(u => u.Username == username);
            if (name is null)
            {
                return false;
            }
            return true;
        }

    }
}
