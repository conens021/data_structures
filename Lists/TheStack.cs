using System.Collections;

namespace DataStructures.Lists
{
    public class TheStack<T>
    {
        private readonly static int DEFAULT_SIZE = 10;
        private static int Top;
        private static int MaxSize;
        private T[] List;

        public TheStack()
        {
            List = new T[DEFAULT_SIZE];
            Top = -1;
            MaxSize = DEFAULT_SIZE;
        }

        public TheStack(int size)
        {
            List = new T[size];
            Top = -1;
            MaxSize = size;
        }


        public void Push(T element)
        {
            if (Top == MaxSize - 1)
                Expand();

            List[++Top] = element;
        }

        private void Expand()
        {
            MaxSize *= 2;

            T[] temp = new T[MaxSize];

            for (int i = 0; i < List.Length; i++)
                temp[i] = List[i];

            List = temp;
        }

        public T? Pop()
        {
            if (Top == -1)
                return default(T);

            T t = List[Top];

            Top--;


            return t;
        }

        public T? GetTop()
        {
            if (Top == -1)
                return default(T);


            return List[Top];
        }

        public bool IsEmpty()
        {

            return Top == -1;
        }

        public bool IsLast()
        {
            return Top == 0;
        }
    }
}
