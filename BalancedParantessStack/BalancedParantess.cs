using DataStructures.Lists;

namespace DataStructures.BalancedParantessStack
{
    public class BalancedParantess
    {
        public static bool ValidateBalanced(string someTestString)
        {
            bool isBalanced = true;
            TheStack<char> openedParanhess = new(someTestString.Length);
            int row = 1;

            for (int i = 0; i < someTestString.Length; i++)
            {
                char currentChar = someTestString[i];

                if (!ValidateChar(ref row, currentChar, openedParanhess))
                    break;
            }

            if (!openedParanhess.IsEmpty())
                isBalanced = false;

            if (!openedParanhess.IsEmpty())
                throw new Exception($"'{openedParanhess.Pop()}' does not have a closing tag! in a row {row}");



            return isBalanced;
        }

        private static bool ValidateChar(ref int row, char currentChar, TheStack<char> openedParanhess)
        {
            if (currentChar == '\n')
            {
                row++;

                return true;
            }

            else if (IsOpeningParanthess(currentChar))
            {
                openedParanhess.Push(currentChar);

                return true;
            }

            else if (IsClosingParanthess(currentChar))
            {
                if (openedParanhess.IsEmpty())
                    throw new Exception($"There is no opening paranhess for closing tag {currentChar} in row {row}");

                else
                {
                    char lastOpened = openedParanhess.GetTop();

                    if (GetOpening(currentChar) != lastOpened)
                        throw new Exception($"'{lastOpened}' does not have a valid closing tag! in a row {row}");

                    else
                        openedParanhess.Pop();
                }
            }


            return true;
        }

        private static char GetOpening(char closing)
        {
            switch (closing)
            {
                case '}':

                    return '{';

                case ')':

                    return '(';

                case ']':

                    return '[';

                default:
                    throw new ArgumentException($"Wrong closing paranthess: {closing}");
            }
        }

        public static bool IsOpeningParanthess(char value)
        {
            return value == '{' || value == '(' || value == '[';
        }

        public static bool IsClosingParanthess(char value)
        {
            return value == '}' || value == ')' || value == ']';
        }
    }
}
