using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForUnitTests
{
    /// <summary>
    /// Класс калькулятор
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Поле хранящее в себе текущую копию калькулятора
        /// </summary>
        public static Calculator Singleton{get; private set;}
        /// <summary>
        /// Приватный конструктор
        /// </summary>
        private Calculator()
        {
        }
        /// <summary>
        /// Суммирование двух чисел
        /// </summary>
        /// <param name="FirstDouble">Число №1</param>
        /// <param name="SecondDouble">Число №2</param>
        /// <returns>Сумма двух чисел</returns>
        public double Addition(double FirstDouble, double SecondDouble) => FirstDouble + SecondDouble;
        /// <summary>
        /// Разность чисел
        /// </summary>
        /// <param name="FirstDouble">Число №1</param>
        /// <param name="SecondDouble">Число №2</param>
        /// <returns>Результат вычитания из числа 1, числа 2</returns>
        public double Subtraction(double FirstDouble, double SecondDouble) => FirstDouble - SecondDouble;
        /// <summary>
        /// Умножение чисел
        /// </summary>
        /// <param name="FirstDouble">Число №1</param>
        /// <param name="SecondDouble">Число №2</param>
        /// <returns>Результат перемножения двух чисел</returns>
        public double Multiplication(double FirstDouble, double SecondDouble) => FirstDouble * SecondDouble;
        /// <summary>
        /// Деление чисел
        /// </summary>
        /// <param name="FirstDouble">Число №1</param>
        /// <param name="SecondDouble">Число №2</param>
        /// <returns>Результат деления числа №1 на число №2</returns>
        public double Division(double FirstDouble, double SecondDouble) => FirstDouble / SecondDouble;
        /// <summary>
        /// Получение текущего экземпляра калькулятора
        /// </summary>
        public static Calculator GetCalculator()
        {
            if (Singleton is null)
            {
                Singleton = new Calculator();
                return Singleton;
            }
            else
            {
                return Singleton;
            }
        }
    }
}
