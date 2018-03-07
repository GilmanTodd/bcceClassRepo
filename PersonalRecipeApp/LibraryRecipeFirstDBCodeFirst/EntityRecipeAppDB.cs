namespace LibraryRecipeFirstDBCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityRecipeAppDB : DbContext
    {
        public EntityRecipeAppDB()
            : base("name=EntityRecipeAppDB")
        {

        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
