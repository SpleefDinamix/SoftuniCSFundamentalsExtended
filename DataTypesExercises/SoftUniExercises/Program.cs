using System;

namespace SoftUniExercises
{
    public class Program
    {
        public static void Main()
        {
            sbyte smallByte = -100;
            byte myByte = 128;
            int myInt1 = -3540;
            int myInt2 = 64876;
            uint uInt = 2147483648;
            int myInt3 = -1141583228;
            long myLong = -1223372036854775808;

            Console.WriteLine(smallByte + "\n" + myByte + "\n" + myInt1 + "\n" + myInt2 + "\n" + uInt);
            Console.WriteLine(myInt3 + "\n" + myLong);

        }
    }
}
