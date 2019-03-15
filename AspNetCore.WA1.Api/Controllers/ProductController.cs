using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.WA1.Api.Models.Entities;
using AspNetCore.WA1.Api.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.WA1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            Product product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound("Kayıt bulunamadı!");
            }
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Geçersiz istek.");
            }
            _productRepository.Add(product);
            _productRepository.SaveChanges();

            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _productRepository.Update(product);
                _productRepository.SaveChanges();
            }
            catch (Exception)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Delete(product);
            _productRepository.SaveChanges();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _productRepository.GetAll().Any(e => e.Id == id);
        }
    }
}