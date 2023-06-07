# Part2
PROG6221_POE-Part 2
Recipe Application
* This is an application that allows the user to create, view, scale, reset and clear recipes. The application has a generic collection to store the recipes created by the user.

How to use:

1. Creating a Recipe

To create a recipe, the user is prompted to enter the name, number of ingredients, and number of steps for the recipe. The user then enters the details of each ingredient, including the name, quantity, unit of measurement, calories and food group.

2. Viewing Recipes

To view existing recipes, the user selects a recipe from an alphabetical list of recipes. The application displays the full recipe to the user. The user can then choose to exit or display the selection bar of recipes.

3. Scaling a Recipe

The user can scale a recipe by a factor of 0.5, 2, or 3. The application prompts the user to enter the scaling factor, and then scales the recipe accordingly. The application then displays the new scaled recipe to the user. The user can choose to exit or display the selection bar of recipes.

4. Resetting a Recipe

The user can reset a recipe to its original quantities. The application prompts the user to select a recipe to reset, and then resets the recipe. The application displays the original recipe to the user. The user can choose to exit or display the selection bar of recipes.

5. Clearing Recipes

The user can clear all the recipes stored in the application by entering "Yes" when prompted. The application will delete all the existing recipes. If there are no recipes in the application, the application will notify the user. If the user enters "No", the application will exit.

6. Running the Application

To run the application, compile and execute the `Part2` class. The application will prompt the user to select one of the following options:

- `Create Recipe`: Create a new recipe
- `View Recipe`: View an existing recipe
- `Scale Recipe`: Scale an existing recipe
- `Reset Recipe`: Reset an existing recipe
- `Clear Recipe`: Clear all existing recipes
- `Quit`: Exit the application

Code Overview:

- The code uses a List<> collection to store the recipes.
- The Recipe class has methods to add ingredients and steps, scale the recipe, and reset the recipe to its original values.
- The code uses a while loop to allow the user to continue adding recipes.
- The recipes are sorted alphabetically and the user can select one to view its full details.
- The program also includes error handling for invalid inputs.

Contributors:

This code was written by Jabulani Sithabiso Dhludhlu.
