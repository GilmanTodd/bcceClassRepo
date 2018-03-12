ALTER DATABASE RecipeAppMain SET single_user WITH ROLLBACK IMMEDIATE

ALTER DATABASE RecipeAppMain MODIFY NAME = RecipeAppMainTemp

ALTER DATABASE RecipeAppMainTemp SET multi_user 