using CookieMonsterAssistant.Ingrediens;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace CookieMonsterAssistant.Recipe
{
    public class ConvertRecipe
    {
        public int HowMany = 1;

        /// <summary>
        /// Kör alla metoder i ordning.
        /// </summary>
        internal void RecipeConversion()
        {
            List<Ingre> Recipe = ReadsCSVfile();
            AsksForHowManyPortionsAndMultiplies(Recipe);
            PrintsIngridients(Recipe);
            PrintsInstructions(Recipe);
            Console.WriteLine();
            Console.WriteLine("This recpie is for " + HowMany * 2 + " people.");
            Console.ReadKey();
        }

        /// <summary>
        /// Läser CSV filen.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Multiplicerar receptet till antalet du vill ha.
        /// </summary>
        /// <param name="Recipe"></param>
        public void AsksForHowManyPortionsAndMultiplies(List<Ingre> Recipe)
        {
            Console.WriteLine("This recipie is for 2 people.");
            Console.WriteLine("Enter multiplication factor for the recipie. Standard is 1.");
            try
            {
                HowMany = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                HowMany = 1;
            }

            for (int i = 0; i < Recipe.Count; i++)

            {
                Recipe[i].Amount *= HowMany;
            }

            Console.Clear();
        }

        /// <summary>
        /// Skriver ut ingridienser, mått o sånt.
        /// </summary>
        /// <param name="Recipe"></param>
        public static void PrintsIngridients(List<Ingre> Recipe)
        {
            foreach (var Ingre in Recipe)
            {
                if ((Ingre.Amount > 0 && Ingre.Amount < 420) || Ingre.Description.StartsWith("Ingredients:"))
                {
                    Console.WriteLine(Ingre.Amount + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
                }
            }
        }

        /// <summary>
        /// Skriver ut instruktioner.
        /// </summary>
        /// <param name="Recipe"></param>
        private static void PrintsInstructions(List<Ingre> Recipe)
        {
            foreach (var Ingre in Recipe)
            {
                if (Ingre.Amount >= 420 && !Ingre.Description.Contains("End:"))
                {
                    Console.WriteLine(Ingre.Description);
                }
            }
        }
    }
}