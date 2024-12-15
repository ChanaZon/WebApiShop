using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        //everything with dto... also in other controllers.

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order result = _orderService.GetOrderById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {

            //int passwordScore = _userService.CheckPassword(user.Password);
            Order result = await _orderService.AddOrder(order);

            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = order.UserId }, order);
            }
            return BadRequest();
        }   

        
    }
}
