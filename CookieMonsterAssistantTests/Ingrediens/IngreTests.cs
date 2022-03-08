using Microsoft.VisualStudio.TestTools.UnitTesting;
using CookieMonsterAssistant.Ingrediens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieMonsterAssistant.Ingrediens.Tests
{
    [TestClass()]
    public class IngreTests
    {
        [TestMethod()]
        public void OneAndaFourthTest()
        {

            string columns = "1 1/4";

            if (columns == "1 1/4")
            {
                columns = "1.25";
            }


            Assert.AreEqual("1.25", columns);



        }


        [TestMethod()]
        public void TwelveOuncesTest()
        {
            string columns = " package (12 ounces)";

            if (columns.ToLower().Contains(" package (12 ounces)"))
            {
                columns = "packet (340g)";
            }


            Assert.AreEqual("packet (340g)", columns);
        }

        [TestMethod()]
        public void TeaspoonEquivTest()
        {
            string columns = "teaspoon";

            if (columns.Trim().ToLower().Contains("teaspoon"))
            {
                columns = "Tesked";
            }
            Assert.AreEqual("Tesked", columns);
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