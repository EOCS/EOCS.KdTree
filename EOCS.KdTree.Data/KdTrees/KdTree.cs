using EOCS.KdTree.Data.Interfaces;

namespace EOCS.KdTree.Data.KdTrees
{
    public class KdTree
    {
        private KdTreeNode _root;
        private int _dimensions;

        public KdTree(int dimensions)
        {
            _dimensions = dimensions;
            _root = null;
        }

        public void Insert(Embedding embedding)
        {
            _root = Insert(_root, embedding, 0);
        }

        public List<Embedding> FindNearestNeighbours(IDistance distance, Embedding target, int n)
        {
            var bestNodes = new SortedList<double, Embedding>(n + 1);
            FindNearestNeighbours(distance, _root, target, bestNodes, n);
            return new List<Embedding>(bestNodes.Values);
        }

        #region Private Methods

        private KdTreeNode Insert(KdTreeNode node, Embedding embedding, int depth)
        {
            var splitIndex = depth % _dimensions;
            var v = embedding.Records[splitIndex];

            if (node == null)
                return new KdTreeNode(splitIndex, v, embedding);

            if (v < node.SplitValue)
                node.Left = Insert(node.Left, embedding, depth + 1);
            else
                node.Right = Insert(node.Right, embedding, depth + 1);

            return node;
        }

        private void FindNearestNeighbours(IDistance d, KdTreeNode node, Embedding target, SortedList<double, Embedding> bestNodes, int n)
        {
            if (node == null)
                return;

            var distance = d.DistanceBetween(node.Embedding, target);
            if (bestNodes.Count < n)
            {
                bestNodes.Add(distance, node.Embedding);
            }
            else if (distance < bestNodes.Keys[bestNodes.Count - 1])
            {
                bestNodes.RemoveAt(bestNodes.Count - 1);
                bestNodes.Add(distance, node.Embedding);
            }

            var cd = node.SplitIndex;
            var nextNode = target.Records[cd] < node.Embedding.Records[cd] ? node.Left : node.Right;
            var otherNode = target.Records[cd] < node.Embedding.Records[cd] ? node.Right : node.Left;

            FindNearestNeighbours(d, nextNode, target, bestNodes, n);

            if (bestNodes.Count < n || Math.Abs(node.Embedding.Records[cd] - target.Records[cd]) < bestNodes.Keys[bestNodes.Count - 1])
            {
                FindNearestNeighbours(d, otherNode, target, bestNodes, n);
            }
        }

        #endregion
    }
}
