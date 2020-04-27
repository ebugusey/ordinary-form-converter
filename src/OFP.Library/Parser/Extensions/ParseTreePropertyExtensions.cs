using Antlr4.Runtime.Tree;

namespace OFP.Parser.Extensions
{
    /// <summary>
    /// Методы-расширения для <see cref="ParseTreeProperty{V}"/>.
    /// </summary>
    internal static class ParseTreePropertyExtensions
    {
        /// <summary>
        /// Получить значение, ассоциированное с указанным узлом дерева.
        /// Возвращает <c><see langword="null"/></c>, если для указанного
        /// узла в коллекции нет значений.
        /// </summary>
        /// <param name="node">Узел дерева, для которого должно быть значение в коллекции.</param>
        /// <returns>Значение, ассоциированное с узлом дерева.</returns>
        public static T? TryGet<T>(this ParseTreeProperty<T> annotations, IParseTree node) where T : class
        {
            return annotations.Get(node);
        }
    }
}
