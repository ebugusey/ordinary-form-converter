grammar Actions;

import V8InternalsLexer, Common, Picture, CommandLink;

any_action
:
    custom_action
    | special_action
    | standard_action
    | standard_submenu
;

custom_action
:
    'e1692cc2-605b-4535-84dd-28440238746c'
    VS BLOCK_START
        NUMBER // 3
        VS STRING // имя обработчика
        VS BLOCK_START
            NUMBER // 1
            VS STRING // имя обработчика
            VS localized_string
            VS localized_string
            VS localized_string
            VS picture
            VS shortcut
        BLOCK_END
    BLOCK_END
;

special_action
:
    'abde0c9a-18a6-4e0c-bbaa-af26b911b3e6'
    VS
    (
        empty_action_value
        | separator_value
        | custom_submenu_value
    )
;

empty_action_value
:
    BLOCK_START
        NUMBER // 1
        VS unknown_command_link
    BLOCK_END
;

separator_value
:
    BLOCK_START
        NUMBER // 1
        VS command_bar_separator_command_link
    BLOCK_END
;

custom_submenu_value
:
    BLOCK_START
        NUMBER // 1
        VS custom_command_collection_link
    BLOCK_END
;

standard_submenu
:
    'c93a51ed-b2d1-47f1-948d-38373f8710af'
    VS
    (
        form_standard_submenu_value
        | tabular_section_standard_submenu_value
    )
;

form_standard_submenu_value
:
    BLOCK_START
        NUMBER // 4
        VS form_command_collection_link // 55 - Действия
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS form_command_collection_link // 4
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER VS NUMBER // 0,0
    BLOCK_END
;

tabular_section_standard_submenu_value
:
    BLOCK_START
        NUMBER // 4
        VS tabular_section_command_collection_link
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS form_command_collection_link // 4
            VS NUMBER // 1
        BLOCK_END
        VS NUMBER VS NUMBER // 0,0
    BLOCK_END
;

standard_action
:
    'fbe38877-b914-4fd5-8540-07dde06ba2e1'
    VS
    (
        form_standard_action_value
        | table_standard_action_value
        | tabular_section_standard_action_value
    )
;

form_standard_action_value
:
    BLOCK_START
        NUMBER VS NUMBER // 6,0
        // Форма:
        // 142 - Закрыть
        // 300 - Справка
        // Форма обработки:
        // 143 - Сохранить значения...
        // 144 - Восстановить значения...
        VS form_command_link
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS form_command_collection_link
            VS NUMBER // 1 - форма обработки, 0 - форма
        BLOCK_END
        VS NUMBER VS NUMBER // 0,1
    BLOCK_END
;

table_standard_action_value
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
        VS form_command_link
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS unknown_command_link // идентификатор = 2147483647
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER VS NUMBER // 0,1
    BLOCK_END
;

tabular_section_standard_action_value
:
    BLOCK_START
        NUMBER VS NUMBER // 6,0
        // 53 - Установить отбор и сортировку списка...
        // 71 - (История отборов)
        // 72 - (Список отборов)
        VS tabular_section_command_link
        VS BLOCK_START
            NUMBER VS NUMBER // 1,99
            VS unknown_command_link // идентификатор = 2147483647
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER VS NUMBER // 0,1
    BLOCK_END
;
