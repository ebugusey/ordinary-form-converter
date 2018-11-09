grammar Common;

import MainLexer;

color
:
    BLOCK_START
        NUMBER // 3
        VS NUMBER // Вид
        VS colorValue
    BLOCK_END
;
colorValue
:
    BLOCK_START
        // Значение цвета:
        // всегда 0 - для AutoColor,
        // двоичное значение BGR в виде uint - для Absolute,
        // идентификатор - для перечислений,
        // всегда 0 - для стиля из конфигурации.
        NUMBER
        ( VS GUID )? // uuid стиля конфигурации с типом Цвет
    BLOCK_END
;

localizedString
:
    BLOCK_START
        NUMBER // 1
        VS NUMBER // количество элементов
        ( VS localizedStringItem )*
    BLOCK_END
;
localizedStringItem
:
    BLOCK_START
        STRING // код языка
        VS STRING // значение
    BLOCK_END
;

base64
:
    BLOCK_START
        BASE64
    BLOCK_END
;

shortcut
:
    BLOCK_START
        NUMBER // 0
        VS NUMBER // Клавиша
        VS NUMBER // маска (0x4, - Shift, 0x8 - Ctrl, 0x10 - Alt)
    BLOCK_END
;

anyGuid
:
    GUID
    | EMPTY_GUID

    | BORDER_GUID
    | CUSTOM_ACTION_GUID
    | DATA_LINK_GUID

    | SIMPLE_EXTENSION_GUID
    | CATALOGREF_EXTENSION_GUID
    | CHARTYPE_EXTENSION_GUID
    | DOCUMENT_EXTENSION_GUID
    | ENUM_EXTENSION_GUID
    | MULTITYPE_EXTENSION_GUID

    | TABLE_BOX_VALUE_TABLE_EXTENSION_GUID
    | TABLE_BOX_VALUE_TREE_EXTENSION_GUID
    | TABLE_BOX_TABULAR_SECTION_EXTENSION_GUID

    | TABLE_BOX_FORM_ATTRIBUTE_COLUMN_GUID
    | TABLE_BOX_TABULAR_SECTION_COLUMN_GUID
    | TABLE_BOX_COLUMN_VALUE_GUID

    | CHECKBOX_GUID
    | HTML_DOCUMENT_GUID
    | TEXT_BOX_GUID
    | LABEL_GUID
    | PANEL_GUID
    | PICTURE_BOX_GUID
    | RADIOBUTTON_GUID
    | SPLITTER_GUID
    | BUTTON_GUID
    | COMMAND_BAR_GUID
    | TABLE_BOX_GUID
    | SPREADSHEET_DOCUMENT_GUID

    | SPECIAL_ACTION_GUID
    | STANDARD_SUBMENU_GUID
    | STANDARD_ACTION_GUID

    | COMMAND_BAR_SEPARATOR_GUID
    | UNKNOWN_COMMAND_GUID
    | TABULAR_SECTION_COMMAND_GUID
    | FORM_COMMAND_COLLECTION_GUID
    | POPUP_COMMAND_COLLECTION_GUID
    | TABULAR_SECTION_COMMAND_COLLECTION_GUID
;

anyValue: anyBlock | NUMBER | STRING | anyGuid ;

anyBlock: BLOCK_START anyValue ( VS anyValue )* BLOCK_END ;

emptyList
:
    BLOCK_START
        NUMBER // 0
    BLOCK_END
;

emptyBlock
:
    BLOCK_START
    BLOCK_END
;
