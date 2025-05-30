using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Data;
using digital_menu.Dtos.Recipe;
using digital_menu.Dtos.RecipeIngredient;
using digital_menu.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var recipes = _context.Recipes.ToList().Select(r => r.ToRecipeDto());
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            var recipe = _context.Recipes.Find(id);

            if(recipe == null) {
                return NotFound();
            }

            return Ok(recipe.ToRecipeDto());
        }

        [HttpGet("{id}/ingredients")]
        public IActionResult GetRecipeWithIngredients([FromRoute] int id)
        {
            var recipe = _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            var recipeDto = new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PreparationMethod = recipe.PreparationMethod,
                Ingredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientDto
                {
                    RecipeId = ri.RecipeId,
                    IngredientId = ri.IngredientId,
                    Ingredient = ri.Ingredient.Name,
                    Quantity = ri.Quantity
                }).ToList()
            };

            return Ok(recipeDto);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] CreateRecipeRequestDto recipeDto) 
        {
            var recipeModel = recipeDto.ToRecipeFromCreateDTO();
            _context.Recipes.Add(recipeModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = recipeModel}, recipeModel.ToRecipeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateRecipeRequestDto updateDto)
        {
            var recipeModel = _context.Recipes.FirstOrDefault(r => r.Id == id);

            if(recipeModel == null)
            {
               return NotFound(); 
            }

            recipeModel.Name = updateDto.Name;
            recipeModel.PreparationMethod = updateDto.PreparationMethod;

            _context.SaveChanges();

            return Ok(recipeModel.ToRecipeDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var recipeModel = _context.Recipes.FirstOrDefault(i => i.Id == id);

            if(recipeModel == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipeModel);
            _context.SaveChanges();
            return NoContent();
        }        
    }
}