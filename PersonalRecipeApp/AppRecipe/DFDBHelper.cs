using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecipe
{
    public class DFDBHelper
    {
        public DFDBHelper()
        {
            ConnectDB();
        }
        public static void ConnectDB()
        {
            //Database.SetInitializer<RecipeAppMainEntities>();
            
        }
    }
}
