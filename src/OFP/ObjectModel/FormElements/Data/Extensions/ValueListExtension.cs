using System;
using OFP.ObjectModel.Platform.Types;

namespace OFP.ObjectModel.FormElements.Data.Extensions
{
    public class ValueListExtension : ElementExtension
    {
        public override Guid Id => new Guid("83a29520-06e8-4348-989c-abe69e8e33e2");

        /// <summary>
        /// ТипЗначенияСписка.
        /// </summary>
        public TypeDescription ValueType { get; set; }
    }
}
