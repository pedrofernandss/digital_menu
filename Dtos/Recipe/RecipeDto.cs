using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Dtos.RecipeIngredient;

namespace digital_menu.Dtos.Recipe
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PreparationMethod { get; set; } = string.Empty;

        public List<RecipeIngredientDto> Ingredients { get; set; } = new();
        
    }
}