using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {



        public IDatabaseProductService DatabaseService { get; }
        public ProductController(IDatabaseProductService databaseService)
        {
            DatabaseService = databaseService;
        }


        #region HTTP-GET

        [HttpGet("product")]
        public IActionResult GetAllProduct()
        {
            return Ok(DatabaseService.GetProducts());
        }

        [HttpGet("productName")]
        public IActionResult GetAllProductByName(int productId, string productName)
        {
            return Ok(DatabaseService.GetProductByname(productId, productName));
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetAllProductById(int productId)
        {
            return Ok(DatabaseService.GetProductById(productId));
        }
        #endregion


        #region HTTP-POST

        [HttpPost("byProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            DatabaseService.AddProduct(product);
            return Ok("Product added succeffully");
        }
        #endregion


        #region HTTP-PUT

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            DatabaseService.UpdateProduct(product);
            return Ok("Updated Successfully");
        }
        #endregion


        #region HTTP-DELETE

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            DatabaseService.DeleteProduct(id);
            return Ok("Deleted successfully");
        }

        #endregion
    }
}
