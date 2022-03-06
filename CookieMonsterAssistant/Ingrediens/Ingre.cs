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

        public static bool Directions = false;
        public static bool Ingridients = false;
        public static bool End = false;





        internal static Ingre ParseRow(string row)
        {
            

            var columns = row.Split(',');

            if ((columns.Length == 3 && Ingridients == true) || row.StartsWith("Ingredients:"))
            {
                Ingridients = true;
                End = false;
                Directions = false;


                if (row.StartsWith("Ingredients:"))
                {
                    
                }

                else
                    {

                    ConvertMeasurementsAndAmounts(columns);
                    return new Ingre()
                {
                    Amount = decimal.Parse((columns[0])),
                    Measure = columns[1],
                    Ingredient = columns[2],
                    Description = ""

                };
                    }
                

            }



            else if ((columns.Length == 4 && Ingridients == true) || row.StartsWith("Ingredients:") )
            {
                Ingridients = true;
                End = false;
                Directions = false;
                ConvertMeasurementsAndAmounts(columns);
                return new Ingre()
                {
                    Amount = decimal.Parse((columns[0])),
                    Measure = columns[1],
                    Ingredient = columns[2],
                    Description = columns[3]

                };

            }
            else if (row.StartsWith("Directions:") || Directions == true)
            {
                    Directions = true;
                    Ingridients = false;
                    End = false;
                return new Ingre()
                {
                    Description = row,
                    Amount = 420
                    

                };

            }
            return new Ingre();
            
            }

        private static void ConvertMeasurementsAndAmounts(string[] columns)
        {
            ThreeFourths(columns);
            OneAndaHalf(columns);
            TwoAndTwoThirds(columns);
            OneAndaFourth(columns);
            CupsToDeci(columns);
            TeaspoonEquiv(columns);
            TwelveOunces(columns);
        }

        private static void TwelveOunces(string[] columns)
        {
            if (columns[1].ToLower().Contains(" package (12 ounces)"))
            {
                columns[1] = "packet (340g)";
            }
        }

        private static void TeaspoonEquiv(string[] columns)
        {
            if (columns[1].Trim().ToLower().Contains("teaspoon"))
            {
                columns[1] = "Tesked";
            }
        }

        private static void CupsToDeci(string[] columns)
        {
            if (columns[1].Contains("cups") || columns[1].Contains("cup"))
            {
                columns[1] = "DL";
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

    }

}
