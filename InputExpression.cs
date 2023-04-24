using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForUnitTests
{
    public class InputExpression
    {
        public enum AlgbOper
        {
            Addition,
            Subtraction,
            Multiply,
            Divide
        }
        public double[] numbers { get;private set; } = new double[2];
        public AlgbOper? Operation { get; private set; } = null;
        public InputExpression(string InputString)
        {
            numbers[1] = Convert.ToDouble(InputString.Split(' ')[2]);
            numbers[0] = Convert.ToDouble(InputString.Split(' ')[0]);
            switch (InputString.Split(" ")[1])
            {
                case "+": Operation = AlgbOper.Addition; break;
                case "-": Operation = AlgbOper.Subtraction; break;
                case "*": Operation = AlgbOper.Multiply; break;
                case "/": Operation = AlgbOper.Divide; break;
            }
        }
        public override string ToString()
        {
            switch (Operation)
            {
                case AlgbOper.Addition: return $"{numbers[0]} + {numbers[1]}";
                case AlgbOper.Subtraction: return $"{numbers[0]} - {numbers[1]}";
                case AlgbOper.Multiply: return $"{numbers[0]} * {numbers[1]}";
                case AlgbOper.Divide: return $"{numbers[0]} / {numbers[1]}";
            }
            throw new Exception("Bug with expression operation");
        }
    }
}
