using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRecipeFirstDBCodeFirst
{
    public class CFDBHelper
    {

        public CFDBHelper()
        {
            ConnectToDB();
        }

        public static void ConnectToDB()
        {
            Database.SetInitializer<EntityRecipeAppDB>(new EntityRecipeAppDBContextInitializer());
        }

        public List<Recipe> GetRecipes()
        {
            try
            {
                using (var ctx = new EntityRecipeAppDB())
                {
                    List<Recipe> recipes = (
                        from a in ctx.Recipes
                        select a
                        ).ToList();
                    return recipes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ingredient> GetIngredients()
        {
            try
            {
                using (var ctx = new EntityRecipeAppDB())
                {
                    List<Ingredient> ingredients = (
                        from a in ctx.Ingredients
                        select a
                        ).ToList();
                    return ingredients;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
