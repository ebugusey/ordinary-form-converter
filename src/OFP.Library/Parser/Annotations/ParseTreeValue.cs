using System.Collections.Concurrent;
using Antlr4.Runtime.Tree;

namespace OFP.Parser.Annotations
{
    internal class ParseTreeValue<T> where T : struct
    {
        private readonly ConcurrentDictionary<IParseTree, T> _annotations =
            new ConcurrentDictionary<IParseTree, T>();

        public T? TryGet(IParseTree node)
        {
            if (!_annotations.TryGetValue(node, out var value))
            {
                return null;
            }

            return value;
        }

        public void Put(IParseTree node, T value)
        {
            _annotations[node] = value;
        }

        public T? RemoveFrom(IParseTree node)
        {
            if (!_annotations.TryRemove(node, out var value))
            {
                return null;
            }

            return value;
        }
    }
}
