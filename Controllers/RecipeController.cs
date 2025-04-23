using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Data;
using Microsoft.AspNetCore.Mvc;

namespace digital_menu.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public RecipeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var recipes = _context.Recipes.ToList();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            var recipe = _context.Recipes.Find(id);

            if(recipe == null) {
                return NotFound();
            }

            return Ok(recipe);
        }
        
    }
}