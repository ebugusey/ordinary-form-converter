grammar Common;

import GUIDsLexer, V8InternalsLexer;

color
:
    BLOCK_START
        NUMBER // 3
        VS NUMBER // Вид
        VS color_value
    BLOCK_END
;
color_value
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

border
:
    BLOCK_START
        NUMBER // 3
        VS NUMBER // Вид
        VS BLOCK_START
            NUMBER
            ( VS GUID )?
        BLOCK_END
        VS NUMBER // ТипРамки
        VS NUMBER // Толщина
        VS NUMBER
        ( VS BORDER_GUID )?
    BLOCK_END
;

localized_string
:
    BLOCK_START
        NUMBER // 1
        VS NUMBER // количество элементов
        ( VS localized_string_item )*
    BLOCK_END
;
localized_string_item
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

any_guid
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
    | CHECKBOX_GUID
    | HTML_DOCUMENT_GUID
    | INPUT_FIELD_GUID
    | LABEL_GUID
    | PANEL_GUID
    | PICTURE_BOX_GUID
    | RADIOBUTTON_GUID
    | SPLITTER_GUID
    | SPREADSHEET_DOCUMENT_GUID
;

any_value: any_block | NUMBER | STRING | any_guid ;

any_block: BLOCK_START any_value ( VS any_value )* BLOCK_END ;

empty_list
:
    BLOCK_START
        NUMBER // 0
    BLOCK_END
;

empty_block
:
    BLOCK_START
    BLOCK_END
;
