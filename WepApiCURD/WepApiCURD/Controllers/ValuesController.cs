using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WepApiCURD.Data;
using WepApiCURD.Models;


namespace WepApiCURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       private readonly CategoryDbContext _category;
        public ValuesController(CategoryDbContext category)
        {
            _category= category;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _category.categories.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _category.categories.FirstOrDefaultAsync(x => x.id == id)); 
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            _category.categories.Add(category);
            await _category.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var categoryitems = await _category.categories.FirstOrDefaultAsync(x => x.id == id);
            if (categoryitems == null)
            {
                return NotFound();
            }
            else { 
            categoryitems.CategoryName = category.CategoryName;
            categoryitems.Descripsion = category.Descripsion;
             _category.categories.Update(categoryitems);
            await _category.SaveChangesAsync();
            return  Ok("Update Succesfully");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryitems = await _category.categories.FindAsync(id);
            if (categoryitems == null)
            {
                return NotFound();
            }
            else
            {
                _category.categories.Remove(categoryitems);
                await _category.SaveChangesAsync();
                return Ok("Delete Successfully");
            }
        }
    }
}
