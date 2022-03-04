// See https://aka.ms/new-console-template for more information
using CookieMonsterAssistant.Ingrediens;
using CookieMonsterAssistant.Recipe;

start.Converter();
string Path = @"C:\Users\DarkArt\Desktop\Recipe.csv";
var Recipe = ReadCSV(Path);

foreach (var Ingre in Recipe)
{
    Console.WriteLine(Ingre.Amount + " " + Ingre.Measure + " " + Ingre.Ingredient + " " + Ingre.Description);
}

static List<Ingre> ReadCSV(string path)
{

    return File.ReadAllLines(path).Skip(1).ToList()
    .Where(row => row.Length > 0)
    .Select(Ingre.ParseRow).ToList();
}


