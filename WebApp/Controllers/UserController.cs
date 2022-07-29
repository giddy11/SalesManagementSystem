using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public IDatabaseUserService DatabaseService { get; }
        public UserController(IDatabaseUserService databaseService)
        {
            DatabaseService = databaseService;
        }


        #region HTTP-POST

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            DatabaseService.CreateUser(user);
            return Ok("User Created Successfully");
        }

        #endregion

        #region HTTP-PUT

        [HttpPut("{userId}/user")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            DatabaseService.UpdateUser(user);
            return Ok("Updated Successfully");
        }

        #endregion


        #region HTTP-GET

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(DatabaseService.GetUsers());
        }




        [HttpGet("byId/{id}")]
        public IActionResult GetUserById(Guid id)
        {
            return Ok(DatabaseService.GetUserById);
        }














        #endregion
    }
}
