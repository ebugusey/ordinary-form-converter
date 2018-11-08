grammar Actions;

import KeywordsLexer, V8InternalsLexer, Common, Picture, CommandLink;

anyAction
:
    customAction
    | specialAction
    | standardAction
    | standardSubmenu
;

customAction
:
    CUSTOM_ACTION_GUID
    VS BLOCK_START
        NUMBER // 3
        VS STRING // имя обработчика
        VS BLOCK_START
            NUMBER // 1
            VS STRING // имя обработчика
            VS localizedString
            VS localizedString
            VS localizedString
            VS picture
            VS shortcut
        BLOCK_END
    BLOCK_END
;

specialAction
:
    SPECIAL_ACTION_GUID
    VS
    (
        emptyActionValue
        | separatorValue
        | customSubmenuValue
    )
;

emptyActionValue
:
    BLOCK_START
        NUMBER // 1
        VS unknownCommandLink
    BLOCK_END
;

separatorValue
:
    BLOCK_START
        NUMBER // 1
        VS commandBarSeparatorCommandLink
    BLOCK_END
;

customSubmenuValue
:
    BLOCK_START
        NUMBER // 1
        VS customCommandCollectionLink
    BLOCK_END
;

standardSubmenu
:
    STANDARD_SUBMENU_GUID
    VS
    (
        formStandardSubmenuValue
        | tabularSectionStandardSubmenuValue
    )
;

formStandardSubmenuValue
:
    BLOCK_START
        NUMBER // 4
        VS formCommandCollectionLink // 55 - Действия
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS formCommandCollectionLink // 4
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER VS NUMBER // 0,0
    BLOCK_END
;

tabularSectionStandardSubmenuValue
:
    BLOCK_START
        NUMBER // 4
        VS tabularSectionCommandCollectionLink
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS formCommandCollectionLink // 4
            VS NUMBER // 1
        BLOCK_END
        VS NUMBER VS NUMBER // 0,0
    BLOCK_END
;

standardAction
:
    STANDARD_ACTION_GUID
    VS
    (
        formStandardActionValue
        | tableStandardActionValue
        | tabularSectionStandardActionValue
    )
;

formStandardActionValue
:
    BLOCK_START
        NUMBER VS NUMBER // 6,0
        // Форма:
        // 142 - Закрыть
        // 300 - Справка
        // Форма обработки:
        // 143 - Сохранить значения...
        // 144 - Восстановить значения...
        VS formCommandLink
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS formCommandCollectionLink
            VS NUMBER // 1 - форма обработки, 0 - форма
        BLOCK_END
        VS NUMBER VS NUMBER // 0,1
    BLOCK_END
;

tableStandardActionValue
:
    BLOCK_START
        NUMBER VS NUMBER // 6,0
        // 80 - Добавить
        // 82 - Скопировать
        // 83 - Удалить
        // 84 - Изменить
        // 85 - Переместить вверх
        // 86 - Переместить вниз
        // 88 - Сортировать по возрастанию
        // 89 - Сортировать по убыванию
        // 91 - Отбор по значению в текущей колонке
        // 93 - Отключить отбор
        // 94 - Закончить редактирование
        // 97 - Настройка списка...
        // 99 - Вывести список...
        VS formCommandLink
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS unknownCommandLink // идентификатор = 2147483647
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER VS NUMBER // 0,1
    BLOCK_END
;

tabularSectionStandardActionValue
:
    BLOCK_START
        NUMBER VS NUMBER // 6,0
        // 53 - Установить отбор и сортировку списка...
        // 71 - (История отборов)
        // 72 - (Список отборов)
        VS tabularSectionCommandLink
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS unknownCommandLink // идентификатор = 2147483647
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER VS NUMBER // 0,1
    BLOCK_END
;
