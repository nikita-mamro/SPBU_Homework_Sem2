using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationHandler;
using System;
using System.IO;

namespace OperationHandler.Tests
{
    /// <summary>
    /// Тесты исполнителя бинарных арифметических операций
    /// </summary>
    [TestClass()]
    public class OperationHandlerTests
    {
        /// <summary>
        /// Тест сложения пары чисел
        /// </summary>
        [TestMethod()]
        public void ProceedAdditionTest()
        {
            for (var operandA = -1000; operandA < 1000; ++operandA)
            {
                for (var operandB = -1000; operandB < 1000; ++operandB)
                {
                    if (operandA + operandB != OperationHandler.ProceedOperation(operandA, "+", operandB))
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        /// <summary>
        /// Тест перемножения пары чисел
        /// </summary>
        [TestMethod()]
        public void ProceedMultiplicationTest()
        {
            for (var operandA = -1000; operandA < 1000; ++operandA)
            {
                for (var operandB = -1000; operandB < 1000; ++operandB)
                {
                    if (operandA * operandB != OperationHandler.ProceedOperation(operandA, "*", operandB))
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        /// <summary>
        /// Тест вычитания числа из числа
        /// </summary>
        [TestMethod()]
        public void ProceedSubstractionTest()
        {
            for (var operandA = -1000; operandA < 1000; ++operandA)
            {
                for (var operandB = -1000; operandB < 1000; ++operandB)
                {
                    if (operandA - operandB != OperationHandler.ProceedOperation(operandA, "-", operandB))
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        /// <summary>
        /// Тест деления числа на число
        /// </summary>
        [TestMethod()]
        public void ProceedDivisionTest()
        {
            for (var operandA = -1000; operandA < 1000; ++operandA)
            {
                for (var operandB = -1000; operandB < 1000; ++operandB)
                {
                    if (operandB == 0)
                    {
                        continue;
                    }

                    if (operandA / operandB != OperationHandler.ProceedOperation(operandA, "/", operandB))
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        /// <summary>
        /// Тест выбрсывания исключения при попытке деления на 0
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroExceptionTest()
        {
            var operandB = 0;
            var theOperator = "/";

            for (var operandA = -1000; operandA < 1000; ++operandA)
            {
                OperationHandler.ProceedOperation(operandA, theOperator, operandB);
            }
        }

        /// <summary>
        /// Тесты того, что метод будет ругаться на переданный некорректно оператор
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void OperatorIsIncorrectSymbolExceptionTest()
        {
            OperationHandler.ProceedOperation(1, "?", 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void OperatorIsLongerThanOneSymbolExceptionTest()
        {
            OperationHandler.ProceedOperation(1, "operator", 1);
        }
    }
}