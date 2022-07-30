using CoreBusiness.DataStorePluginInterfaces;
using CoreBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public IDatabaseUserService DatabaseService { get; set; }
        public UserController(IDatabaseUserService databaseService)
        {
            DatabaseService = databaseService;
        }


        #region HTTP-POST
        /// <summary>
        /// I have a bug here : when i use the same username for another user, it allows the registration to be successful
        /// </summary>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        
        public IActionResult CreateUser(string name, string username, string email, string password)
        {
            bool usernameExist = DatabaseService.IsUsernameExist(username);
            //bool userIdExist = DatabaseService.IsUserIdExist(user.UserId);
            bool userEmailExist = DatabaseService.IsUserEmailExist(email);

            if (!usernameExist && !userEmailExist)
            {
                DatabaseService.CreateUser(name, username, email, password);
                return Ok("User Created Successfully");
            }
            else if (userEmailExist) return Ok("Email has beign used");
            else return Ok("username already taken");
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
