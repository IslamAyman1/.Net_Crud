using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("")]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _context.Set<Product>().Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpPut]
        [Route("Edit")]
        public ActionResult EditProduct(Product product)
        {
            var existingProduct = _context.Set<Product>().Find(product.Id);
            existingProduct.Name = product.Name;
            _context.Set<Product>().Update(existingProduct);
            _context.SaveChanges();
            return Ok(existingProduct);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult DeleteProduct(int id) 
        {
            var deleteProduct = _context.Set<Product>().Find(id);
            _context.Set<Product>().Remove(deleteProduct);
            _context.SaveChanges();
            return Ok(deleteProduct);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult GetProduct(int id)
        {
          var record =  _context.Set<Product>().Where(b => b.Id == id);
            return record == null ? NotFound() : Ok(record);
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var records = _context.Set<Product>().ToList();
            return Ok(records);
        }

    }
}
