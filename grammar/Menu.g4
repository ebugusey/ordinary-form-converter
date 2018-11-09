grammar Menu;

import Common, Picture, Actions;

menu
:
    BLOCK_START
        NUMBER // 5
        VS GUID // идентификатор меню
        VS NUMBER // ревизия
        VS NUMBER // 1
        VS menuItemList
        VS submenuList
    BLOCK_END
;

menuItemList
:
    NUMBER // количество элементов
    ( VS menuItem )*
;
menuItem
:
    BLOCK_START
        NUMBER // 6
        VS GUID // идентификатор кнопки командной панели
        VS NUMBER // 1
        VS anyAction
        // Маска:
        // 0x1 - Картинка,
        // 0x2 - Подсказка,
        // 0x4 - Пояснение,
        // 0x8 - СочетаниеКлавиш.
        VS NUMBER
        ( VS localizedString )? // Подсказка
        ( VS localizedString )? // Пояснение
        ( VS picture )? // Картинка
        ( VS shortcut )? // СочетаниеКлавиш
    BLOCK_END
;

submenuList
:
    NUMBER // количество элементов
    ( VS submenu )+
;
submenu
:
    BLOCK_START
        NUMBER // 5
        VS commandCollectionLink // идентификатор коллекции, от которой "наследуется" подменю
        VS NUMBER // ? 1 - стандартное меню
        VS commandBarButtonList
        VS BLOCK_START
            NUMBER // -1|0
            VS NUMBER // 0
            VS submenuData
        BLOCK_END
    BLOCK_END
;

submenuData
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS submenuDataItem )*
    BLOCK_END
;
submenuDataItem
:
    // идентификатор коллекции, для которой задаются параметры
    customCommandCollectionLink
    VS NUMBER // ПорядокКнопок
;

commandBarButtonList
:
    NUMBER // количество элементов
    ( VS commandBarButton )*
;
commandBarButton
:
    GUID // идентификатор кнопки командной панели
    VS BLOCK_START
        NUMBER //  8
        VS STRING // Имя
        VS NUMBER // ИзменяетДанные
        VS NUMBER // 1
        VS localizedString // Текст
        VS NUMBER // 0
        // идентификатор подчиненной коллекции команд
        VS customCommandCollectionLink
        VS NUMBER // 1e2 (100)
        VS NUMBER // ТипКнопки
        VS NUMBER // Отображение
        VS NUMBER // Доступность
        VS NUMBER // Пометка
        VS NUMBER VS NUMBER VS NUMBER // 0,0,0
    BLOCK_END
;
