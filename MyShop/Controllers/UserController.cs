using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using System.Diagnostics.Metrics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{

    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User result = _userService.GetUserById(id);
            if (result.UserId != null)
            {
                return Ok(_userService.GetUserById(id));
            }
            return BadRequest();
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            int passwordScore = _userService.CheckPassword(user.Password);
            User result = _userService.AddUser(user);
            if ((user.UserName==""||user.FirstName==""||user.LastName==""))
            {
              return BadRequest(new { error = "UserName, FirstName, and LastName are required." });
            }

            if (result != null && passwordScore > 2) 
            {
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Password")]
        public ActionResult<int> CheckPassword([FromBody] string password)
        {
            int result = _userService.CheckPassword(password);
            if (result < 0)
            {
                return BadRequest();
            }
            return result;
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("Login")]
        public ActionResult<User> Login([FromQuery] string userName, [FromQuery] string password)
        {
            User result = _userService.Login(userName,password);
            if (result != null)
            {
                return Ok(_userService.Login(userName, password));
            }
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User userToUpdate)
        {
            Boolean result = _userService.UpdateUser(id,userToUpdate);
            if (result)
            {
                return Ok(_userService.UpdateUser(id, userToUpdate));
            }
            return BadRequest();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
