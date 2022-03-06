using CookieMonsterAssistant.Ingrediens;
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
            foreach (var Ingre in Recipe)
            {
                Console.WriteLine(Ingre.Amount * HowMany + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
            }
        }


    }
}
