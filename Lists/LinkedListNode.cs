namespace DataStructures.Lists
{
    public class TheLinkedListNode<T> 
    {
        public TheLinkedListNode() 
        {
        }

        public TheLinkedListNode(T data)
        {
            Data = data;
        }

        public T Data;
        public TheLinkedListNode<T>? Next;
    }
}
