using System.Xml.Linq;

namespace EOCS.KdTree.Data.KdTrees
{
    public class KdTreeNode
    {
        public int SplitIndex { get; set; }
        public double SplitValue { get; set; }
        public KdTreeNode Left { get; set; }
        public KdTreeNode Right { get; set; }
        public Embedding Embedding { get; set; }

        public KdTreeNode(int splitIndex, double splitValue, Embedding embedding)
        {
            SplitIndex = splitIndex;
            SplitValue = splitValue;
            Left = null;
            Right = null;
            Embedding = embedding;
        }
    }

    //public abstract class KdTreeNodeBase
    //{
    //    public KdTreeNodeBase(int dimension, KdTreeNode parent)
    //    {
    //        Dimension = dimension;
    //        Parent = parent;
    //    }  

    //    public int Dimension { get; protected set; }

    //    public KdTreeNode Parent { get; protected set; }

    //    public abstract bool IsLeaf { get; }

    //    public abstract int Height { get; }

    //    public abstract KdTreeNodeBase Insert(Embedding embedding);

    //    public abstract KdTreeLeaf FindLeafForEmbedding(Embedding target);

    //    public abstract List<KdTreeLeaf> GetLeaves();

    //    public void SetParent(KdTreeNode parent)
    //    {
    //        Parent = parent;
    //    }
    //}

    //public class KdTreeNode : KdTreeNodeBase
    //{
    //    public KdTreeNode(int dimension, KdTreeNode parent, int splitIndex, double splitValue, KdTreeNodeBase left, KdTreeNodeBase right)
    //        : base(dimension, parent)
    //    {
    //        SplitIndex = splitIndex;
    //        SplitValue = splitValue;
    //        Left = left;
    //        Right = right;
    //    }

    //    public int SplitIndex { get; protected set; }

    //    public double SplitValue { get; protected set; }

    //    public KdTreeNodeBase Left { get; protected set; }

    //    public KdTreeNodeBase Right { get; protected set; }

    //    public override bool IsLeaf => false;

    //    public override int Height => 1 + Math.Max(Left.Height, Right.Height);
        
    //    public override KdTreeNodeBase Insert(Embedding embedding)
    //    {
    //        var v = embedding.Records[SplitIndex];
    //        if (v < SplitValue)
    //        {
    //            var left = Left.Insert(embedding);
    //            var res = new KdTreeNode(Dimension, Parent, SplitIndex, SplitValue, left, Right);
    //            left.SetParent(res); Right.SetParent(res);
    //            return res;
    //        }
    //        else
    //        {
    //            var right = Right.Insert(embedding);
    //            var res = new KdTreeNode(Dimension, Parent, SplitIndex, SplitValue, Left, right);
    //            Left.SetParent(res); right.SetParent(res);
    //            return res;
    //        }
    //    }

    //    public override KdTreeLeaf FindLeafForEmbedding(Embedding target)
    //    {
    //        var t = target.Records[SplitIndex];
    //        if (t < SplitValue) return Left.FindLeafForEmbedding(target);
    //        return Right.FindLeafForEmbedding(target);
    //    }

    //    #region Private Methods

    //    public override List<KdTreeLeaf> GetLeaves()
    //    {
    //        var leftLeaves = new List<KdTreeLeaf>();
    //        if (Left != null) leftLeaves = Left.GetLeaves();
    //        var rightLeaves = new List<KdTreeLeaf>();
    //        if (Right != null) rightLeaves = Right.GetLeaves();

    //        leftLeaves.AddRange(rightLeaves);

    //        return leftLeaves;
    //    }

    //    #endregion
    //}

    //public class KdTreeLeaf : KdTreeNodeBase
    //{
    //    public KdTreeLeaf(int dimension, KdTreeNode parent, int depth, Embedding embedding)
    //        : base(dimension, parent)
    //    {
    //        Depth = depth;
    //        Embedding = embedding;
    //    }

    //    public int Depth { get; protected set; }

    //    public Embedding Embedding { get; protected set; }

    //    public override bool IsLeaf => true;

    //    public override int Height => 0;

    //    public override KdTreeNodeBase Insert(Embedding embedding)
    //    {
    //        var index = Depth % Dimension;
    //        var v = embedding.Records[index]; var c = Embedding.Records[index];

    //        var newDepth = Depth + 1;
    //        KdTreeLeaf left = null; KdTreeLeaf right = null;
    //        if (v < c)
    //        { 
    //            left = new KdTreeLeaf(Dimension, null, newDepth, embedding);
    //            right = new KdTreeLeaf(Dimension, null, newDepth, Embedding);
    //        }
    //        else
    //        {
    //            left = new KdTreeLeaf(Dimension, null, newDepth, Embedding);
    //            right = new KdTreeLeaf(Dimension, null, newDepth, embedding);
    //        }

    //        var res = new KdTreeNode(Dimension, Parent, index, c, left, right);
    //        left.SetParent(res); right.SetParent(res);

    //        return res;
    //    }

    //    public override KdTreeLeaf FindLeafForEmbedding(Embedding target)
    //    {
    //        return this;
    //    }

    //    public override List<KdTreeLeaf> GetLeaves()
    //    {
    //        return new List<KdTreeLeaf>() { this };
    //    }
    //}
}
