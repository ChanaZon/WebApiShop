using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{

    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService = new();
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
            return Ok(userService.GetUserById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {


            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("Login")]
        public ActionResult<User> Login([FromQuery] string userName, [FromQuery] string password)
        {
                        return Ok(userService.Login(userName,password));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User userToUpdate)
        {
                return Ok(userService.UpdateUser(id,userToUpdate));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
