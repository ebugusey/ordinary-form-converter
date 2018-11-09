grammar Font;

import Common;

font
:
    autoFont
    | styleBasedFont
    | absoluteFont
;

autoFont
:
    BLOCK_START
        NUMBER // 7
        VS NUMBER // Вид
        VS NUMBER // маска
        ( VS NUMBER )? // размер * 10
        ( VS NUMBER )? // полужирный
        ( VS NUMBER )? // курсив
        ( VS NUMBER )? // подчеркнутый
        ( VS NUMBER )? // зачеркнутый
        ( VS STRING )? // имя шрифта
        VS NUMBER // 1
        VS NUMBER // масштаб
    BLOCK_END
;

styleBasedFont
:
    BLOCK_START
        NUMBER // 7
        VS NUMBER // Вид
        VS NUMBER // маска
        VS fontStyle
        ( VS NUMBER )? // размер * 10
        ( VS NUMBER )? // полужирный
        ( VS NUMBER )? // курсив
        ( VS NUMBER )? // подчеркнутый
        ( VS NUMBER )? // зачеркнутый
        ( VS STRING )? // имя шрифта
        VS NUMBER // 1
        VS NUMBER // масштаб
    BLOCK_END
;
fontStyle
:
    BLOCK_START
        NUMBER
        ( VS GUID )?
    BLOCK_END
;

absoluteFont
:
    BLOCK_START
        NUMBER // 7
        VS NUMBER // Вид
        VS NUMBER // 0 (маска)
        VS NUMBER // размер
        VS NUMBER VS NUMBER VS NUMBER // 0,0,0
        VS NUMBER // полужирный
        VS NUMBER // курсив
        VS NUMBER // подчеркнутый
        VS NUMBER // зачеркнутый
        VS NUMBER VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,0,0,0
        VS STRING // имя шрифта
        VS NUMBER // 1
        VS NUMBER // масштаб
    BLOCK_END
;
