using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int productId);
        List<Product> GetProductByname(int productId, string productName);
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
    }
}
