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
        internal void RecipeConversion()
        {
            string Path = @"C:\Users\DarkArt\Desktop\Recipe.csv";
            var Recipe = ReadCSV(Path);           
            List<Ingre> ReadCSV(string path)
            {

                return File.ReadAllLines(path).Skip(1).ToList()
                .Where(row => row.Length > 0)
                .Select(Ingre.ParseRow).ToList();
            }
            foreach (var Ingre in Recipe)
            {
                Console.WriteLine(Ingre.Amount + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
            }
        }
        private void addingre()
        {
            List<Ingre> ingre = new List<Ingre>();
            {
                new Ingre() { Description = "asd", Amount = "asd", Ingredient = "asd", Measure = "asd" };
              
            };                       
        }
    }
}
