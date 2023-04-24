using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorForUnitTests
{
    public class InterfaceForUser
    {
        private static InterfaceForUser Singleton;
        public Regex ForProofCh = new Regex(@"(^\d+,\d+$)|(^\d+$)");
        public Regex ForProofZn = new Regex(@"^[+-/*/]$");
        public List<string> History = new List<string>();
        public delegate void UserInputExpression(InputExpression inputExpression, int TestStatus = 0);
        public event UserInputExpression NotifyAboutUserInputExpression;
        private InterfaceForUser()
        {
            NotifyAboutUserInputExpression += CalculateExpression;
        }
        public static InterfaceForUser GetInterfaceForUser()
        {
            if (Singleton is null)
            {
                Singleton = new InterfaceForUser();
                return Singleton;
            }
            else
            {
                return Singleton;
            }
        }
        public void StartCalculation()
        {
            Console.Clear();
            Console.WriteLine("Введите выражение для расчета (Для просмотра истории введите -SH)");
            string expression = Console.ReadLine();
            if (expression == "-SH")
            {
                SeenHistory();
                Console.ReadKey();
                Console.Clear();
                StartCalculation();
            }
            if (ValidationInput(expression))
            {
                NotifyAboutUserInputExpression(new InputExpression(expression));
            }
            else
            {
                Console.WriteLine("Выражение введенно неверно, повторите ввод:");
                StartCalculation();
            }
        }
        //private bool ValidationInput(string StrForVal) => Regex.IsMatch(StrForVal, @"(?=((^\d+,\d+)|(^\d+)))(?=.+\s[+-/*/]\s.+)(?=((.+\d+,\d+$)|(.+\d+$)))");
        private bool ValidationInput(string StrForVal) => Regex.IsMatch(StrForVal.Split(" ")[0], @"(^\d+,\d+$)|(^\d+$)")
                && Regex.IsMatch(StrForVal.Split(" ")[1], @"^[+-/*/]$")
                && Regex.IsMatch(StrForVal.Split(" ")[2], @"(^\d+,\d+$)|(^\d+$)");
        public void CalculateExpression(InputExpression inputExpression, int TestStatus = 0)
        {
            double Res = inputExpression.Operation switch
            {
                InputExpression.AlgbOper.Addition => Calculator.GetCalculator().Addition(inputExpression.numbers[0], inputExpression.numbers[1]),
                InputExpression.AlgbOper.Subtraction => Calculator.GetCalculator().Subtraction(inputExpression.numbers[0], inputExpression.numbers[1]),
                InputExpression.AlgbOper.Multiply => Calculator.GetCalculator().Multiplication(inputExpression.numbers[0], inputExpression.numbers[1]),
                InputExpression.AlgbOper.Divide => Calculator.GetCalculator().Division(inputExpression.numbers[0], inputExpression.numbers[1])
            };
            History.Add(inputExpression + " = " + $"{Res}");
            if(TestStatus == 0)
            {
                Console.Clear();
                Console.WriteLine(Res);
                Console.ReadKey();
                StartCalculation();
            }
        }
        private void SeenHistory()
        {
            foreach (var StrHistory in History)
            {
                Console.WriteLine(StrHistory);
            }
        }
    }
}
