using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digital_menu.Dtos.RecipeIngredient;
using digital_menu.Models;
using digital_menu.Mappers;

namespace digital_menu.Controllers
{
    [Route("api/recipe-ingredients")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RecipeIngredientController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("{recipeId}")]
        public IActionResult GetByRecipe([FromRoute] int recipeId)
        {
            var recipe = _context.Recipes
                .Where(r => r.Id == recipeId)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Select(r => r.ToRecipeDto()) // Projeção direta para o DTO
                .FirstOrDefault();

            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRecipeIngredientRequestDto recipeIngredientDto)
        {
            var existing = _context.RecipeIngredients
                .FirstOrDefault(ri => ri.RecipeId == recipeIngredientDto.RecipeId && ri.IngredientId == recipeIngredientDto.IngredientId);

            if (existing != null)
            {
                return Conflict("Essa combinação já existe. Use PUT para atualizar.");
            }

            var ri = new RecipeIngredient
            {
                RecipeId = recipeIngredientDto.RecipeId,
                IngredientId = recipeIngredientDto.IngredientId,
                Quantity = recipeIngredientDto.Quantity,
            };

            _context.RecipeIngredients.Add(ri);
            _context.SaveChanges();

            return Created("", ri);
        }

        [HttpPut("{recipeId}/{ingredientId}")]
        public IActionResult Update(int recipeId, int ingredientId, [FromBody] UpdateRecipeIngredientRequestDto recipeIngredientDto)
        {
            var ri = _context.RecipeIngredients
                .FirstOrDefault(r => r.RecipeId == recipeId && r.IngredientId == ingredientId);

            if (ri == null)
                return NotFound();

            ri.Quantity = recipeIngredientDto.Quantity;
            _context.SaveChanges();

            return Ok(ri);
        }

        [HttpDelete("{recipeId}/{ingredientId}")]
        public IActionResult Delete(int recipeId, int ingredientId)
        {
            var ri = _context.RecipeIngredients
                .FirstOrDefault(r => r.RecipeId == recipeId && r.IngredientId == ingredientId);

            if (ri == null)
                return NotFound();

            _context.RecipeIngredients.Remove(ri);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
