namespace mitoSoft.Math.Graphs
{
    /// <summary>
    /// Identifies a unique node in the graph.
    /// </summary>
    /// <remarks>
    /// A key object must be immutable, its HashCode and all properties (that are used for equality comparison) never changing.
    /// </remarks>
    public abstract class GraphNodeKey
    {
        public abstract int GetKeyHashCode();

        public abstract bool KeysAreEqual(GraphNodeKey other);

        public abstract string GetKeyDisplayValue();

        public sealed override bool Equals(object obj) => this.KeysAreEqual(obj as GraphNodeKey);

        public sealed override int GetHashCode() => this.GetKeyHashCode();

        public override string ToString() => this.GetKeyDisplayValue();
    }
}