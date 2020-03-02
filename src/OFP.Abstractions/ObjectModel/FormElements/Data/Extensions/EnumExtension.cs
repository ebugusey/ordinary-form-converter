using System;

namespace OFP.ObjectModel.FormElements.Data.Extensions
{
    public class EnumExtension : ElementExtension
    {
        public override Guid Id => new Guid("30ee7b7c-8dac-4e20-b58e-e7f7742ae8d8");

        /// <summary>
        /// БыстрыйВыбор.
        /// </summary>
        public bool IsQuickChoice { get; set; }
    }
}
