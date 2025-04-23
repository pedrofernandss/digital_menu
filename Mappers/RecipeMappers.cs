using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Dtos.Recipe;
using digital_menu.Models;

namespace digital_menu.Mappers
{
    public static class RecipeMappers
    {
        public static RecipeDto ToRecipeDto(this Recipe recipeModel)
        {
            return new RecipeDto
            {
                Id = recipeModel.Id,
                Name = recipeModel.Name,
                PreparationMethod = recipeModel.PreparationMethod
            };
        }

        public static Recipe ToRecipeFromCreateDTO(this CreateRecipeRequestDto recipeDto)
        {
            return new Recipe
            {
                Name = recipeDto.Name,
                PreparationMethod = recipeDto.PreparationMethod,
            };
        }
    }
}