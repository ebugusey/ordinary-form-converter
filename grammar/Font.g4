grammar Font;

import V8InternalsLexer;

font
:
    auto_font
    | style_based_font
    | absolute_font
;

auto_font
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

style_based_font
:
    BLOCK_START
        NUMBER // 7
        VS NUMBER // Вид
        VS NUMBER // маска
        VS font_style
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
font_style
:
    BLOCK_START
        NUMBER
        ( VS GUID )?
    BLOCK_END
;

absolute_font
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
