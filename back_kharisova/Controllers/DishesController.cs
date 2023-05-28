using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_kharisova.Models;
using static back_kharisova.Models.Dish;

namespace back_kharisova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly RestContext _context;

        public DishesController(RestContext context)
        {
            _context = context;
        }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
          if (_context.Dishes == null)
          {
              return NotFound();
          }
            return await _context.Dishes.ToListAsync();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
          if (_context.Dishes == null)
          {
              return NotFound();
          }
            var dish = await _context.Dishes.FindAsync(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        [HttpGet("DishesWithCategoryName")]
        public IActionResult DishesWithCategoryName()
        {
            var dishTypeNames = Enum.GetNames(typeof(Dish.DishType)).ToList();

            var dishesWithEnumType = _context.Dishes
                .Select(dish => new
                {
                    Id = dish.Id,
                    Type = dishTypeNames[(int)dish.Type],
                    Name = dish.Name,
                    Weight = dish.Weight,
                    Calories = dish.Calories,
                    Price = dish.Price,
                    Description = dish.Description
                })
                .ToList();

            return Ok(dishesWithEnumType);
        }

        [HttpGet("Top5ExpensiveDishes")]
        public IActionResult Top5ExpensiveDishes()
        {
            var top5ExpensiveDishes = _context.Dishes
                .OrderByDescending(d => d.Price)
                    .Take(5)
                    .Select(d => new
                    {
                        Type = d.Type.ToString(),
                        Name = d.Name,
                        Weight = d.Weight,
                        Calories = d.Calories,
                        Price = d.Price,
                        Description = d.Description
                    })
                    .ToList();

            return Ok(top5ExpensiveDishes);
        }

        [HttpGet("Top5CheapestDishes")]
        public IActionResult Top5CheapestDishes()
        {
            var top5CheapestDishes = _context.Dishes
                .OrderBy(d => d.Price)
                .Take(5)
                .Select(d => new
                {
                    Type = d.Type.ToString(),
                    Name = d.Name,
                    Weight = d.Weight,
                    Calories = d.Calories,
                    Price = d.Price,
                    Description = d.Description
                })
                .ToList();

            return Ok(top5CheapestDishes);
        }

        [HttpGet("DishesByItsTypeNumber")]
        public IActionResult DishesByItsTypeNumber(DishType dishType)
        {
            var dishesByType = _context.Dishes
                .Where(d => d.Type == dishType)
                .Select(d => new
                {
                    Type = d.Type.ToString(),
                    Name = d.Name,
                    Weight = d.Weight,
                    Calories = d.Calories,
                    Price = d.Price,
                    Description = d.Description
                })
                .ToList();

            return Ok(dishesByType);
        }

        [HttpGet("DishesByItsTypeName")]
        public IActionResult DishesByItsTypeName(string dishType)
        {
            if (!Enum.TryParse<DishType>(dishType, out var parsedDishType))
            {
                return BadRequest("Invalid dish type.");
            }

            var dishTypeName = Enum.GetName(typeof(DishType), parsedDishType);

            var dishesByType = _context.Dishes
                .Where(d => d.Type == parsedDishType)
                .Select(d => new
                {
                    Type = dishTypeName,
                    Name = d.Name,
                    Weight = d.Weight,
                    Calories = d.Calories,
                    Price = d.Price,
                    Description = d.Description
                })
                .ToList();

            return Ok(dishesByType);
        }

        [HttpGet("Top5LowCalorieDishes")]
        public IActionResult Top5LowCalorieDishes()
        {
            var top5LowCalorieDishes = _context.Dishes
                .OrderBy(d => d.Calories)
                .Take(5)
                .Select(d => new
                {
                    Type = d.Type.ToString(),
                    Name = d.Name,
                    Weight = d.Weight,
                    Calories = d.Calories,
                    Price = d.Price,
                    Description = d.Description
                })
                .ToList();

            return Ok(top5LowCalorieDishes);
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish(int id, Dish dish)
        {
            if (id != dish.Id)
            {
                return BadRequest();
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
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

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
          if (_context.Dishes == null)
          {
              return Problem("Entity set 'RestContext.Dishes'  is null.");
          }
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDish", new { id = dish.Id }, dish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            if (_context.Dishes == null)
            {
                return NotFound();
            }
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishExists(int id)
        {
            return (_context.Dishes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
