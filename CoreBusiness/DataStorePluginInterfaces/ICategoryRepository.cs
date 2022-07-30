using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void AddCategory(int categoryId, string name, string description);
        //void AddCategory(int categoryId, string name, string description);
        //void DeleteAllCategories(List<Category> categories);
        void DeleteCategory(int categoryId);
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        List<Category> GetCategoryByname(int categoryId, string categoryName);
        bool IsCategoryNameExist(string name);
        void UpdateCategory(Category category);
    }
}
