namespace DataStructures.Lists
{
    public class TheQueue<T>
    {
        private T[] Array;
        private static readonly int DEFAULT_SIZE = 10;
        private static int MaxSize;
        private static int Top;
        private static int Rear;

        public TheQueue()
        {
            Top = -1;
            Rear = -1;
            MaxSize = DEFAULT_SIZE;
            Array = new T[MaxSize];
        }

        public TheQueue(int size)
        {
            Top = -1;
            Rear = -1;
            MaxSize = size;
            Array = new T[MaxSize];
        }

        public void Enqueue(T element)
        {
            if ((Rear + 1) % MaxSize == Top)
                Expand();

            else if (IsEmpty())
                Top = Rear = 0;

            else
                Rear = (Rear + 1) % MaxSize;


            Array[Rear] = element;
        }

        public T? Dequeue()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("No more elements to be Dequeued.");

            T? temp = Array[Top];

            //if we have just 1 element
            if (Top == Rear)
                Top = Rear = -1;

            else
                Top = (Top + 1) % MaxSize;


            return temp;
        }

        public bool IsEmpty()
        {
            return Top == -1 && Rear == -1;
        }

        private void Expand()
        {
            MaxSize *= 2;

            T[] temp = new T[MaxSize];

            for (int i = Top; i < Array.Length; i++)
                temp[i] = Array[i];

            if (Rear < Top)
            {
                int lastFree = Array.Length;

                for (int i = 0; i < Top; i++)
                {
                    temp[lastFree] = temp[i];

                    lastFree++;

                }

                Rear = lastFree;
            }

            Array = temp;
        }
    }
}
