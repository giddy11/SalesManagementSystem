using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.DatabaseServicesDirectory
{
    public class DatabaseProductService : IDatabaseProductService
    {
       

        public DatabaseProductService()
        {
            //Add some default products
            var products = new List<Product>();
            //products = new List<Product>()
            //{
            //    new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 500},
            //    new Product{ ProductId = 2, CategoryId = 2, Name = "Canada Dry", Quantity = 200, Price = 300},
            //    new Product { ProductId = 3, CategoryId = 3, Name = "Chicken", Quantity = 250, Price = 300}
            //};
        }

        private readonly List<Product> products;


        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public List<Product> GetProductByname(int productId, string productName)
        {
            var _products = products.Where(x => x.ProductId == productId && x.Name == productName);
            return products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return products?.FirstOrDefault(x => x.CategoryId == productId);
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.CategoryId);
                product.ProductId = maxId;
            }
            else
            {
                product.ProductId = 1;
            }

            products.Add(product);
        }


        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
            }
        }

        public void DeleteProduct(int productId)
        {
            products?.Remove(GetProductById(productId));
        }

    }
}
