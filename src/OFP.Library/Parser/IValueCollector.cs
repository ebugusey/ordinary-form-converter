using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Tree;

namespace OFP.Parser
{
    internal interface IValueCollector<T>
    {
        T Get(IParseTree node);
    }
}
