using System;

namespace OFP.ObjectModel.FormElements.Data.Extensions
{
    public class CatalogRefExtension : ElementExtension
    {
        public override Guid Id => new Guid("8585207b-9ca7-425b-9385-e8fd67c4e148");

        /// <summary>
        /// БыстрыйВыбор.
        /// </summary>
        public bool IsQuickChoice { get; set; }

        /// <summary>
        /// ВыборГруппИЭлементов.
        /// </summary>
        public FoldersAndItemsUse FoldersAndItemsChoiceMode { get; set; }

        /// <summary>
        /// Связь по владельцу.
        /// </summary>
        public string OwnerLinkDataPath { get; set; }

        public CatalogRefExtension()
        {
            FoldersAndItemsChoiceMode = FoldersAndItemsUse.FoldersAndItems;
            OwnerLinkDataPath = string.Empty;
        }
    }
}
