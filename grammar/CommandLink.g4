grammar CommandLink;

import Common;

commandCollectionLink
:
    customCommandCollectionLink
    | formCommandCollectionLink
    | popupCommandCollectionLink
    | tabularSectionCommandCollectionLink
;

customCommandCollectionLink
:
    GUID // идентификатор родительского меню
    VS NUMBER // числовой идентификатор пункта меню
;

commandBarSeparatorCommandLink
:
    COMMAND_BAR_SEPARATOR_GUID
    VS NUMBER // 0
;

unknownCommandLink
:
    UNKNOWN_COMMAND_GUID
    VS NUMBER // 0|2147483647
;

formCommandLink
:
    EMPTY_GUID
    VS NUMBER // идентификатор команды формы
;

tabularSectionCommandLink
:
    TABULAR_SECTION_COMMAND_GUID
    VS NUMBER // идентификатор команды табличной части
;

formCommandCollectionLink
:
    FORM_COMMAND_COLLECTION_GUID
    VS NUMBER // 4 - форма | 55 - Действия (обработка)
;

popupCommandCollectionLink
:
    POPUP_COMMAND_COLLECTION_GUID
    VS NUMBER // 0
;

tabularSectionCommandCollectionLink
:
    TABULAR_SECTION_COMMAND_COLLECTION_GUID
    VS NUMBER // 16 - История отборов (табличная часть обработки)
;
