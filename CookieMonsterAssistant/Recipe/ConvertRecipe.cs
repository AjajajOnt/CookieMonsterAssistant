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

                return File.ReadAllLines(path)
                .Where(row => row.Length > 0)
                .Select(Ingre.ParseRow).ToList();
            }
            foreach (var Ingre in Recipe)
            {
                Console.WriteLine(Ingre.Amount + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
            }
        }
        internal void RecipeConversionV()
        {
            string Path = @"C:\Users\DarkArt\Desktop\Recipe.csv";
            var Recipe = ReadCSV(Path);
            List<Ingre> ReadCSV(string path)
            {

                return File.ReadAllLines(path)
                .Where(row => row.Length > 0)
                .Select(Ingre.ParseRow).ToList();
            }
            foreach (var Ingre in Recipe)
            {
                Console.WriteLine(Ingre.Amount + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
            }
        }

    }
}
