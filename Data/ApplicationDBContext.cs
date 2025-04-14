using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using digital_menu.Models;
using Microsoft.EntityFrameworkCore;

namespace digital_menu.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {

        }

        public DbSet<Recipe> Recipes {get; set;}
        public DbSet<Ingredient> Ingredients {get; set;}
        public DbSet<RecipeIngredient> RecipeIngredients {get; set;}
    }
}