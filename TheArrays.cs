using DataStructures.Graphs;
using DataStructures.Lists;
using System.Text;

namespace DataStructures
{
    public class TheArrays
    {
        public static void Main()
        {
            PrintCyclicTable(10);
        }


        public static void PrintCyclicTable(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int curr = i + j + 1;
                    if (curr > n)
                        Console.Write(curr % n);
                    else
                        Console.Write(curr);
                }

                Console.WriteLine("");
            }
        }

        public static string GetShuffleString(string value1, string value2)
        {
            StringBuilder sb = new();

            int shorter = value1.Length < value2.Length ? value1.Length : value2.Length;
            int longer = value1.Length >= value2.Length ? value1.Length : value2.Length;

            int index = 0;

            while (index < shorter)
            {
                sb.Append(value1[index]);
                sb.Append(value2[index]);

                index++;
            }


            while (index < longer)
            {
                if (longer == value1.Length)
                    sb.Append(value1[index]);
                else
                    sb.Append(value2[index]);

                index++;
            }


            return sb.ToString();
        }

        public static int[,] RemoveMinRowSum(int[,] matrix)
        {
            int rowsLength = matrix.GetLength(0);
            int colsLength = matrix.GetLength(1);

            int minRow = 0;
            int minRowSum = int.MaxValue;

            int[,] newMatrix = new int[rowsLength - 1, colsLength];

            for (int i = 0; i < rowsLength; i++)
            {
                int rowSum = 0;

                for (int j = 0; j < colsLength; j++)
                    rowSum += matrix[i, j];

                if (rowSum < minRowSum)
                {
                    minRow = i;
                    minRowSum = rowSum;
                }
            }

            int rowOriginalMatrix = 0;

            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                if (i == minRow) rowOriginalMatrix++;

                for (int j = 0; j < newMatrix.GetLength(1); j++)
                    newMatrix[i, j] = matrix[rowOriginalMatrix, j];

                rowOriginalMatrix++;
            }


            return newMatrix;
        }

        public static int SumNDigits(int n, int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int curr = array[i];

                int currDigits = GetDigitsCount(curr);

                if (currDigits >= n)
                    sum += curr;
            }


            return sum;
        }

        public static int GetDigitsCount(int value)
        {
            string strValue = value.ToString();

            return strValue.Length;
        }

        public static Graphs<string> Populate()
        {
            string[] airports = { "PHX", "BGD", "NY", "LAX", "BRLN", "BCN", "ATH" };

            Graphs<string> graphs = new();

            graphs.AddAllNodes(airports);

            graphs.AddAllUndirectedEdges("LAX", new string[] { "NY", "PHX" });
            graphs.AddAllUndirectedEdges("NY", new string[] { "PHX", "BRLN", "BCN" });
            graphs.AddAllUndirectedEdges("BRLN", new string[] { "BCN", "BGD", "ATH" });
            graphs.AddAllUndirectedEdges("BCN", new string[] { "BGD", "ATH" });
            graphs.AddAllUndirectedEdges("BGD", new string[] { "ATH" });


            return graphs;
        }

        public static bool IsInAscendingOrder(int n)
        {
            int absValue = Math.Abs(n);

            if (absValue < 10) return true;

            string strValue = Convert.ToString(absValue);
            int minValue = int.MinValue;

            for (int i = 0; i < strValue.Length; i++)
            {
                int current = Convert.ToInt32(strValue[i]);

                if (current <= minValue)
                    return false;


                minValue = current;
            }

            return true;
        }

        public static bool IsPalindrom(string value)
        {
            string tempValue = value.ToLower().Replace(" ", "");

            StringBuilder sb = new StringBuilder();

            for (int i = tempValue.Length - 1; i >= 0; i--)
                sb.Append(tempValue[i]);


            return sb.ToString().Equals(tempValue);
        }

        public static int[,] MatrixTranspone(int[,] matrix)
        {
            int[,] temp = new int[matrix.GetLength(0), matrix.GetLength(1)];


            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp[i, j] = matrix[j, i];
                }

            return temp;
        }

        public static void PrintZero(int n)
        {
            if (n == 0) return;

            int row = 0;

            while (row < n)
            {
                if (row == 0 || row == n - 1)
                    for (int i = 0; i < n; i++)
                        Console.Write("*");

                else
                {
                    int marker = (n - row - 1);

                    for (int j = 0; j < n; j++)
                        if (j == 0 || j == n - 1 || j == marker)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                }

                row++;

                Console.WriteLine("");
            }
        }

    }
}
