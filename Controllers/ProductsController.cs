using Microsoft.AspNetCore.Mvc;
using InventoryPro.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Lista estática en memoria
        private static List<Product> products = new List<Product>();

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name))
                return BadRequest("Producto inválido");

            product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);

            return Ok(product);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;

            return Ok(product);
        }
    }
}