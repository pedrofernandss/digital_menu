using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Data;
using Microsoft.AspNetCore.Mvc;
using digital_menu.Mappers;
using digital_menu.Dtos.Ingredient;

namespace digital_menu.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public IngredientController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var ingredients = _context.Ingredients.ToList().Select(i => i.ToIngredientDto());
            
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            var ingredient = _context.Ingredients.Find(id);

            if(ingredient == null) {
                return NotFound();
            }

            return Ok(ingredient.ToIngredientDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateIngredientRequestDto ingredientDto) 
        {
            var ingredientModel = ingredientDto.ToIngredientFromCreateDTO();
            _context.Ingredients.Add(ingredientModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = ingredientModel}, ingredientModel.ToIngredientDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateIngredientRequestDto updateDto)
        {
            var ingredientModel = _context.Ingredients.FirstOrDefault(i => i.Id == id);

            if(ingredientModel == null)
            {
               return NotFound(); 
            }

            ingredientModel.Name = updateDto.Name;
            ingredientModel.Unit = updateDto.Unit;

            _context.SaveChanges();

            return Ok(ingredientModel.ToIngredientDto());


        }    
    }
}