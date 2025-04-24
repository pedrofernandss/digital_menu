using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digital_menu.Dtos.Ingredient
{
    public class CreateIngredientRequestDto
    {
       public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
 
    }
}