using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace CalculatorForUnitTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InterfaceForUser.GetInterfaceForUser().StartCalculation();
        }
    }
}