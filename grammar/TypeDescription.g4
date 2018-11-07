grammar TypeDescription;

import V8InternalsLexer;

type_description
:
    BLOCK_START
        STRING // "Pattern"
        ( VS type_description_value )*
    BLOCK_END
;

type_description_value
:
    type_description_3q
    | type_description_2q
    | type_description_non_q
    | type_description_datetime
    | type_description_ref
;

type_description_2q
:
    // Строка или двоичные данные.
    BLOCK_START
        STRING // S|R
        VS NUMBER // Длина
        VS NUMBER // ДопустимаяДлина
    BLOCK_END
;

type_description_3q
:
    // Число.
    BLOCK_START
        STRING // N
        VS NUMBER // Разрядность
        VS NUMBER // РазрядностьДробнойЧасти
        VS NUMBER // ДопустимыйЗнак
    BLOCK_END
;

type_description_non_q
:
    // Любой тип.
    // Для типа не указаны квалификаторы,
    // или тип не требует квалификаторов (Булево).
    BLOCK_START
        STRING // B|N|S|D|R
    BLOCK_END
;

type_description_datetime
:
    // Дата.
    BLOCK_START
        STRING // D
        VS STRING // ЧастиДаты ("T" - Time, "D" - Date, отсутствует - DateTime)
    BLOCK_END
;

type_description_ref
:
    // Ссылочный тип.
    BLOCK_START
        STRING // #
        VS GUID // xr:TypeId типа из конфигурации или идентификатор типа платформы
    BLOCK_END
;

typed_value
:
    BLOCK_START
        STRING // U|B|N|S|D|R|#
        (
            VS
            ( NUMBER | STRING | GUID )
        )?
    BLOCK_END
;
