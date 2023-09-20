using System.Xml.Linq;

namespace DataStructures.Trees
{
    public class TheFullBinaryTree
    {
        public TheBinaryTreeNode Add(TheBinaryTreeNode? current, int data)
        {
            Queue<TheBinaryTreeNode> queue = new();

            if (current == null)
            {
                current = new TheBinaryTreeNode(data);

                return current;
            }

            TheBinaryTreeNode root = current;

            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = new(data);

                    break;
                }

                else if (current.Right == null)
                {
                    current.Right = new(data);

                    break;
                }

                queue.Enqueue(current.Left);
                queue.Enqueue(current.Right);
            }

            return root;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public TheBinaryTreeNode? Delete(TheBinaryTreeNode? root, int value)
        {
            //If tree is empty
            if (root == null) return null;

            //If tree only has root
            if (root.Left == null && root.Right == null)
            {
                //check if Root 
                if (root.Data == value)
                {
                    var tempRoot = root;

                    root = null;

                    return tempRoot;
                }

                return null;
            }

            Queue<TheBinaryTreeNode> queue = new();

            queue.Enqueue(root);

            TheBinaryTreeNode? keyNode = null;
            //node that is deque from queue
            //temp hold the value of last node
            TheBinaryTreeNode? currentNode = null;

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();

                if (currentNode.Data == value)
                {
                    keyNode = currentNode;
                }

                //for finding last element
                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }


            if (keyNode != null && currentNode != null)
            {
                keyNode.Data = currentNode.Data;
                //remove the last node

                DeleteNode(root, currentNode);
            }


            return null;
        }

        public TheBinaryTreeNode? DeleteNode(TheBinaryTreeNode? root, TheBinaryTreeNode deleting)
        {
            if (root == null) return null;

            if (root == deleting)
            {
                var tempRoot = root;

                root = null;

                return tempRoot;
            }

            Queue<TheBinaryTreeNode> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TheBinaryTreeNode currentNode = queue.Dequeue();

                if (currentNode.Left == deleting)
                {
                    currentNode.Left = null;
                }
                if (currentNode.Right == deleting)
                {
                    currentNode.Right = null;
                }

                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }


            return null;
        }

        public TheBinaryTreeNode? GetLastLeaf()
        {
            throw new NotImplementedException();

        }

        public TheBinaryTreeNode? Get(TheBinaryTreeNode root, int finding)
        {
            throw new NotImplementedException();
        }

        public TheBinaryTreeNode AddSafe(TheBinaryTreeNode? currentNode, int data)
        {
            throw new NotImplementedException();
        }

        public bool IsBinarySearchTree(TheBinaryTreeNode? root)
        {
            if (root == null) return true;

            if (IsSubtreeLesser(root.Left, root.Data)
                && IsSubtreeGreater(root.Right, root.Data)
                && IsBinarySearchTree(root.Left)
                && IsBinarySearchTree(root.Right))

                return true;


            else return false;
        }

        private bool IsSubtreeLesser(TheBinaryTreeNode? root, int value)
        {
            if (root == null) return true;

            if (root.Data <= value &&
                IsSubtreeLesser(root.Left, value)
                && IsSubtreeLesser(root.Right, value))
                return true;

            else return false;
        }

        private bool IsSubtreeGreater(TheBinaryTreeNode? root, int value)
        {
            if (root == null) return true;

            if (root.Data > value &&
                IsSubtreeGreater(root.Left, value)
                && IsSubtreeGreater(root.Right, value))
                return true;

            else return false;
        }
    }
}
