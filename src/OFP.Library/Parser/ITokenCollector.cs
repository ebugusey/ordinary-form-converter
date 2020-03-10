using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace OFP.Parser
{
    internal interface ITokenCollector
    {
        long GetNumber(ITerminalNode node);
        long GetNumber(IToken token);
        string GetString(ITerminalNode node);
        string GetString(IToken token);
        Guid GetGuid(ITerminalNode node);
        Guid GetGuid(IToken token);
        ReadOnlyMemory<byte> GetBase64(ITerminalNode node);
        ReadOnlyMemory<byte> GetBase64(IToken token);
    }
}
