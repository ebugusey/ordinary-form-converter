grammar Font;

import Common;

font
:
    relativeFont
    | absoluteFont
;

relativeFont
:
    BLOCK_START
        NUMBER // 7
        VS Kind = NUMBER // Вид
        VS Mask = NUMBER // маска
        ( VS fontStyle )?
        ( VS NUMBER )? // размер * 10
        ( VS NUMBER )? // полужирный
        ( VS NUMBER )? // курсив
        ( VS NUMBER )? // подчеркнутый
        ( VS NUMBER )? // зачеркнутый
        ( VS FaceName = STRING )? // имя шрифта
        VS NUMBER // 1
        VS Scale = NUMBER // масштаб
    BLOCK_END
;
fontStyle
:
    BLOCK_START
        Value = NUMBER
        ( VS GUID )?
    BLOCK_END
;

absoluteFont
:
    BLOCK_START
        NUMBER // 7
        VS NUMBER // Вид
        VS NUMBER // 0 (маска)
        VS Size = NUMBER // размер
        VS NUMBER VS NUMBER VS NUMBER // 0,0,0
        VS Bold = NUMBER // полужирный
        VS Italic = NUMBER // курсив
        VS Underline = NUMBER // подчеркнутый
        VS Strikeout = NUMBER // зачеркнутый
        VS NUMBER VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,0,0,0
        VS FaceName = STRING // имя шрифта
        VS NUMBER // 1
        VS Scale = NUMBER // масштаб
    BLOCK_END
;
