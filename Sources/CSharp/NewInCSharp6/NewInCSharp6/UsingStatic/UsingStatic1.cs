using System;

// Simplify the call to static methods of a class.
// In this case simplify  the calls to static methods of class Math.
using static System.Math;

namespace NewInCSharp6.UsingStatic
{
    public class UsingStatic1
    {
        public double DoSomeMath(double angle)
        {
            return Math.Sqrt(Sin(angle) + Cos(angle) + PI);
        }
    }
}
