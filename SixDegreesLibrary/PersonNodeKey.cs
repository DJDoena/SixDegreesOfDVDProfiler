using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Graphs;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    partial class PersonNode
    {
        [DebuggerDisplay(nameof(PersonNodeKey) + " ({ToString()})")]
        private sealed class PersonNodeKey : GraphNodeKeyBase
        {
            private readonly IPerson _person;

            private readonly PersonKey _key;

            public PersonNodeKey(IPerson person)
            {
                _person = person;
                _key = new PersonKey(person);
            }

            public override string GetKeyDisplayValue() => PersonFormatter.GetName(_person);

            public override int GetKeyHashCode() => _key.GetHashCode();

            public override bool KeysAreEqual(GraphNodeKeyBase other)
            {
                if (!(other is PersonNodeKey pnk))
                {
                    return false;
                }
                else
                {
                    var areEqual = _key.Equals(pnk._key);

                    return areEqual;
                }
            }
        }
    }
}