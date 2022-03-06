using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieMonsterAssistant.Ingrediens
{
    public class Ingre
    {
        public string Amount { get; set; }

        public string Measure { get; set; }


        public string Ingredient { get; set; }
        public string Description { get; set; }

        internal static Ingre ParseRow(string row)
        {
                var columns = row.Split(',');
            Console.WriteLine(columns.Length);
            if (columns.Length == 3)
            {
                if (columns[1].Trim() == "cups" || columns[1].Trim() == "cup")
                {
                    columns[1] += "2,3 DL";
                }
                return new Ingre()
                {
                    Amount = (columns[0]),
                    Measure = columns[1],
                    Ingredient = columns[2],
                    Description = ""
                    
                };                                                    
            }
            else if (columns.Length == 4)
            {
                if (columns[1].Trim() == "cups" || columns[1].Trim() == "cup")
                {
                    Console.WriteLine(columns[1]);
                    columns[1] = "2,3 DL";
                }
                return new Ingre()
                {
                    Amount = (columns[0]),
                    Measure = columns[1],
                    Ingredient = columns[2],
                    Description = columns[3]
                    
                };
            
            }
            
            return new Ingre();
        }
    }

}
