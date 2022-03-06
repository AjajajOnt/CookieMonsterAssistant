using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieMonsterAssistant.Ingrediens
{
    public class Ingre
    {
        public decimal Amount { get; set; }

        public string Measure { get; set; }


        public string Ingredient { get; set; }
        public string Description { get; set; }


        bool Directions = false;
        bool Ingridients = false;
        bool End = false;

        internal static Ingre ParseRow(string row)
        {
            bool Directions = false;
            if (Directions == true || row.Contains("Directions:"))
            {
                Directions = true;
                return ConvertIngri(row);

            }
            return ConvertIngri(row);
        }

        private static Ingre ConvertIngri(string row)
        {
            if (true)
            {

            
            var columns = row.Split(',');
            if (columns.Length == 3 Directions == true)
            {
                ThreeFourths(columns);
                OneAndaHalf(columns);
                TwoAndTwoThirds(columns);
                OneAndaFourth(columns);
                return new Ingre()
                {
                    Amount = decimal.Parse((columns[0])),
                    Measure = columns[1],
                    Ingredient = columns[2],
                    Description = ""

                };
            }
            else if (columns.Length == 4)
            {
                ThreeFourths(columns);
                OneAndaHalf(columns);
                TwoAndTwoThirds(columns);
                OneAndaFourth(columns);
                return new Ingre()
                {
                    Amount = decimal.Parse((columns[0])),
                    Measure = columns[1],
                    Ingredient = columns[2],
                    Description = columns[3]

                };

            }
            else
            {
                Console.WriteLine(row);
            }
            return new Ingre();
            }
        }



        private static void ThreeFourths(string[] columns)
        {
            if (columns[0].Contains("3/4"))
            {
                columns[0] = "0,75";
            }
        }

        private static void OneAndaHalf(string[] columns)
        {
            if (columns[0].Contains("1 1/2"))
            {
                columns[0] = "1,50";
            }
        }

        private static void TwoAndTwoThirds (string[] columns)
        {
            if (columns[0].Contains("2 2/3"))
            {
                columns[0] = "2,66";
            }
        }
        private static void OneAndaFourth(string[] columns)
        {
            if (columns[0].Contains("1 1/4"))
            {
                columns[0] = "1,25";
            }
        }

        private static void CupsToDl(string[] columns)
        {
            if (columns[1].Trim() == "cups" || columns[1].Trim() == "cup")
            {
                columns[1] = "2,3 DL";
            }
        }
    }

}
