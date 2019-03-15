using System;

namespace OFP.ObjectModel.FormElements.Data.Extensions
{
    public class CharTypeRefExtension : ElementExtension
    {
        public override Guid Id => new Guid("5f656c99-ee3b-4bb7-92a1-e6f5a93c2c9d");

        /// <summary>
        /// БыстрыйВыбор.
        /// </summary>
        public bool IsQuickChoice { get; set; }

        /// <summary>
        /// ВыборГруппИЭлементов.
        /// </summary>
        public FoldersAndItemsUse FoldersAndItemsChoiceMode { get; set; }

        // TODO: Возможно стоит пересмотреть тип свойства.
        //      В конфигураторе в этом поле можно выбрать много всякого.
        //      и вроде как это должна быть ссылка на элемент, с которым
        //      связано поле ввода.
        /// <summary>
        /// Связь по владельцу.
        /// </summary>
        public string OwnerLinkDataPath { get; set; }

        public CharTypeRefExtension()
        {
            FoldersAndItemsChoiceMode = FoldersAndItemsUse.FoldersAndItems;
            OwnerLinkDataPath = string.Empty;
        }
    }
}
