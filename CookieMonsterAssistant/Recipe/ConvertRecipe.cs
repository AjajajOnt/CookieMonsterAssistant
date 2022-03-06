using CookieMonsterAssistant.Ingrediens;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace CookieMonsterAssistant.Recipe
{
    internal class ConvertRecipe
    {
        public bool Directions = false;
        public bool Ingridients = false;
        public bool End = false;
        public int HowMany = 1;

        internal void RecipeConversion()
        {
            List<Ingre> Recipe = ReadsCSVfile();
            AsksForHowManyPortions(Recipe);
            PrintsIngridients(Recipe);
            PrintsInstructions(Recipe);
            Console.WriteLine("This recpie is for " + HowMany * 2 + " people.");
            Console.ReadKey();
        }

        private static List<Ingre> ReadsCSVfile()
        {
            string Path = @"C:\Users\DarkArt\Desktop\Recipe.csv";
            var Recipe = ReadCSV(Path);
            List<Ingre> ReadCSV(string path)
            {
                return File.ReadAllLines(path)
                .Where(row => row.Length > 0)
                .Select(Ingre.ParseRow).ToList();
            }

            return Recipe;
        }

        private void AsksForHowManyPortions(List<Ingre> Recipe)
        {
            Console.WriteLine("This recipie is for 2 people.");
            Console.WriteLine("Enter multiplication factor for the recipie. Standard is 1.");
            HowMany = int.Parse(Console.ReadLine());

            for (int i = 0; i < Recipe.Count; i++)

            {
                Recipe[i].Amount *= HowMany;
            }

            Console.Clear();
        }

        private static void PrintsIngridients(List<Ingre> Recipe)
        {
            foreach (var Ingre in Recipe)
            {
                if ((Ingre.Amount > 0 && Ingre.Amount < 420) || Ingre.Description.StartsWith("Ingredients:"))
                {
                    Console.WriteLine(Ingre.Amount + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
                }
            }
        }

        private static void PrintsInstructions(List<Ingre> Recipe)
        {
            foreach (var Ingre in Recipe)
            {
                if (Ingre.Amount >= 420)
                {
                    Console.WriteLine(Ingre.Description);
                }
            }
        }
    }
}