namespace DataStructures.Algorithms
{
    public class BinarySearch
    {
        public static int Search(int[] array, int search)
        {
            int found = SearchRec(array, 0, array.Length, search);


            return found;
        }


        private static int SearchRec(int[] array, int left, int right, int search)
        {
            //base case
            if (left > right) return -1;

            int medior =  (left + right) / 2;

            if (array[medior] == search) return medior;

            else if (array[medior] < search)
                return SearchRec(array, medior + 1, right, search);

            else
                return SearchRec(array, left, medior - 1, search);
        }
    }
}
