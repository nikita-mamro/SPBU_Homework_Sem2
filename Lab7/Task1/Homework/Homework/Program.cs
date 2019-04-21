using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string s = "21,3×(-0,143--12÷-8+1,02)+(2,4-22)";

            var kek = Convertors.NotationConverter.SeparateCorrectExpression(s);

            var res = Convertors.NotationConverter.InfixToReversePolishNotation(s);

            var x = Calculator.Calculator.Calculate(s);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CalculatorForm());
        }
    }
}
