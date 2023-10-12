using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Techwiz.Models;
using Techwiz.Services;

namespace Techwiz.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(uint id)
        {
            if (id <= 0) 
                return BadRequest("Invalid ID");

            var user = await _userService.GetUserByIdAsync(id);

            if (user == null) 
                return NotFound();

            return Ok(user);
        } 

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel body)
        {
            if (body == null) 
                return BadRequest("Invalid request data");

            if (string.IsNullOrWhiteSpace(body.Name) || string.IsNullOrWhiteSpace(body.Email)) 
                return BadRequest("Name and Email are required");

            var user = await _userService.CreateUserAsync(body);

            return Created(nameof(CreateUser), user);
        }
    }
}