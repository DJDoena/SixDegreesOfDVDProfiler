namespace mitoSoft.Math.Graphs
{
    public abstract class GraphNodeKey
    {
        public abstract int GetKeyHashCode();

        public abstract bool KeysAreEqual(GraphNodeKey other);

        public abstract string GetKeyDisplayValue();

        public sealed override bool Equals(object obj) => KeysAreEqual(obj as GraphNodeKey);

        public sealed override int GetHashCode() => GetKeyHashCode();

        public sealed override string ToString() => GetKeyDisplayValue();
    }
}