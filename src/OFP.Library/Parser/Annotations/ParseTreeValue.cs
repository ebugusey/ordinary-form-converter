using System.Collections.Concurrent;
using Antlr4.Runtime.Tree;

namespace OFP.Parser.Annotations
{
    /// <summary>
    /// Аннотация для узлов дерева парсинга.
    /// Позволяет ассоциировать произвольное значение значимого типа (value type)
    /// с узлом дерева.
    /// <para>
    /// Для ссылочных типов используй <see cref="ParseTreeProperty{V}"/>.
    /// </para>
    /// </summary>
    /// <typeparam name="T">Тип значения, ассоциируемого с узлами дерева.</typeparam>
    internal class ParseTreeValue<T> where T : struct
    {
        private readonly ConcurrentDictionary<IParseTree, T> _annotations =
            new ConcurrentDictionary<IParseTree, T>();

        /// <summary>
        /// Получить значение, ассоциированное с указанным узлом дерева.
        /// Возвращает <c><see langword="null"/></c>, если для указанного
        /// узла в коллекции нет значений.
        /// </summary>
        /// <param name="node">Узел дерева, для которого должно быть значение в коллекции.</param>
        /// <returns>Значение, ассоциированное с узлом дерева.</returns>
        public T? TryGet(IParseTree node)
        {
            if (!_annotations.TryGetValue(node, out var value))
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Установить ассоциацию узла дерева с указанным значением.
        /// Если для указанного узла дерева в этой коллекции уже было
        /// установлено значение, то оно заменится новым значением.
        /// </summary>
        /// <param name="node">Узел дерева, для которого устанавливается ассоциация.</param>
        /// <param name="value">Произвольное значение, которое ассоциируется с узлом дерева.</param>
        public void Put(IParseTree node, T value)
        {
            _annotations[node] = value;
        }

        /// <summary>
        /// Удалить ассоциацию для указанного узла дерева.
        /// </summary>
        /// <param name="node">Узел дерева, для которого удаляется ассоциированное с ним значение.</param>
        /// <returns>Значение, которое было установлено до очистки.</returns>
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
