grammar Menu;

import V8InternalsLexer, Common, Picture, Actions;

menu
:
    BLOCK_START
        NUMBER // 5
        VS GUID // идентификатор меню
        VS NUMBER // ревизия
        VS NUMBER // 1
        VS menu_item_list
        VS submenu_list
    BLOCK_END
;

menu_item_list
:
    NUMBER // количество элементов
    ( VS menu_item )*
;
menu_item
:
    BLOCK_START
        NUMBER // 6
        VS GUID // идентификатор кнопки командной панели
        VS NUMBER // 1
        VS any_action
        // Маска:
        // 0x1 - Картинка,
        // 0x2 - Подсказка,
        // 0x4 - Пояснение,
        // 0x8 - СочетаниеКлавиш.
        VS NUMBER
        ( VS localized_string )? // Подсказка
        ( VS localized_string )? // Пояснение
        ( VS picture )? // Картинка
        ( VS shortcut )? // СочетаниеКлавиш
    BLOCK_END
;

submenu_list
:
    NUMBER // количество элементов
    ( VS submenu )+
;
submenu
:
    BLOCK_START
        NUMBER // 5
        VS command_collection_link // идентификатор коллекции, от которой "наследуется" подменю
        VS NUMBER // ? 1 - стандартное меню
        VS command_bar_button_list
        VS BLOCK_START
            NUMBER // -1|0
            VS NUMBER // 0
            VS submenu_data
        BLOCK_END
    BLOCK_END
;

submenu_data
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS submenu_data_item )*
    BLOCK_END
;
submenu_data_item
:
    // идентификатор коллекции, для которой задаются параметры
    custom_command_collection_link
    VS NUMBER // ПорядокКнопок
;

command_bar_button_list
:
    NUMBER // количество элементов
    ( VS command_bar_button )*
;
command_bar_button
:
    GUID // идентификатор кнопки командной панели
    VS BLOCK_START
        NUMBER //  8
        VS STRING // Имя
        VS NUMBER // ИзменяетДанные
        VS NUMBER // 1
        VS localized_string // Текст
        VS NUMBER // 0
        // идентификатор подчиненной коллекции команд
        VS custom_command_collection_link
        VS NUMBER // 1e2 (100)
        VS NUMBER // ТипКнопки
        VS NUMBER // Отображение
        VS NUMBER // Доступность
        VS NUMBER // Пометка
        VS NUMBER VS NUMBER VS NUMBER // 0,0,0
    BLOCK_END
;
