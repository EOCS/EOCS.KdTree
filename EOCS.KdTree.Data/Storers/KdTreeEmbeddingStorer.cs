using EOCS.KdTree.Data.Interfaces;

namespace EOCS.KdTree.Data.Storers
{
    public class KdTreeEmbeddingStorer : IEmbeddingStorer
    {
        private const int DIMENSION = 6;
        private KdTrees.KdTree _tree = new KdTrees.KdTree(DIMENSION);

        public void LoadEmbeddings(List<Embedding> embeddings)
        {
            foreach (var embedding in embeddings)
            {
                _tree.Insert(embedding);
            }
        }

        public List<Embedding> FindNearestNeighbours(IDistance distance, Embedding embedding, int n)
        {            
            return _tree.FindNearestNeighbours(distance, embedding, n);
        }        
    }
}
