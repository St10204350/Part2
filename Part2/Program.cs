
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace RecipeApplication
{
    public class Part2
    {
        List<Recipe_Application> recipes = new List<Recipe_Application>(); //generic collection to store the recipes 
        int option;
        int recipeName;
        public void RecipeDetails()
        {
            Console.Write("Enter the number of recipes you want to add: ");
            int numRecipe = int.Parse(Console.ReadLine()); //enter the number of recipe you want to add

            for (int j = 1; j <= numRecipe; j++) //loop until the numRecipe have details
            {
                Console.Write("Enter the name of recipe " + j + ": ");
                string recipeName = Console.ReadLine(); //enter the name of recipe

                Recipe_Application recipe = new Recipe_Application(recipeName); //create new Recipe object with name provided by user
                recipes.Add(recipe); //add recipe to generic collection of recipes
                Console.Write("Enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++) //loop until the numIngredients have details
                {
                    Console.Write("Enter the name of ingredient {0}: ", (i + 1));
                    string ingredientName = Console.ReadLine();
                    Console.Write("Enter the quantity of ingredient {0}: ", (i + 1));
                    double quantity = double.Parse(Console.ReadLine());

                    string unit;
                    while (true)
                    { //loop for selecting unit of measurement and validating the input
                        Console.Write("Select the unit of measurement of ingredient {0}: \n- Milligrams (mg) \n- Grams (g) \n- Milliliters (ml) \n- Litres (l) \n- Killograms (kg)" +
                                          "\n- Teaspoon (tsp) \n- Tablespoon (tbsp) \nEnter your choice: ", (i + 1));
                        unit = Console.ReadLine();

                        if (unit.ToLower() == "mg" || unit.ToLower() == "g" || unit.ToLower() == "ml" || unit.ToLower() == "l" || unit.ToLower() == "kg" || unit.ToLower() == "tsp"
                            || unit.ToLower() == "tbsp")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please select 'mg', 'g', 'ml', 'l', 'kg', 'tsp', 'tbsp'.");
                        }
                    }

                    Console.Write("Enter the number of calories in ingredient {0}: ", (i + 1));
                    int calories = int.Parse(Console.ReadLine());
                    Action<string> warningDelegate = (message) => Console.WriteLine("!!!Warning!!! " + message);

                    if (calories > 300)
                    {
                        // Set the Foreground color to DarkBlue
                        Console.ForegroundColor = ConsoleColor.Red;
                        warningDelegate("Calories exceed 300!");
                        // Set the Foreground color to DarkBlue
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }

                    string foodGroup;
                    while (true) //loop to ensure correct food group is entered
                    {
                        Console.Write("Enter the food group that ingredient {0} belongs to: \n1: Fruit and vegetables \n2: Starchy food \n3: Dairy \n4: Protein \n5: Fat " +
                                      "\nEnter your choice: ", (i + 1));
                        int foodGroupNumber = int.Parse(Console.ReadLine());

                        switch (foodGroupNumber)
                        {
                            case 1:
                                foodGroup = "Fruit and vegetables";
                                break;
                            case 2:
                                foodGroup = "Starchy food";
                                break;
                            case 3:
                                foodGroup = "Dairy";
                                break;
                            case 4:
                                foodGroup = "Protein";
                                break;
                            case 5:
                                foodGroup = "Fat";
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                continue; //continue loop for another input
                        }
                        break; //exit loop if correct input provided
                    }
                    ingredientStore ingredient = new ingredientStore(ingredientName, quantity, unit, calories, foodGroup); //create new Ingredient object with details provided by user
                    recipe.AddIngredient(ingredient); //add ingredient to recipe using method in Recipe class
                }

                Console.Write("Enter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine()); //enter the number step you'll need

                for (int i = 0; i < numSteps; i++)
                {
                    Console.Write("Enter step {0}: ", (i + 1));
                    string step = Console.ReadLine();
                    recipe.AddStep(step); //add step to recipe using method in Recipe class
                }
                Console.WriteLine("Recipe was successfully added"); //display the message if the recipe was successfully added
            }
        }

        public void DisplayResults()
        {
            if (recipes.Count > 0)
            {
                while (true)
                {
                    recipes.Sort(); //sort the recipe in alphabetical order
                    //Prompt to choose from the below option provided
                    Console.WriteLine("\nSelect a recipe to view or enter 999 to quit: ");

                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", (i + 1), recipes[i].Name); //display alphabetical list of recipes for user to choose from
                    }

                    Console.Write("Enter your choice: ");
                    int recipeNumber = int.Parse(Console.ReadLine()) - 1;

                    if (recipeNumber == 998)
                    {
                        break;
                    }
                    else
                    {
                        Recipe_Application selected_Recipe = recipes[recipeNumber];
                        Console.WriteLine(selected_Recipe.ToString()); //display full recipe to user
                        Message();
                        if (option == 0)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo recipe added!");
            }
        }

        public void ScaleRecipe()
        {
            if (recipes.Count > 0)
            {
                while (true)
                {
                    //Prompt to choose from the below option provided
                    Console.WriteLine("\nSelect a recipe to scale or enter 999 to quit: ");

                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", (i + 1), recipes[i].Name); //display alphabetical list of recipes for user to choose from
                    }

                    Console.Write("Enter your choice: ");
                    int recipeNumber = int.Parse(Console.ReadLine()) - 1;

                    if (recipeNumber == 998)
                    {
                        break;
                    }
                    Recipe_Application Recipeselected = recipes[recipeNumber];

                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    double factor = double.Parse(Console.ReadLine()); //enter the scalling factor

                    switch (factor)
                    {
                        case 0.5:
                        case 2:
                        case 3:
                            Recipeselected.Scale(factor);
                            Console.WriteLine("\nThe new scaled recipe is:" + Recipeselected.ToString()); //display the new scaled recipe 
                            Console.WriteLine("Recipe scaled succefully!");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                    Message();
                    if (option == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo recipe added!");
            }
        }

        public void ResetQuantities()
        {
            if (recipes.Count > 0)
            {
                while (true)
                {
                    Console.WriteLine("\nSelect a recipe to reset: ");

                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", (i + 1), recipes[i].Name); //display alphabetical list of recipes for user to choose from
                    }

                    Console.Write("Enter your choice: ");
                    int recipeNumber = int.Parse(Console.ReadLine()) - 1;
                    Recipe_Application selectedRecipe = recipes[recipeNumber];

                    selectedRecipe.Reset();
                    Console.WriteLine("\nThe original recipe is:" + selectedRecipe.ToString()); //display the original recipe
                    Console.WriteLine("Recipe reset succefully!");
                    Message();
                    if (option == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo recipe added!");
            }
        }

        public void ClearRecipe()
        {
            //Prompt to choose from the below option provided
            Console.WriteLine("Would you like to clear the data: Yes or No");
            string clear = Console.ReadLine();
            if (clear == "Yes")
            {
                if (recipes.Count > 0)
                {
                    recipes.Clear(); //Clear all the recipe
                    Console.WriteLine("\nRecipe has been cleared succefully!");
                }
                else
                {
                    Console.WriteLine("\nNo recipe added!");
                }   
            }
            else
            {
                Console.WriteLine("Thank you!!!");
            }
        }

        public void Message()
        {
            //Prompt to choose from the below option provided
            Console.Write("\nEnter 0 to quit or any number to display the selection bar of the recipes: ");
            option = int.Parse(Console.ReadLine());

                
        }
    }

    public class Recipe_Application : IComparable<Recipe_Application> //implement IComparable to allow sorting of recipes by name
    {
        public string Name { get; set; }
        public ingredientStore.CaloriesExceededEventHandler HandleCaloriesExceeded { get; private set; }
        private List<ingredientStore> ingredients = new List<ingredientStore>(); //generic collection to store ingredients
        private List<string> steps = new List<string>(); //generic collection to store steps 

        public Recipe_Application(string ingredintName)
        {
            Name = ingredintName;
        }

        public void AddIngredient(ingredientStore i)
        {
            ingredients.Add(i);
            i.CaloriesExceeded += HandleCaloriesExceeded; //subscribe to CaloriesExceeded event for each added ingredient
        }

        public void AddStep(string s)
        {
            steps.Add(s);
        }

        public void Scale(double factor)
        {
            foreach (ingredientStore i in ingredients)
            {
                i.Scale(factor); //scale each ingredient using method in Ingredient class
            }
        }

        public void Reset()
        {
            foreach (ingredientStore i in ingredients)
            {
                i.Reset(); //reset each ingredient to original quantity using method in Ingredient class
            }
        }

        public override string ToString()
        {
            string str = "\n\tRecipe name: " + Name + "\n\n\tIngredients:\n";

            foreach (ingredientStore i in ingredients)
            {
                str += "\t- " + i.ToString() + "\n"; //display each ingredient using ToString method in Ingredient class
            }

            str += "\n\tSteps:\n";

            for (int i = 0; i < steps.Count; i++)
            {
                str += "\tStep " + (i + 1) + ": " + steps[i] + "\n"; //display each step with a number prefix
            }

            int totalCalories = 0;

            foreach (ingredientStore i in ingredients)
            {
                totalCalories += i.Calories; //calculate total calories of all ingredients in recipe
            }

            if (totalCalories > 300)
            {
                // Set the Foreground color to Red
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t!!!Warning!!! \n\tTotal calories of recipe exceed 300!");
                // Set the Foreground color to DarkBlue
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

            str += "\n\tTotal calories: " + totalCalories; //display total calories of recipe

            foreach(ingredientStore i in ingredients)
            {
                str += "\n\t" + "("+ i.Name + ") " + "belongs to food group: " + i.FoodGroup; //display each ingredient with food group information
            }
            return str;
        }

        public int CompareTo(Recipe_Application other)
        {
            return Name.CompareTo(other.Name); //sorting the recipes
        }
    }

    public class ingredientStore
    {
        public string Name { get; set; }
        private double quantity;
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        private double originalQuantity;
        public int OriginalCalories;

        public delegate void CaloriesExceededEventHandler(object sender, EventArgs e); //declare delegate

        public event CaloriesExceededEventHandler CaloriesExceeded; //declare event

        public ingredientStore(string ingredintName, double quantity, string unit, int calories, string foodGroup)

        {
            Name = ingredintName;
            this.quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            OriginalCalories = calories;
            originalQuantity = quantity; //store original quantity for use in resetting

        }

        public void Scale(double factor)
        {
            quantity *= factor; //scale quantity by factor
            Calories = Convert.ToInt32(Calories * factor);
        }

        public void Reset()
        {
            quantity = originalQuantity; //reset quantity to original value
            Calories = OriginalCalories;
        }

        public override string ToString()
        {
            return quantity + " " + Unit + " of " + Name + " ("+Calories+ " calories)"; //display formatted string for ingredient
        }

        public double TotalCalories()
        {
            return quantity * Calories;
        }

        public void CheckCalories()
        {
            if (TotalCalories() > 300)
            {
                CaloriesExceeded?.Invoke(this, EventArgs.Empty);
            }
        }

        public void AddQuantity(double quantity) //add method to easily add quantity to ingredient
        {
            this.quantity += quantity;
            CheckCalories(); //check calories after adding quantity
        }

        private void HandleCaloriesExceeded(object sender, EventArgs e)
        {
            ingredientStore ingredient = (ingredientStore)sender; //cast sender object to Ingredient type
            Console.WriteLine("Warning: Total calories for " + ingredient.Name + " exceed 300!"); //output warning message
        }
    }

    class runClass
    {
        static void Main(string[] args)
        {
            List<Recipe_Application> recipes = new List<Recipe_Application>(); //generic collection to store the recipes 
            Part2 part2 = new Part2();

            // Set the Foreground color to DarkBlue
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            //Set the background color to White
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            try
            {
                Console.Write("\t**********<Welcome to the Recipe Application>**********");
                while (true) //loop to continue display menu
                {
                    Console.Write("\nWhat would you like to do?\n1. Add a new recipe\n2. View the recipe details \n3. Scale recipe \n4. Reset recipe" +
                                  "\n5. Clear recipe \n6. Exit\nEnter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            //dispaly the method from class Part2
                            part2.RecipeDetails();
                            break;
                        case 2:
                            //dispaly the method from class Part2
                            part2.DisplayResults();
                            break;
                        case 3:
                            //dispaly the method from class Part2
                            part2.ScaleRecipe();
                            break;
                        case 4:
                            //dispaly the method from class Part2
                            part2.ResetQuantities();
                            break;
                        case 5:
                            //dispaly the method from class Part2
                            part2.ClearRecipe();
                            break;
                        case 6:
                            Console.WriteLine("Thanks for using Recipe Application! Goodbye.");
                            Environment.Exit(0); //exit the program
                            break;

                        default:
                            Console.WriteLine("Invalid input"); //print if invalid input
                            break;
                    }
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input. Please enter a number."); //display this message when a user inputted a string instead of integer
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Invalid input. Please enter a valid option."); //dipslay this message if a user inpuuted invalid option from the code
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occurred. Please try again."); //show this meeage if the code has logical errors
            }

        }
    }
}



