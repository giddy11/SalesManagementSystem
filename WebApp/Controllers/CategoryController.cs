using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        public IDatabaseService DatabaseService { get; }
        public CategoryController(IDatabaseService databaseService)
        {
            DatabaseService = databaseService;
        }




        //// GET: api/<CategoryController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CategoryController>
        [HttpPost("byCategory")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            DatabaseService.AddCategory(category);
            return Ok("Category added succeffully");
        }

        [HttpPost]
        public IActionResult AddCategory(int categoryId, string name, string description)
        {
            DatabaseService.AddCategory(categoryId, name, description);
            return Ok("Added Successfully");
        }


        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
