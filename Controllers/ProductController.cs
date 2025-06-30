using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService, ProductService productService2)
        {
            Console.WriteLine("1:"+productService.instanceID);
            Console.WriteLine("2:"+productService2.instanceID);
            _productService = productService;
            _productService = productService2;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductByID(int id)
        {
            
            var product = _productService.GetProductByID(id);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateAProduct(ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }
            _productService.AddProduct(product);
            return Created();
        }
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, ProductDTO product)
        {

            _productService.UpdateProduct(product, id);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
         
           // _productService.DeleteProductByID(id);
            return NoContent(); // Return 204 No Content if deletion is successful
        }
       
    }
}
 