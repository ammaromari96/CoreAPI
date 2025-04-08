using AngularApp6.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp6.Server.Controllers
{
    public class ProudctController : Controller
    {
        private readonly MyDbContext _db;

        public ProudctController(MyDbContext db)
        {
            _db = db;
        }
  


        [HttpGet]
        public IActionResult GetProduct()
        {
            var Product = _db.Products.ToList();
            return Ok(Product);
        }


        [HttpGet("getProductById")]
        public IActionResult GetProductById(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost("getProductByName")]


        public IActionResult GetProductByName(string name)
        {
            var product = _db.Products.FirstOrDefault(c => c.Name == name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("getFirstproduct")]

        public IActionResult GetFirstProduct()
        {
            var Product = _db.Products.FirstOrDefault();
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
    }
}
