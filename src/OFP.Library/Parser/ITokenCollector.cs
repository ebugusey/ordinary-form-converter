using System;
using Antlr4.Runtime.Tree;

namespace OFP.Parser
{
    internal interface ITokenCollector
    {
        long GetNumber(ITerminalNode node);
        string GetString(ITerminalNode node);
        Guid GetGuid(ITerminalNode node);
        ReadOnlyMemory<byte> GetBase64(ITerminalNode node);
    }
}
