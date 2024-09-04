using EOCS.KdTree.Data.Interfaces;
using EOCS.KdTree.Data.Storers;

namespace EOCS.KdTree.Data
{
    public class EmbeddingManager
    {        
        private IEmbeddingStorer _storer;

        public EmbeddingManager(string store)
        {
            _storer = store switch
            {
                "STORE_IN_LIST" => new ListEmbeddingStorer(),
                "STORE_KDTREE" => new KdTreeEmbeddingStorer(),
                _ => throw new NotImplementedException()
            };
        } 
    }
}
