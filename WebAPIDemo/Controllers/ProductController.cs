using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult GetAllProduct() => Ok("Thanh cong");
       
    }
}
