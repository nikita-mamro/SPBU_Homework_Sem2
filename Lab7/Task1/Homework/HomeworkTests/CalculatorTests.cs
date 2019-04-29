using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [DataRow("1", "1")]
        [DataRow("1+1", "2")]
        [DataRow("1+-1", "0")]
        [DataRow("1+999999", "1000000")]
        [DataRow("1,234 + 1000000,3454", "1000001.5794")]
        [DataRow("1+-999999", "-999998")]
        [DataRow("999999+1", "1000000")]
        [DataRow("999999+-1", "999998")]
        [DataRow("1000000+1234567", "2234567")]
        [DataRow("1000000+-1234567", "-234567")]
        [DataRow("1-2", "-1")]
        [DataRow("1--2", "3")]
        [DataRow("2-1", "1")]
        [DataRow("-2--1", "-1")]
        [DataRow("1000000-1", "999999")]
        [DataRow("1000000--1", "1000001")]
        [DataRow("313,4151-124,125", "189.2901")]
        [DataRow("1-1000000", "-999999")]
        [DataRow("1--1000000", "1000001")]
        [DataRow("-12345678--12345678", "0")]
        [DataRow("0×1", "0")]
        [DataRow("0×-1", "0")]
        [DataRow("1×0", "0")]
        [DataRow("-1×0", "0")]
        [DataRow("0×999999", "0")]
        [DataRow("0×-999999", "0")]
        [DataRow("999999×0", "0")]
        [DataRow("-999999×0", "0")]
        [DataRow("4253,112×24145,3222", "102692759.5927")]
        [DataRow("5×7", "35")]
        [DataRow("5×-7", "-35")]
        [DataRow("-5×7", "-35")]
        [DataRow("-5×-7", "35")]
        [DataRow("10×999999", "9999990")]
        [DataRow("10×-999999", "-9999990")]
        [DataRow("-10×999999", "-9999990")]
        [DataRow("-10×-999999", "9999990")]
        [DataRow("76684×25235", "1935120740")]
        [DataRow("-76684×25235", "-1935120740")]
        [DataRow("76684×-25235", "-1935120740")]
        [DataRow("76684×25235", "1935120740")]
        [DataRow("0÷1", "0")]
        [DataRow("0÷-1", "0")]
        [DataRow("0÷132245635", "0")]
        [DataRow("0÷-132245635", "0")]
        [DataRow("10÷341", "0.0293")]
        [DataRow("-10÷341", "-0.0293")]
        [DataRow("10÷-341", "-0.0293")]
        [DataRow("-10÷-341", "0.0293")]
        [DataRow("10÷2", "5")]
        [DataRow("10÷-2", "-5")]
        [DataRow("-10÷2", "-5")]
        [DataRow("-10÷-2", "5")]
        [DataRow("100000000÷5", "20000000")]
        [DataRow("24125,3462÷1241,1241", "19.4383")]
        [DataRow("(2+3)×(-8--1)÷2", "-17.5")]
        public void CalculateTest(string expression, string expected)
        {
            _ = double.TryParse(expected, NumberStyles.Any, CultureInfo.InvariantCulture, out double expectedDouble);
            Assert.IsTrue(Math.Abs(Calculator.Calculate(expression) - expectedDouble) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        [DataRow("1÷0")]
        [DataRow("1÷(100-100)")]
        public void DividingByZeroExceptionTest(string expression)
        {
            Calculator.Calculate(expression);
        }
    }
}