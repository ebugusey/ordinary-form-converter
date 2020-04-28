using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace OFP.Parser
{
    /// <summary>
    /// Коллектор токенов (листьев дерева парсинга),
    /// которые успел обойти парсер.
    /// Когда парсер доходит до токена, он попадает
    /// в этот коллектор в разобранном виде.
    /// </summary>
    internal interface ITokenCollector
    {
        /// <summary>
        /// Получить разобранное из токена число для указанного узла дерева парсинга.
        /// </summary>
        /// <param name="node">Узел дерева парсинга, в котором находится разобранный токен.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще на заходил в этот узел.
        /// </exception>
        long GetNumber(ITerminalNode node);

        /// <summary>
        /// Получить разобранное из указанного токена число.
        /// </summary>
        /// <param name="token">Токен, который должен быть разобран как число.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще не доходил до этого токена.
        /// </exception>
        long GetNumber(IToken token);

        /// <summary>
        /// Получить разобранную из токена строку для указанного узла дерева парсинга.
        /// </summary>
        /// <param name="node">Узел дерева парсинга, в котором находится разобранный токен.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще на заходил в этот узел.
        /// </exception>
        string GetString(ITerminalNode node);

        /// <summary>
        /// Получить разобранную из указанного токена строку.
        /// </summary>
        /// <param name="token">Токен, который должен быть разобран как строка.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще не доходил до этого токена.
        /// </exception>
        string GetString(IToken token);

        /// <summary>
        /// Получить разобранный из токена <see cref="Guid"/> для указанного узла дерева парсинга.
        /// </summary>
        /// <param name="node">Узел дерева парсинга, в котором находится разобранный токен.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще на заходил в этот узел.
        /// </exception>
        Guid GetGuid(ITerminalNode node);

        /// <summary>
        /// Получить разобранный из указанного токена <see cref="Guid"/>.
        /// </summary>
        /// <param name="token">Токен, который должен быть разобран как <see cref="Guid"/>.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще не доходил до этого токена.
        /// </exception>
        Guid GetGuid(IToken token);

        /// <summary>
        /// Получить разобранную из токена Base64-строку в виде массива байтов
        /// для указанного узла дерева парсинга.
        /// </summary>
        /// <param name="node">Узел дерева парсинга, в котором находится разобранный токен.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще на заходил в этот узел.
        /// </exception>
        ReadOnlyMemory<byte> GetBase64(ITerminalNode node);

        /// <summary>
        /// Получить разобранную из указанного токена Base64-строку в виде массива байтов.
        /// </summary>
        /// <param name="token">Токен, который должен быть разобран как Base64-строка.</param>
        /// <returns>Разобранное значение.</returns>
        /// <exception cref="InvalidOperationException">
        /// Если парсер еще не доходил до этого токена.
        /// </exception>
        ReadOnlyMemory<byte> GetBase64(IToken token);
    }
}
