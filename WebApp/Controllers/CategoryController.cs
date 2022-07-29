﻿using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        public IDatabaseService DatabaseService { get; }
        public CategoryController(IDatabaseService databaseService)
        {
            DatabaseService = databaseService;
        }


        #region HTTP-GET

        [HttpGet("category")]
        public IActionResult GetAllCategory()
        {
            return Ok(DatabaseService.GetCategories());
        }

        [HttpGet("categoryName")]
        public IActionResult GetAllCategoryByName(int categoryId, string categoryName)
        {
            return Ok(DatabaseService.GetCategoryByname(categoryId, categoryName));
        }

    
        [HttpGet("byId/{id}")]
        public IActionResult GetAllCategoryById(int id)
        {
            return Ok(DatabaseService.GetCategoryById(id));
        }
        #endregion


        #region HTTP-POST
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
        #endregion


        #region HTTP-PUT

        
        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            DatabaseService.UpdateCategory(category);
            return Ok("Updated Successfully");
        }
        #endregion



        #region HTTP-DELETE
        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        #endregion
    }
}
