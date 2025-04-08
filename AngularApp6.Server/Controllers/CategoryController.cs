using AngularApp6.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CategoryController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _db.Categories.ToList();
            return Ok(categories);
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


        [HttpPost ("getCategoryByName")]


        public IActionResult GetCategoryByName(string name)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Name == name);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost ("getFirstCategory")]

        public IActionResult GetFirstCategory()
        {
            var category = _db.Categories.FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

    }
}
