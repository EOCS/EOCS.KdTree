using EOCS.KdTree.Data.Interfaces;

namespace EOCS.KdTree.Data.Storers
{
    public class ListEmbeddingStorer : IEmbeddingStorer
    {
        private List<Embedding> _embeddings;

        public void LoadEmbeddings(List<Embedding> embeddings)
        {
            _embeddings = embeddings;
        }

        public List<Embedding> FindNearestNeighbours(IDistance distance, Embedding embedding, int n)
        {
            var res = new List<EmbeddingWithDistance>();
            foreach (var e in _embeddings)
            {
                var dist = distance.DistanceBetween(e, embedding);
                if (res.Count < n) res.Add(new EmbeddingWithDistance(dist, e));
                else
                {
                    var max = res.OrderByDescending(i => i.Distance).First();
                    if(dist < max.Distance)
                    {
                        res.Remove(max);
                        res.Add(new EmbeddingWithDistance(dist, e));
                    }
                }
                
            }

            return res.Select(t => t.Embedding).ToList();
        }
    }

    public class EmbeddingWithDistance
    {
        public double Distance { get; set; }

        public Embedding Embedding { get; set; }

        public EmbeddingWithDistance(double distance, Embedding embedding)
        {
            Distance = distance;
            Embedding = embedding;
        }
    }
}
