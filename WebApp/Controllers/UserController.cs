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
            bool usernameExist = DatabaseService.IsUsernameExist(user.Username) || DatabaseService.IsUserIdExist(user.UserId);
            if (!usernameExist)
            {
                DatabaseService.CreateUser(user);
                return Ok("User Created Successfully");
            }
            return BadRequest("This user already exist");
            
        }

        #endregion

        #region HTTP-PUT

        [HttpPut("{userId}/user")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            bool exist = DatabaseService.IsUserExist(user.UserId);
            if (exist)
            {
                DatabaseService.UpdateUser(user);
                return Ok("Updated Successfully");
            }
            return NotFound("User not Found");
            
        }

        #endregion
        
        
        #region HTTP-GET

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(DatabaseService.GetUsers());
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetUserById(Guid userId)
        {
            bool exist = DatabaseService.IsUserExist(userId);
            if (exist)
            {
                return Ok(DatabaseService.GetUserById);
            }
            return NotFound("Cannot Fetch User");
            
        }

        #endregion
    }
}
