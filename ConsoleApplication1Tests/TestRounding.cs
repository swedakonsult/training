using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ConsoleApplication1Tests
{
    [TestClass]
    public class TestRounding
    {
        [TestMethod]
        public void TestRoundToInt_PositiveFloat()
        {
            var guineaPig = new Rounding();

            const int expected = 4;
            int result;
            float pellet;

            result = 0;
            pellet = 4.233F;
            result = guineaPig.RoundToInt(pellet);
            Assert.AreEqual(expected, result);

            result = 0;
            pellet = 4.73F;
            result = guineaPig.RoundToInt(pellet);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRoundToInt_NegativeFloat()
        {
            var guineaPig = new Rounding();

            const int expected = -4;
            int result;
            float pellet;

            result = 0;
            pellet = -4.233F;
            result = guineaPig.RoundToInt(pellet);
            Assert.AreEqual(expected, result);

            result = 0;
            pellet = -4.73F;
            result = guineaPig.RoundToInt(pellet);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRoundToByte_PositiveFloat()
        {
            var guineaPig = new Rounding();

            const byte expected = 4;
            int result;
            float pellet;

            result = 0;
            pellet = 4.233F;
            result = guineaPig.RoundToByte(pellet);
            Assert.AreEqual(expected, result);

            result = 0;
            pellet = 4.73F;
            result = guineaPig.RoundToByte(pellet);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRoundToByte_NegativeFloat()
        {
            var guineaPig = new Rounding();

            const byte expected = 256-4;
            byte result;
            float pellet;

            result = 0;
            pellet = -4.233F;
            result = guineaPig.RoundToByte(pellet);
            Assert.AreEqual(expected, result);

            result = 0;
            pellet = -4.73F;
            result = guineaPig.RoundToByte(pellet);
            Assert.AreEqual(expected, result);
        }
    }
}
