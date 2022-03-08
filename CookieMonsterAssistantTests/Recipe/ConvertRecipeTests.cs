using CookieMonsterAssistant.Ingrediens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CookieMonsterAssistant.Recipe.Tests
{
    [TestClass()]
    public class ConvertRecipeTests
    {
        [TestMethod()]
        public void AsksForHowManyPortionsAndMultipliesTest()
        {
            int HowMany = 2;
            Ingre NewIngre = new Ingre
            {
                Amount = 5
            };

            NewIngre.Amount *= HowMany;

            Assert.AreEqual(10, NewIngre.Amount);
        }
    }
}