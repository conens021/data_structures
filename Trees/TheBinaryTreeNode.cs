namespace DataStructures.Trees
{
    public class TheBinaryTreeNode
    {
        public int Data;
        public TheBinaryTreeNode? Left;
        public TheBinaryTreeNode? Right;

        public TheBinaryTreeNode()
        {
            Left = Right = null;
        }

        public TheBinaryTreeNode(int data)
        {
            Data = data;
            Left = Right = null;
        }

    }
}
