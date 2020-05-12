using System;
using Antlr4.Runtime.Tree;
using OFP.ObjectModel.Platform.Colors;
using OFP.Parser.Extensions;
using OFP.Parser.Generated;

namespace OFP.Parser
{
    /// <summary>
    /// Реализация разбора и хранения значения с типом <see cref="Color">.
    /// </summary>
    internal class ColorListener : OrdinaryFormBaseListener, IValueCollector<Color>
    {
        private readonly ParseTreeProperty<Color> _values = new ParseTreeProperty<Color>();

        private readonly ITokenCollector _tokens;

        public ColorListener (ITokenCollector tokenCollector)
        {
            _tokens = tokenCollector;
        }

        public Color Get(IParseTree node)
        {
            var value = _values.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return value;
        }

        public override void ExitColor(OrdinaryFormParser.ColorContext context)
        {

            var color = new AutoColor();




        }

    }



}
