grammar CommandLink;

import V8InternalsLexer;

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
    '9d0a2e40-b978-11d4-84b6-008048da06df'
    VS NUMBER // 0
;

unknownCommandLink
:
    '357c6a54-357d-425d-a2bd-22f4f6e86c87'
    VS NUMBER // 0|2147483647
;

formCommandLink
:
    '00000000-0000-0000-0000-000000000000'
    VS NUMBER // идентификатор команды формы
;

tabularSectionCommandLink
:
    '6b7291bf-bcd2-41af-bac7-414d47cc6e6a'
    VS NUMBER // идентификатор команды табличной части
;

formCommandCollectionLink
:
    'b78f2e80-ec68-11d4-9dcf-0050bae2bc79'
    VS NUMBER // 4 - форма | 55 - Действия (обработка)
;

popupCommandCollectionLink
:
    '31946946-0a9b-40a2-95cf-82f200778341'
    VS NUMBER // 0
;

tabularSectionCommandCollectionLink
:
    '875faa24-ba4b-4731-9f11-7a7cea99ef16'
    VS NUMBER // 16 - История отборов (табличная часть обработки)
;
