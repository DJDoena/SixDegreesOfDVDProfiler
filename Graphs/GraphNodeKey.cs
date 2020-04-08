using System;
using System.Diagnostics;

namespace mitoSoft.Math.Graphs
{
    [DebuggerDisplay("GraphNodeKey {_name}")]
    public sealed class GraphNodeKey : GraphNodeKeyBase
    {
        private readonly string _name;

        private readonly int _hashCode;

        public GraphNodeKey(string name)
        {
            this._name = name ?? throw new ArgumentNullException(nameof(name));

            _hashCode = name.GetHashCode();
        }

        public override string GetKeyDisplayValue() => _name;

        public override int GetKeyHashCode() => _hashCode;

        public override bool KeysAreEqual(GraphNodeKeyBase other)
        {
            if (!(other is GraphNodeKey gnk))
            {
                return false;
            }

            var areEqual = this._name.Equals(gnk._name);

            return areEqual;
        }
    }
}