namespace EOCS.KdTree.Data.Interfaces
{
    public interface IEmbeddingStorer
    {
        void LoadEmbeddings(List<Embedding> embeddings);

        List<Embedding> FindNearestNeighbours(IDistance distance, Embedding embedding, int n);
    }
}
