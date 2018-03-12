using System;
using System.Collections.Generic;
using System.Windows;

namespace AppRecipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // define global vars

        public List<Recipe> recipeList;
        public static bool errorOccurred = false;
        public static bool exitClean = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RecipeAppMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    using (var dbContext = new RecipeAppMainEntities())
                    {
                        List<Recipe> listRecipe = (
                            from x in dbContext.Recipes
                            select x
                            ).ToList();
                    }
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                Exception ex1 = ex;
                while (ex1.InnerException != null)
                {
                    ex1 = ex1.InnerException;
                }
                lblMessage.Content = ex1.ToString();
                errorOccurred = true;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // zero out display boxes
            lblMessage.Content = null;
            // zero out recipe selection
            lbxRecipes.UnselectAll();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            exitClean = true;
            this.Close();
        }


        private void RecipeAppMainWindow_Closed(object sender, EventArgs e)
        {


        }

        private void RecipeAppMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (exitClean != true)
            {
                lblMessage.Content = "Please close this app using the [Exit] button";
                e.Cancel = true;
            }
        }

    }
}
