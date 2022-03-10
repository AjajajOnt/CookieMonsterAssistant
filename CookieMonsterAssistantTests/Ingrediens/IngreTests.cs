using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CookieMonsterAssistant.Ingrediens.Tests
{
    [TestClass()]
    public class IngreTests
    {
        [TestMethod()]
        public void OneAndaFourthTest()
        {
            string[] columns = new string[3];
            columns[0] =  "1 1/4" ;
            Ingre.OneAndaFourth(columns);
            Assert.AreEqual("1,25", columns[0]);


        }

        [TestMethod()]
        public void TwelveOuncesTest()
        {


            string[] columns = new string[3];
            columns[1] = " package (12 ounces)";
            Ingre.TwelveOunces(columns);
            Assert.AreEqual("packet (340g)", columns[1]);

        }

        [TestMethod()]
        public void TeaspoonEquivTest()
        {


            string[] columns = new string[3];
            columns[1] = "teaspoon";
            Ingre.TeaspoonEquiv(columns);
            Assert.AreEqual("Tesked", columns[1]);

        }

        [TestMethod()]
        public void CupsToDeciTest()
        {


            string[] columns = new string[3];
            columns[1] = "cups";
            Ingre.CupsToDeci(columns);
            Assert.AreEqual("DL", columns[1]);

        }

        [TestMethod()]
        public void ThreeFourthsTest()
        {


            string[] columns = new string[3];
            columns[0] = "3/4";
            Ingre.ThreeFourths(columns);
            Assert.AreEqual("0,75", columns[0]);

        }

        [TestMethod()]
        public void OneAndaHalfTest()
        {


            string[] columns = new string[3];
            columns[0] = "1 1/2";
            Ingre.OneAndaHalf(columns);
            Assert.AreEqual("1,50", columns[0]);
        }

        [TestMethod()]
        public void TwoAndTwoThirdsTest()
        {


            string[] columns = new string[3];
            columns[0] = "2 2/3";
            Ingre.TwoAndTwoThirds(columns);
            Assert.AreEqual("2,66", columns[0]);
        }
    }
}