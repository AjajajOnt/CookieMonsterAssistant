using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieMonsterAssistant.Ingrediens
{
    public class Ingre
    {

        public int Amount { get; set; }
        public int Measure { get; set; }
        public string Ingredient { get; set; }
        public string Description { get; set; }

        internal static Ingre ParseRow(string row)
        {
            
            
            
                var columns = row.Split(',');
                return new Ingre()
                {
                    Amount = int.Parse(columns[0]),
                    Measure = int.Parse(columns[1]),
                    Ingredient = (columns[2]),
                    Description = columns[3],

                };

            
            
        }
    }
}
