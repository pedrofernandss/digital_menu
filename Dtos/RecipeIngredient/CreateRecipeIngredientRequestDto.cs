using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digital_menu.Dtos.RecipeIngredient
{
    public class CreateRecipeIngredientRequestDto
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }

    }
}