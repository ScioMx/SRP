using System;
using System.Collections.Generic;

namespace Calculator.Separation
{
    public enum Operations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Equal
    }

    public class Calculator
    {
        protected static Dictionary<string, Operations> OperationsDic = new Dictionary<string, Operations>
        {
            {"+", Operations.Addition},
            {"-", Operations.Subtraction},
            {"*", Operations.Multiplication},
            {"/", Operations.Division},
            {"=", Operations.Equal},
        };

        public static double Compute(Operations operation, double first, double second)
        {
            double result;

            switch (operation)
            {
                case Operations.Addition:
                    result = first + second;
                    break;
                case Operations.Subtraction:
                    result = first - second;
                    break;
                case Operations.Multiplication:
                    result = first * second;
                    break;
                case Operations.Division:
                    result = first / second;
                    break;
                case Operations.Equal:
                    result = first;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("operation");
            }

            return result;
        }

        public static double Compute(string operation, double first, double second)
        {
            if (OperationsDic.ContainsKey(operation))
            {
                return Compute(OperationsDic[operation], first, second);
            }

            throw new ArgumentException("operation");
        }
    }
}
