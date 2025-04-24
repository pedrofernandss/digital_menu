using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Models;

namespace digital_menu.Dtos.RecipeIngredient
{
    public class RecipeIngredientDto
    {
        public int RecipeId { get; set; }
        public string Recipe { get; set; } = null!;

        public int IngredientId { get; set; }
        public string Ingredient { get; set; } = null!;

        public decimal Quantity { get; set; }
    }
}
