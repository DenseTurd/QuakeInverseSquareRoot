using System;

namespace QuakeInverseSquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 9;
            Console.WriteLine("Inverse square root of {0}", n);
            Console.WriteLine($"Actual: {1 / MathF.Sqrt(n)}");
            Console.WriteLine($"Approximate: {QInvSqRt(n)}");
        }

        // The method Quake used to quickly estimate inverse square root.
        // Accurate to within 1%
        // I think they used it for normal calculations, reflecting projectiles an ting?
        // https://www.youtube.com/watch?v=p8u_k2LIZyo << great explanation, could help you if you wanted to make the code safe
        // Something to do with the pointers
        // The pointers are used to get the raw bits from a float into a long, 
        // including the floating point bits,
        // which is basically the log or something.
        // There might be an elegant solution to this in C#.
        static unsafe float QInvSqRt(float num)
        {
            long i;
            float x2, y;
            const float threeHalfs = 1.5f;

            x2 = num * 0.5f;
            y = num;
            i = *(long*)&y;
            i = 0x5f3759df - (i >> 1);
            y = *(float*)&i;
            y = y * (threeHalfs - (x2 * y * y));

            return y;
        }
    }
}
