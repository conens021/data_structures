using DataStructures.Lists;
using System.Text;

namespace DataStructures.MathExpression
{
    public static class InfixConvertor
    {
        public static string ToPostfix(string value)
        {
            if (value == null)
                throw new ArgumentNullException("cannot be null!");

            StringBuilder sb = new();
            string[] tokens = ProccessInfixString(value);
            TheStack<string> operators = new();

            for (int i = 0; i < tokens.Length; i++)
            {
                string currentToken = tokens[i];

                if (Shared.IsOperator(currentToken))
                {
                    //Add opertaor to string only if
                    //1.operators stack is not empty
                    //2.Current token is not '(' , or ')'
                    //3.Top Operator Is Greater then current operator 
                    while (!operators.IsEmpty()
                        && !IsParantess(currentToken)
                        && OperatorIsGreater(operators.GetTop(), currentToken))
                    {
                        sb.Append($"{operators.Pop()},");
                    }

                    AddOperator(operators, currentToken, sb);
                }
                else
                    sb.Append($"{currentToken},");
            }

            while (!operators.IsEmpty())
            {
                if (operators.IsLast())
                    sb.Append(operators.Pop());

                else
                    sb.Append($"{operators.Pop()},");

            }


            return sb.ToString();
        }

        private static bool IsParantess(string currentToken)
        {
            return (currentToken == "(" || currentToken == ")");
        }

        private static bool OperatorIsGreater(string? currentTop, string currentToken)
        {
            //Nothing is greater then opening parantess
            if (currentTop == "(") return false;

            //next is multiplication and division
            if (currentTop == "*" || currentTop == "/")
                return true;

            //then if current top and current token is + or -
            else if ((currentTop == "+" || currentTop == "-")
                        && (currentToken == "+" || currentToken == "-"))
                return true;

            else return false;
        }

        private static void AddOperator(TheStack<string> operators, string current, StringBuilder sb)
        {
            if (current == ")")
            {
                while (operators.GetTop() != "(")
                {
                    if (operators.IsEmpty()) break;

                    sb.Append($"{operators.Pop()},");
                }

                //for poping '('
                operators.Pop();

                return;
            }

            operators.Push(current);
        }

        private static string[] ProccessInfixString(string value)
        {
            value = value.Replace(" ", "");
            value = value.Replace("+", " + ");
            value = value.Replace("-", " - ");
            value = value.Replace("*", " * ");
            value = value.Replace("/", " / ");
            value = value.Replace("(", " ( ");
            value = value.Replace(")", " ) ");

            value = value.Replace("  ", " ");

            value = value.Trim();


            string[] splited = value.Split(' ');

            return splited;
        }
    }
}
