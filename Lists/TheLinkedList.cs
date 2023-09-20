namespace DataStructures.Lists
{
    public class TheLinkedList<T>
    {
        public TheLinkedListNode<T>? Head { get; set; }
        public TheLinkedListNode<T>? Tail { get; set; }
        public int Count;
        /// <summary>
        /// Insert data to the end of the list.
        /// </summary>
        public TheLinkedListNode<T> Insert(T data)
        {
            if (Head == null)
            {
                Head = new(data);

                Count++;

                return Head;
            }

            return InsertInternal(Head, data);
        }
        private TheLinkedListNode<T> InsertInternal(TheLinkedListNode<T> root, T data)
        {
            if (root == null)
            {
                root = new(data);

                Count++;

                return root;
            }

            root.Next = InsertInternal(root.Next, data);

            return root;
        }
        /// <summary>
        /// Insert data to the n-th position of the list.
        /// </summary>
        public TheLinkedListNode<T> InsertBefore(T data, int position)
        {
            if (position == 0)
                return InsertFirst(data);

            TheLinkedListNode<T> newNode = new(data);
            TheLinkedListNode<T>? currentNode = Head;

            for (int i = 0; i < position - 1; i++)
            {
                currentNode = currentNode.Next;
            }

            newNode.Next = currentNode.Next;

            currentNode.Next = newNode;


            Count++;

            return newNode;
        }

        public TheLinkedListNode<T> InsertAfter(T data, int position)
        {
            if (position == 0)
                return InsertFirst(data);

            TheLinkedListNode<T> newNode = new(data);
            TheLinkedListNode<T>? currentNode = Head;

            for (int i = 0; i <= position; i++)
            {
                currentNode = currentNode.Next;
            }

            newNode.Next = currentNode.Next;

            currentNode.Next = newNode;


            Count++;

            return newNode;
        }

        public TheLinkedListNode<T>? Delete(int position)
        {
            if (position == 0)
            {
                Head = Head.Next;

                return Head;
            }

            TheLinkedListNode<T>? temp = Head;

            for (int i = 0; i < position - 1; i++)
                temp = temp.Next;


            temp.Next = temp.Next?.Next;

            return temp;
        }

        public TheLinkedListNode<T> InsertFirst(T data)
        {
            TheLinkedListNode<T> temp = new(data);

            if (Head == null)
                Head = temp;
            else
            {
                temp.Next = Head;

                Head = temp;
            }


            return temp;
        }

        public TheLinkedListNode<T>? RemoveFirst()
        {
            if (Head == null)
                return null;

            TheLinkedListNode<T> temp = Head;

            Head = Head.Next;

            return temp;
        }

        public TheLinkedListNode<T> Enqueue(T data)
        {
            TheLinkedListNode<T> temp = new(data);

            if (Head == null)
            {
                Head = temp;
                Tail = temp;

                return temp;
            }


            Tail.Next = temp;

            Tail = temp;

            return temp;
        }

        public TheLinkedListNode<T>? Dequeue()
        {
            if (Head == null) return null;

            TheLinkedListNode<T> temp = Head;

            Head = Head.Next;

            return temp;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public TheLinkedListNode<T>? Peak()
        {
            return Head;
        }

        public void ReverseRec(TheLinkedListNode<T>? root)
        {
            if (root.Next == null)
            {
                Head = root;

                return;
            }

            ReverseRec(root.Next);

            TheLinkedListNode<T> next = root.Next;

            next.Next = root;

            root.Next = null;
        }

        public void PrintElements(TheLinkedListNode<T>? root)
        {
            if (root == null)
                Console.WriteLine("[]");

            Console.Write($"[{root.Data},");

            while (root.Next != null)
            {
                root = root.Next;
                Console.Write($"{root.Data},");
            }


            Console.WriteLine("]");
        }

        public void PrintReverse(TheLinkedListNode<T>? root)
        {
            if (root == null)
                return;

            PrintReverse(root.Next);

            Console.WriteLine(root.Data);
        }
    }
}
