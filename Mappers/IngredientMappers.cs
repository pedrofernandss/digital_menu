using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Dtos.Ingredient;
using digital_menu.Models;

namespace digital_menu.Mappers
{
    public static class IngredientMappers
    {
        public static IngredientDto ToIngredientDto(this Ingredient ingredientModel)
        {
            return new IngredientDto
            {
                Id = ingredientModel.Id,
                Name = ingredientModel.Name,
                Unit = ingredientModel.Unit,
            };
        }

        public static Ingredient ToIngredientFromCreateDTO(this CreateIngredientRequestDto ingredientDto)
        {
            return new Ingredient
            {
                Name = ingredientDto.Name,
                Unit = ingredientDto.Unit,
            };
        }
    }
}