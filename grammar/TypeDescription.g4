grammar TypeDescription;

import Common;

typeDescription
:
    BLOCK_START
        STRING // "Pattern"
        ( VS typeDescriptionValue )*
    BLOCK_END
;

typeDescriptionValue
:
    typeDescriptionQ3
    | typeDescriptionQ2
    | typeDescriptionQ0
    | typeDescriptionDateTime
    | typeDescriptionRef
;

typeDescriptionQ2
:
    // Строка или двоичные данные.
    BLOCK_START
        STRING // S|R
        VS NUMBER // Длина
        VS NUMBER // ДопустимаяДлина
    BLOCK_END
;

typeDescriptionQ3
:
    // Число.
    BLOCK_START
        STRING // N
        VS NUMBER // Разрядность
        VS NUMBER // РазрядностьДробнойЧасти
        VS NUMBER // ДопустимыйЗнак
    BLOCK_END
;

typeDescriptionQ0
:
    // Любой тип.
    // Для типа не указаны квалификаторы,
    // или тип не требует квалификаторов (Булево).
    BLOCK_START
        STRING // B|N|S|D|R
    BLOCK_END
;

typeDescriptionDateTime
:
    // Дата.
    BLOCK_START
        STRING // D
        VS STRING // ЧастиДаты ("T" - Time, "D" - Date, отсутствует - DateTime)
    BLOCK_END
;

typeDescriptionRef
:
    // Ссылочный тип.
    BLOCK_START
        STRING // #
        VS GUID // xr:TypeId типа из конфигурации или идентификатор типа платформы
    BLOCK_END
;

typedValue
:
    BLOCK_START
        STRING // U|B|N|S|D|R|#
        (
            VS
            ( NUMBER | STRING | GUID )
        )?
    BLOCK_END
;
