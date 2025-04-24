using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Dtos.RecipeIngredient;
using digital_menu.Models;

namespace digital_menu.Mappers
{
    public static class RecipeIngredientMappers
    {
        public static RecipeIngredientDto ToREDto(this RecipeIngredient recipeIngredientModel)
        {
            return new RecipeIngredientDto
            {
                RecipeId = recipeIngredientModel.RecipeId,
                IngredientId = recipeIngredientModel.IngredientId,
                Ingredient = recipeIngredientModel.Ingredient.Name,
                Quantity = recipeIngredientModel.Quantity,
            };
        }

        public static RecipeIngredient ToREFromCreateDTO(this CreateRecipeIngredientRequestDto recipeIngredientDto)
        {
            return new RecipeIngredient
            {
                RecipeId = recipeIngredientDto.RecipeId,
                IngredientId = recipeIngredientDto.IngredientId,
                Quantity = recipeIngredientDto.Quantity,
            };
        }
    }
}