namespace LibraryRecipeFirstDBCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecipeID { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Yield { get; set; }

        [StringLength(500)]
        public string ServingSize { get; set; }

        [Required]
        public string Directions { get; set; }

        public string Comment { get; set; }

        [Required]
        [StringLength(500)]
        public string RecipeType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
