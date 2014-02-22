using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class BitShift
    {
        public static object ShiftRight(int pellet1, int shiftSize)
        {
            return pellet1 >> shiftSize;
        }

        public static object ShiftRight(byte pellet1, int shiftSize)
        {
            return pellet1 >> shiftSize;
        }

        public static object ShiftLeft(byte pellet1, int shiftSize)
        {
            return pellet1 << shiftSize;
        }

        public object ShiftByte(byte pellet1, int shiftSize, ShiftDirection shiftDirection)
        {
            switch(shiftDirection)
            {
                case ShiftDirection.Left:
                    return ShiftLeft(pellet1, shiftSize);
                case ShiftDirection.Right:
                    return ShiftRight(pellet1, shiftSize);
            }
            throw new InvalidOperationException("Invalid shift direction provided.");
        }
    }

    public enum ShiftDirection
    {
        Left,
        Right
    }
}
