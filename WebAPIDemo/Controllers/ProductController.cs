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
        public ProductController(ProductService productService)
        {
            _productService = productService;
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
            if (id < 0)
            {
                return BadRequest("Product ID cannot be negative.");
            }
            var product = _productService.GetProductByID(id, out var foundProduct);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateAProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductByID), new { id = product.Id}, product);
        }
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product product)
        {
            if (id < 0 || product == null)
            {
                return BadRequest("Invalid product data.");
            }
            _productService.UpdateProduct(product);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id < 0)
            {
                return BadRequest("Product ID cannot be negative.");
            }
            _productService.DeleteProductByID(id);
            return NoContent(); // Return 204 No Content if deletion is successful
        }
        /*[HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct() => Ok(ProductList.Products);
        //ActionResult<IEnumerable<Product>> is the return type for a collection of products
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = ProductList.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product not found
            }
            return Ok(product); // Return 200 OK with the product
        }
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (product.Id < 0 || string.IsNullOrEmpty(product.Name))
            {
                return BadRequest("Invalid product data."); // Return 400 Bad Request if data is invalid
            }
            ProductList.Products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            // Return 201 Created with the product
            // CreateAtAction(name of method, route values, product)
            // route values is used to generate the URL for the created resource, example: /api/product/{id}
        }
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updateProduct)
        {
            if (updateProduct == null)
            {
                return NotFound(); // Return 404 if product not found
            }
            var product = ProductList.Products.FirstOrDefault(p => p.Id == id);
            if (id < 0)
            {
                return BadRequest("Invalid product data."); // Return 400 Bad Request if data is invalid
            }
            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.Price = updateProduct.Price;
            return Ok(updateProduct); // Return 204 No Content if update is successful

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = ProductList.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product not found
            }
            ProductList.Products.Remove(product);
            return NoContent(); // Return 204 No Content if deletion is successful
        }*/
    }
}
 