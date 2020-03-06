using Antlr4.Runtime.Tree;

namespace OFP.Parser.Extensions
{
    internal static class ParseTreePropertyExtensions
    {
        public static T? TryGet<T>(this ParseTreeProperty<T> annotations, IParseTree node) where T : class
        {
            return annotations.Get(node);
        }
    }
}
