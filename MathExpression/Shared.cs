namespace DataStructures.MathExpression
{
    internal static class Shared
    {
        private static readonly string[] Operators =
       new string[] { "+", "-", "*", "/", "(", ")" };

        internal static bool IsOperator(string value)
        {
            return Operators.Contains(value);
        }

        internal static string[] SplitOperants(string value)
        {
            return value.Split(",");
        }

        internal static double Calc(string operatorValue, double operandX, double operandY)
        {
            switch (operatorValue)
            {
                case "+":
                    return operandX + operandY;

                case "-":
                    return operandX - operandY;


                case "*":
                    return operandX * operandY;

                case "/":
                    return operandX / operandY;


                default:

                    throw new ArgumentException($"Unknow operator: {operatorValue}");
            }
        }

    }
}
