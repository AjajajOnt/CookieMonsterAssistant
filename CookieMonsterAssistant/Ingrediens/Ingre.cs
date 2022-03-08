namespace CookieMonsterAssistant.Ingrediens
{
    public class Ingre
    {
        public float Amount { get; set; }

        public string? Measure { get; set; }

        public string? Ingredient { get; set; }
        public string? Description { get; set; }

        public static bool Directions = false;
        public static bool Ingridients = false;
        public static bool End = false;

        /// <summary>
        /// Bryter ner raderna och konverterar ingridienserna
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
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
                    return new Ingre()
                    {

                        Description = columns[0]
                    };
                }
                else
                {
                    ConvertMeasurementsAndAmounts(columns);
                    return new Ingre()
                    {
                        Amount = float.Parse((columns[0])),
                        Measure = columns[1],
                        Ingredient = columns[2],
                        Description = ""
                    };
                }
            }
            else if ((columns.Length == 4 && Ingridients == true) || row.StartsWith("Ingredients:"))
            {
                Ingridients = true;
                End = false;
                Directions = false;
                ConvertMeasurementsAndAmounts(columns);
                return new Ingre()
                {
                    Amount = float.Parse((columns[0])),
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
        /// <summary>
        /// Konverterar måtten till svenska mått.
        /// </summary>
        /// <param name="columns"></param>
        public static void ConvertMeasurementsAndAmounts(string[] columns)
        {
            ThreeFourths(columns);
            OneAndaHalf(columns);
            TwoAndTwoThirds(columns);
            OneAndaFourth(columns);
            CupsToDeci(columns);
            TeaspoonEquiv(columns);
            TwelveOunces(columns);
        }
        /// <summary>
        /// Konverterar mått
        /// </summary>
        /// <param name="columns"></param>
        public static void TwelveOunces(string[] columns)
        {
            if (columns[1].ToLower().Contains(" package (12 ounces)"))
            {
                columns[1] = "packet (340g)";
            }
        }
        /// <summary>
        /// Konverterar mått
        /// </summary>
        /// <param name="columns"></param>
        public static void TeaspoonEquiv(string[] columns)
        {
            if (columns[1].Trim().ToLower().Contains("teaspoon"))
            {
                columns[1] = "Tesked";
            }
        }
        /// <summary>
        /// Konverterar mått
        /// </summary>
        /// <param name="columns"></param>
        public static void CupsToDeci(string[] columns)
        {
            if (columns[1].Contains("cups") || columns[1].Contains("cup"))
            {
                columns[1] = "DL";
            }
        }
        /// <summary>
        /// Konverterar mått
        /// </summary>
        /// <param name="columns"></param>
        public static void ThreeFourths(string[] columns)
        {
            if (columns[0].Contains("3/4"))
            {
                columns[0] = "0,75";
            }
        }
        /// <summary>
        /// Konverterar mått
        /// </summary>
        /// <param name="columns"></param>
        public static void OneAndaHalf(string[] columns)
        {
            if (columns[0].Contains("1 1/2"))
            {
                columns[0] = "1,50";
            }
        }
        /// <summary>
        /// Konverterar mått
        /// </summary>
        /// <param name="columns"></param>
        public static void TwoAndTwoThirds(string[] columns)
        {
            if (columns[0].Contains("2 2/3"))
            {
                columns[0] = "2,66";
            }
        }
        /// <summary>
        /// Konverterar mått
        /// </summary>
        /// <param name="columns"></param>
        public static void OneAndaFourth(string[] columns)
        {
            if (columns[0].Contains("1 1/4"))
            {
                columns[0] = "1,25";
            }
        }
    }
}