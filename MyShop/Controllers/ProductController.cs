using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> result = await _productService.GetProducts();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product result = await _productService.GetProductById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }




       
    }
}
