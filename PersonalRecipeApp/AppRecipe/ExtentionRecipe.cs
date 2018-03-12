using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Extension of the Recipe Class

namespace AppRecipe
{
    public partial class Recipe : IComparable<Recipe>
    {
        // implement IComparable
        public int CompareTo(Recipe that)
        {
            int result = this.Title.CompareTo(that.Title);
            return result;
        }
    }
}
