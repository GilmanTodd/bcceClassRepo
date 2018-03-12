using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Extension of the Ingredient Class

namespace AppRecipe
{
    public partial class Ingredient : IComparable<Ingredient>
    {
        // implement IComparable
        public int CompareTo(Ingredient that)
        {
            int result = this.Description.CompareTo(that.Description);
            return result;
        }
    }
}
