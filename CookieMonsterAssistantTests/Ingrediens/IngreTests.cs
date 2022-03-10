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
            string columns = "cups";
            if (columns.Contains("cups") || columns.Contains("cup"))
            {
                columns = "DL";
            }
            Assert.AreEqual("DL", columns);
        }

        [TestMethod()]
        public void ThreeFourthsTest()
        {
            string columns = "3/4";
            if (columns.Contains("3/4"))
            {
                columns = "0,75";
            }
            Assert.AreEqual("0,75", columns);
        }

        [TestMethod()]
        public void OneAndaHalfTest()
        {
            string columns = "1 1/2";
            if (columns.Contains("1 1/2"))
            {
                columns = "1,50";
            }
            Assert.AreEqual("1,50", columns);
        }

        [TestMethod()]
        public void TwoAndTwoThirdsTest()
        {
            string columns = "2 2/3";
            if (columns.Contains("2 2/3"))
            {
                columns = "2,66";
            }
            Assert.AreEqual("2,66", columns);
        }
    }
}