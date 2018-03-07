namespace LibraryRecipeFirstDBCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }

        [Required]
        public string Description { get; set; }

        public int RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
