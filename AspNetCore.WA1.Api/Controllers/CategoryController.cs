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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            Category category = _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Geçersiz istek.");
            }
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();

            return CreatedAtAction("Get", new { id = category.Id }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                _categoryRepository.Update(category);
                _categoryRepository.SaveChanges();
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

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            _categoryRepository.Delete(category);
            _categoryRepository.SaveChanges();
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _categoryRepository.GetAll().Any(e => e.Id == id);
        }
    }
}