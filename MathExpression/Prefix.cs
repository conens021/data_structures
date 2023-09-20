using DataStructures.Lists;

namespace DataStructures.MathExpression
{
    public static class Prefix
    {
        public static double Execute(string value)
        {
            TheStack<double> operands = new();

            string[] values = Shared.SplitOperants(value);

            for (int i = values.Length - 1; i >= 0; i--)
            {
                string current = values[i];

                if (Shared.IsOperator(current))
                {
                    double x = operands.Pop();
                    double y = operands.Pop();

                    var res = Shared.Calc(current, x, y);

                    operands.Push(res);
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
