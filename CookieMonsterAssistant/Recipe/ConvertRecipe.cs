using CookieMonsterAssistant.Ingrediens;
using CookieMonsterAssistant.Recipe;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            string Path = @"C:\Users\DarkArt\Desktop\Recipe.csv";
            var Recipe = ReadCSV(Path);           
            List<Ingre> ReadCSV(string path)
            {

                return File.ReadAllLines(path)
                .Where(row => row.Length > 0)
                .Select(Ingre.ParseRow).ToList();
            }

            Console.WriteLine("This recipie is for 2 people.");
            Console.WriteLine("Enter multiplication factor for the recipie. Standard is 1.");
            HowMany = int.Parse(Console.ReadLine());

            for (int i = 0; i < Recipe.Count; i++)

            {
                Recipe[i].Amount *= HowMany;

            }

            Console.Clear();

            foreach (var Ingre in Recipe)
            {
                if (Ingre.Amount > 0 && Ingre.Amount < 420)
                {


                    Console.WriteLine(Ingre.Amount + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
                }
            }

            foreach (var Ingre in Recipe)
            {
                if (Ingre.Amount >= 420)
                {
                    Console.WriteLine(Ingre.Description);

                }
  
                    
                
            }
            Console.WriteLine("This recpie is for " + HowMany * 2 + " people.");
            Console.ReadKey();

        }


    }
}
