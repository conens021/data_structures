using DataStructures.Lists;

namespace DataStructures.MathExpression
{
    public class Postfix
    {
        public static double Execute(string? postfixValue)
        {
            if (postfixValue == null) return 0;

            TheStack<double> operands = new();

            string[] values = Shared.SplitOperants(postfixValue);

            for (int i = 0; i < values.Length; i++)
            {
                string current = values[i];

                if (Shared.IsOperator(current))
                {
                    double y = operands.Pop();
                    double x = operands.Pop();

                    double result = Shared.Calc(current, x, y);

                    operands.Push(result);
                }
                else
                {
                    operands.Push(Convert.ToInt32(current));
                }
            }

            return operands.Pop();
        }

    }
}
