using System;
using Antlr4.Runtime.Tree;

namespace OFP.Parser
{
    /// <summary>
    /// Коллектор разобранный значений
    /// из узлов дерева, которые успел обойти парсер.
    /// Когда парсер доходит то разбираемого типа,
    /// значение этого типа попадает в этот коллектор
    /// в разобранном виде.
    /// </summary>
    /// <typeparam name="T">Тип разбираемого значения.</typeparam>
    internal interface IValueCollector<T>
    {
        /// <summary>
        /// Получить разобранное из указанного узла значение.
        /// </summary>
        /// <param name="node">Узел дерева парсинга, который представляет разбираемое значение.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще не заходил в этот узел
        /// или в дереве нет узла, который может быть распарсен в <typeparamref name="T"/>.
        /// </exception>
        T Get(IParseTree node);
    }
}
