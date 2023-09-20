using DataStructures.Trees;

namespace DataStructures.Threes
{
    public enum TraverseOrder
    {
        INORDER,
        PREORDER,
        POSTORDER,
        REVERSE
    }

    public class TheBinarySearchTree
    {
        public TheBinaryTreeNode Insert(TheBinaryTreeNode? currentNode, int data)
        {
            if (currentNode == null)
                currentNode = new(data);


            else if (data <= currentNode.Data)
                currentNode.Left = Insert(currentNode.Left, data);

            else
                currentNode.Right = Insert(currentNode.Right, data);


            return currentNode;
        }

        public TheBinaryTreeNode? Get(TheBinaryTreeNode? root, int finding)
        {
            if (root == null) return null;

            else if (root.Data == finding) return root;

            else if (finding <= root.Data)
                return Get(root.Left, finding);
            else
                return Get(root.Right, finding);
        }

        public int FindMin(TheBinaryTreeNode? root)
        {
            if (root == null) return -1;

            TheBinaryTreeNode current = root;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current.Data;
        }

        public TheBinaryTreeNode? FindMinNode(TheBinaryTreeNode? root)
        {
            if (root == null) return null;

            TheBinaryTreeNode current = root;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        public TheBinaryTreeNode? FindMaxNode(TheBinaryTreeNode? root)
        {
            if (root == null) return null;

            TheBinaryTreeNode current = root;

            while (current.Right != null)
            {
                current = current.Right;
            }

            return current;
        }

        public int FindMax(TheBinaryTreeNode? root)
        {
            if (root == null) return -1;

            TheBinaryTreeNode current = root;

            while (current.Right != null)
            {
                current = current.Right;
            }

            return current.Data;
        }

        public void PrintElements(TheBinaryTreeNode? root, TraverseOrder order)
        {
            if (root == null)
            {
                Console.WriteLine("[]");

                return;
            }
            Console.Write("[");

            switch (order)
            {
                case TraverseOrder.INORDER:
                    TraverseInorder(root);
                    break;

                case TraverseOrder.PREORDER:
                    TraversePreOrder(root);
                    break;
                case TraverseOrder.POSTORDER:
                    TraversePostOrder(root);
                    break;

                case TraverseOrder.REVERSE:
                    ReverseTraverseInorder(root);
                    break;
            }



            Console.WriteLine("]");
        }

        public void TraverseInorder(TheBinaryTreeNode? root)
        {
            if (root == null)
                return;

            TraverseInorder(root.Left);
            Console.Write($"{root.Data},");
            TraverseInorder(root.Right);
        }

        public void TraversePreOrder(TheBinaryTreeNode? root)
        {
            if (root == null)
                return;

            Console.Write($"{root.Data},");
            TraverseInorder(root.Left);
            TraverseInorder(root.Right);
        }

        public void TraversePostOrder(TheBinaryTreeNode? root)
        {
            if (root == null)
                return;

            TraverseInorder(root.Left);
            TraverseInorder(root.Right);
            Console.Write($"{root.Data},");
        }

        public void ReverseTraverseInorder(TheBinaryTreeNode? root)
        {
            if (root == null)
                return;

            ReverseTraverseInorder(root.Right);
            Console.Write($"{root.Data},");
            ReverseTraverseInorder(root.Left);
        }

        public int GetDepth(TheBinaryTreeNode root, int data)
        {
            if (root == null) return -1;

            if (root.Data == data) return 0;

            int distLeft = GetDepth(root.Left, data);
            if (distLeft >= 0) return distLeft + 1;

            int distRight = GetDepth(root.Right, data);
            if (distRight >= 0) return distRight + 1;


            return -1;
        }

        public int GetHeight(TheBinaryTreeNode root)
        {
            if (root == null) return -1;

            int leftHeight = GetHeight(root.Left);
            int rightHeight = GetHeight(root.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public bool IsBinarySearchTree(TheBinaryTreeNode? root)
        {
            if (root == null) return false;

            if (IsBinarySearchTreeRec(root, int.MinValue, int.MaxValue))
                return true;


            else return false;
        }

        private bool IsBinarySearchTreeRec(TheBinaryTreeNode root, int minValue, int maxValue)
        {
            if (root == null) return true;

            if (root.Data > minValue && root.Data <= maxValue
                && IsBinarySearchTreeRec(root.Left, minValue, root.Data)
                && IsBinarySearchTreeRec(root.Right, root.Data, maxValue))

                return true;

            else return false;
        }

        public TheBinaryTreeNode? Delete(TheBinaryTreeNode? root, int deletingValue)
        {
            if (root == null) return null;

            else if (deletingValue < root.Data)
                root.Left = Delete(root.Left, deletingValue);

            else if (deletingValue > root.Data)
                root.Right = Delete(root.Right, deletingValue);

            //we found deleting
            else
            {
                //Case 1 
                //If is leaf node just delete
                if (IsLeaf(root))
                    return null;

                //Case 2
                //If deleting node has only 1 child
                else if (HasOneChild(root))
                    return root.Left ?? root.Right;

                //Case 3
                //If we have 2 child we must find maximum on lef subtree
                //or find minimum on righ subtree
                //Replace with deleting
                //and again traverse from current and find duplicate on the subree
                //and delete that one element
                else
                {
                    TheBinaryTreeNode? max = FindMaxNode(root.Left);

                    root.Data = max.Data;

                    root.Left = Delete(root.Left, max.Data);
                }


            }


            return root;
        }

        public bool IsLeaf(TheBinaryTreeNode root)
        {
            return root.Left == null && root.Right == null;
        }

        public bool HasOneChild(TheBinaryTreeNode root)
        {
            return root.Left == null || root.Right == null;
        }

        public TheBinaryTreeNode? GetInorderSuccessor(TheBinaryTreeNode? root, int value)
        {
            TheBinaryTreeNode? current = Get(root, value);

            if (current == null) return null;

            //if current element is have right subtree
            //find the min in the right subtree
            if (current.Right != null)

                return FindMinNode(current);

            else
            {
                TheBinaryTreeNode? successor = null;
                TheBinaryTreeNode? ancestor = root;

                while (ancestor != current)
                {
                    if (current.Data <= ancestor.Data)
                    {
                        successor = ancestor;
                        ancestor = ancestor.Left;
                    }
                    else
                        ancestor = ancestor.Right;
                }

                return successor;
            }

        }

    }

}
