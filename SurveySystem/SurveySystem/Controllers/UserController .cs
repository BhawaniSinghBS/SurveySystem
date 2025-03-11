using Microsoft.AspNetCore.Mvc;
using SurveySystem.BLL.UserService;
using SurveySystem.DAL.Entites;

namespace SurveySystem.API.Controllers
{   //**********************************************
     //To do: data trasfer models will be used here which are converted to DTOs at Business logic layer
    //*********************************************************
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                return BadRequest("Name and Email are required.");

            var createdUser = await _userService.AddUserAsync(user);
            return Ok(createdUser);
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var isDeleted = await _userService.DeleteUserAsync(userId);
            if (!isDeleted)
                return NotFound("User not found.");

            return Ok("User deleted successfully.");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }
    }
}
