using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1Tests
{
    [TestClass]
    public class TestBitShift
    {
        /// <summary>
        /// Test showing that shifting to the right by 3 is the same as 
        /// dividing an integer containing the result of 2 to the power of 3.
        /// </summary>
        [TestMethod]
        public void TestShiftRight_ShiftBy3()
        {
            var guineaPig = new BitShift();
            const int pellet1 = 345;
            const int shiftSize = 3;
            int divisor = (int)Math.Pow(2, shiftSize);

            Assert.AreNotEqual(shiftSize, divisor, "Test setup error");

            int truth = pellet1 / divisor;
            Assert.AreEqual(truth, BitShift.ShiftRight(pellet1, shiftSize));
        }

        /// <summary>
        /// Test showing that shifting to the right by 4 is the same as 
        /// dividing an integer containing the result of 2 to the power of 4.
        /// </summary>
        [TestMethod]
        public void TestShiftRight_ShiftBy4()
        {
            var guineaPig = new BitShift();
            const int pellet1 = 345;
            const int shiftSize = 4;
            int divisor = (int)Math.Pow(2, shiftSize);

            Assert.AreNotEqual(shiftSize, divisor, "Test setup error");

            int truth = pellet1 / divisor;
            Assert.AreEqual(truth, BitShift.ShiftRight(pellet1, shiftSize));
        }

        /// <summary>
        /// Test showing that shifting to the right by 8 is the same as 
        /// dividing an integer containing the result of 2 to the power of 8.
        /// </summary>
        [TestMethod]
        public void TestShiftRight_ShiftBy8()
        {
            var guineaPig = new BitShift();
            const int pellet1 = 34234225;
            const int shiftSize = 8;
            int divisor = (int)Math.Pow(2, shiftSize);

            Assert.AreNotEqual(shiftSize, divisor, "Test setup error");

            int truth = pellet1 / divisor;
            Assert.AreEqual(truth, BitShift.ShiftRight(pellet1, shiftSize));
        }
    }
}
