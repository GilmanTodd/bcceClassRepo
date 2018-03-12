using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryRecipeFirstDBCodeFirst
{
    public class EntityRecipeAppDBContextInitializer : CreateDatabaseIfNotExists<EntityRecipeAppDB>
    {
        protected override void Seed(EntityRecipeAppDB context)
        {
            base.Seed(context);
            try
            {
                // get Recipe data from XML
                List<Recipe> recipes = GetXMLDataRecipe();

                // write the list to the DB
                foreach (Recipe x in recipes)
                {
                    context.Recipes.Add(x);
                }
                context.SaveChanges();

                // get ingredient data from XML
                List<Ingredient> ingredients = GetXMLDataIngredient();

                // write the list to the DB
                foreach (Ingredient x in ingredients)
                {
                    context.Ingredients.Add(x);
                }
                context.SaveChanges();

            }
            catch (UpdateException ex)
            {
                // delete the database
                if (context.Database.Exists()) context.Database.Delete();
                throw ex;
            }
            catch (DataException ex)
            {
                // delete the database
                if (context.Database.Exists()) context.Database.Delete();
                throw ex;
            }
            catch (XmlException ex)
            {
                // delete the database
                if (context.Database.Exists()) context.Database.Delete();
                throw ex;
            }
            catch (FileNotFoundException ex)
            {
                // delete the database
                if (context.Database.Exists()) context.Database.Delete();
                throw new FileNotFoundException("File was not found : {0}", ex);
            }
            catch (Exception ex)
            {
                // delete the database
                if (context.Database.Exists()) context.Database.Delete();
                throw new Exception("Exception : {0}", ex);
            }
        }
        
        // ----  methods  -----------------------------------------------------------------------------------------------
        static List<Recipe> GetXMLDataRecipe()
        {
            // get raw data from XML
            //var recipesXML = (
            //    from a in XDocument.Load("Recipes.xml").Descendants("Recipe")
            //    select a
            //    ).ToList();
            var recipesXML = (
                from a in XDocument.Load(FindFile("Recipe.xml")[0].FullName).Descendants("Recipe")
                select a
                ).ToList();

            // initialize empty recipe list
            List<Recipe> recipes = new List<Recipe>(recipesXML.Count);

            // convert xml to objects and populate the empty list
            Recipe recipe = null;

            foreach (var x in recipesXML)
            {
                recipe = new Recipe();

                switch (x.Name.ToString())
                {
                    case "RecipeID":
                        recipe.RecipeID = int.Parse(x.Element("RecipeID").Value);
                        break;
                    case "Title":
                        recipe.Title = x.Element("Title").Value.Trim()
                            .Substring(0, Math.Min(x.Element("Title").Value.Trim().Length, 50));
                        break;
                    case "Yield":
                        recipe.Yield = x.Element("Yield").Value.Trim();
                        break;
                    case "ServingSize":
                        recipe.ServingSize = x.Element("ServingSize").Value.Trim()
                            .Substring(0, Math.Min(x.Element("ServingSize").Value.Trim().Length, 50));
                        break;
                    case "RecipeType":
                        recipe.RecipeType = x.Element("RecipeType").Value.Trim()
                            .Substring(0, Math.Min(x.Element("RecipeType").Value.Trim().Length, 50));
                        break;
                    case "Directions":
                        recipe.Yield = x.Element("Directions").Value.Trim();
                        break;
                    case "Comment":
                        recipe.Yield = x.Element("Comment").Value.Trim();
                        break;
                }

                // handle bad data
                if (recipe.Yield == null)
                {
                    recipe.Yield = "unknown";
                }

                // add to collection
                recipes.Add(recipe);
            }

            // return collection
            return recipes;
        }

        static List<Ingredient> GetXMLDataIngredient()
        {
            // get contents of XML file
            //var ingredientXML = (
            //    from a in XDocument.Load("Ingredients.xml").Descendants("Ingredient")
            //    select a
            //    ).ToList();
            var ingredientXML = (
                from a in XDocument.Load(FindFile("Ingredients.xml")[0].FullName).Descendants("Ingredient")
                select a
                ).ToList();
            
            // initialize empty recipe list
            List<Ingredient> ingredients = new List<Ingredient>(ingredientXML.Count);

            // convert xml to objects and populate the empty list
            Ingredient ingredient = null;

            foreach (var x in ingredientXML)
            {
                ingredient = new Ingredient();

                switch (x.Name.ToString())
                {
                    case "IngredientID":
                        ingredient.IngredientID = int.Parse(x.Element("IngredientID").Value);
                        break;
                    case "Description":
                        ingredient.Description = x.Element("Description").Value;
                        break;
                    case "RecipeID":
                        ingredient.RecipeID = int.Parse(x.Element("RecipeID").Value);
                        break;
                }

                // handle bad data

                // add to collection
                ingredients.Add(ingredient);
            }

            // return collection
            return ingredients;
        }

        static FileInfo[] FindFile(string filename)
        {
            string fileRoot = @"..\";

            DirectoryInfo rootDirectory = new DirectoryInfo(fileRoot);

            FileInfo[] fileArray;

            fileArray = rootDirectory.GetFiles(filename, SearchOption.AllDirectories);

            return fileArray;
        }
    }
}
