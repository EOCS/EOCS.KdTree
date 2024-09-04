using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EOCS.KdTree.Data;
using EOCS.KdTree.Data.Distances;
using EOCS.KdTree.Data.Interfaces;
using EOCS.KdTree.Data.Storers;
using System.Data;
using System.Globalization;

namespace EOCS.KdTree.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }

    public class EmbeddingStorerBenchmark
    {
        private KdTreeEmbeddingStorer _kdTreeEmbeddingStorer;
        private ListEmbeddingStorer _listEmbeddingStorer;

        private IDistance _distance;

        private Embedding _query;

        [GlobalSetup]
        public void Setup()
        {
            var path = AppContext.BaseDirectory + "/dataset100000.csv";
            var lines = File.ReadAllLines(path);

            var embeddings = new List<Embedding>(); var culture = new CultureInfo("en-US");
            foreach (var line in lines)
            {
                var records = line.Split(';').Select(x => Convert.ToDouble(x.Trim(), culture)).ToArray();
                var embedding = new Embedding(records);
                embeddings.Add(embedding);
            }

            _kdTreeEmbeddingStorer = new KdTreeEmbeddingStorer();
            _listEmbeddingStorer = new ListEmbeddingStorer();
            _distance = new EuclidianDistance();

            _kdTreeEmbeddingStorer.LoadEmbeddings(embeddings);
            _listEmbeddingStorer.LoadEmbeddings(embeddings);

            _query = new Embedding(new double[] { 0.25551613824067143, -0.8849031990448337, -0.7598131480221972, 0.50383174460758, -0.4510775673617402, -0.3108595333783353, 0.7336475844915646, 0.263399338913618, 0.6692907911816828, 0.9378379967863208 });
        }

        [Benchmark]
        public List<Embedding> FindNeighboursWithList() => _listEmbeddingStorer.FindNearestNeighbours(_distance, _query, 5);

        [Benchmark]
        public List<Embedding> FindNeighboursWithKdTree() => _kdTreeEmbeddingStorer.FindNearestNeighbours(_distance, _query, 5);
    }
}
