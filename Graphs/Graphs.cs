using DataStructures.Lists;
using System.Collections;
using System.Linq;

namespace DataStructures.Graphs
{
    public class Graphs<T> where T : class
    {
        private IDictionary<T, TheLinkedList<T>> Elements;

        public Graphs()
        {
            Elements = new Dictionary<T, TheLinkedList<T>>();
        }

        public void AddNode(T node)
        {
            Elements.Add(node, new TheLinkedList<T>());
        }

        public void AddAllNodes(IEnumerable<T> node)
        {
            node.ToList().ForEach(node => Elements.Add(node, new TheLinkedList<T>()));
        }

        public bool AddEdge(T node, T edge)
        {
            TheLinkedList<T> edges;

            if (Elements.TryGetValue(node, out edges))
            {
                edges.Insert(edge);


                return true;
            }
            else
                return false;
        }

        public bool AddUndirectedEdge(T node, T edge)
        {
            TheLinkedList<T> edges;

            if (Elements.TryGetValue(node, out edges))
                edges.Insert(edge);
            else
                return false;


            if (Elements.TryGetValue(edge, out edges))
                edges.Insert(node);
            else
                return false;


            return true;
        }

        public bool AddAllEdges(T node, IEnumerable<T> newEdges)
        {
            TheLinkedList<T> edges;

            if (Elements.TryGetValue(node, out edges))
            {
                foreach (T edge in newEdges)
                    edges.Insert(edge);


                return true;
            }
            else
                return false;
        }

        public bool AddAllUndirectedEdges(T node, IEnumerable<T> newEdges)
        {
            TheLinkedList<T> edges;

            if (Elements.TryGetValue(node, out edges))
            {
                foreach (T edge in newEdges)
                {
                    edges.Insert(edge);

                    TheLinkedList<T> edgeEdges;

                    if (Elements.TryGetValue(edge, out edgeEdges))
                        edgeEdges.Insert(node);
                }
            }
            else
                return false;


            return true;
        }

        public bool NodeExists(T node)
        {
            return Elements.ContainsKey(node);
        }

        public IDictionary<T, TheLinkedList<T>> GetElements()
        {
            return Elements;
        }

        public void BFS(T node, T search)
        {
            TheQueue<T> que = new();
            HashSet<T> visited = new();

            que.Enqueue(node);
            visited.Add(node);

            while (!que.IsEmpty())
            {
                T? current = que.Dequeue();

                Console.WriteLine(current);
               
                TheLinkedList<T>? edges;

                Elements.TryGetValue(current, out edges);

                if (edges == null || edges.Count == 0) continue;

                TheLinkedListNode<T>? root = edges.Head;

                while (root != null)
                {
                    T currentEdge = root.Data;

                    if (!visited.Contains(currentEdge))
                    {
                        que.Enqueue(currentEdge);
                        visited.Add(currentEdge);
                    }

                    if (search == currentEdge)
                        Console.WriteLine($"Found: {search}");

                    root = root.Next;
                }
            }
        }

        public void DFS(T node, T search)
        {
            HashSet<T> visited = new();

            DFSRec(node, search, visited);
        }

        public void DFSRec(T node, T search, HashSet<T> visited)
        {
            Console.WriteLine(node);

            visited.Add(node);

            TheLinkedList<T> edges;

            if (Elements.TryGetValue(node, out edges))
            {
                TheLinkedListNode<T>? currentEdge = edges.Head;

                while (currentEdge != null)
                {
                    if (currentEdge.Data.Equals(search))
                    {
                        Console.WriteLine($"Found : {search}");

                        return;
                    }

                    if (!visited.Contains(currentEdge.Data))
                        DFSRec(currentEdge.Data, search, visited);

                    currentEdge = currentEdge.Next;
                }
            }
            else return;
        }
    }
}
