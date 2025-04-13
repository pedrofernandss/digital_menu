using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digital_menu.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty
        public string PreparationMethod { get; set; } = string.Empty
        public DateTime CreatedAt { get; set; } = DateTime.Now
        public DateTime UpdatedAt { get; set; } = DateTime.Now
    }
}