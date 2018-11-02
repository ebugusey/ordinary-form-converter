grammar Picture;

import V8InternalsLexer, Common;

picture
:
    empty_picture
    | library_picture
    | absolute_picture
;

empty_picture
:
    BLOCK_START
        NUMBER // 4
        VS NUMBER // ВидКартинки
        VS library_picture_empty_link
        VS STRING // ""
        VS NUMBER VS NUMBER // координаты прозрачного пикселя
        VS NUMBER // установлена прозрачность
        VS NUMBER // 0
        VS STRING // ""
    BLOCK_END
;

library_picture
:
    BLOCK_START
        NUMBER // 4
        VS NUMBER // ВидКартинки
        VS library_picture_link
        VS STRING // ""
        VS NUMBER VS NUMBER // координаты прозрачного пикселя
        VS NUMBER // установлена прозрачность
        VS NUMBER // 0
        VS STRING // ""
    BLOCK_END
;

absolute_picture
:
    BLOCK_START
        NUMBER // 4
        VS NUMBER // ВидКартинки
        VS library_picture_empty_link
        VS STRING // ""
        VS NUMBER VS NUMBER // координаты прозрачного пикселя
        VS NUMBER // установлена прозрачность
        VS absolute_picture_data
        VS NUMBER // 0
        VS STRING // ""
    BLOCK_END
;

library_picture_link
:
    // Указатель на картинку из БиблиотекаКартинок.
    // Картинка из библиотеки может быть задана как числом,
    // так и GUID-ом.
    BLOCK_START
        NUMBER // 0 - указан GUID
        ( VS GUID )? // uuid картинки из библиотеки или конфигурации
    BLOCK_END
;
library_picture_empty_link
:
    BLOCK_START
        NUMBER // 0
    BLOCK_END
;

absolute_picture_data
:
    // Обычно это двоичные данные.
    // Но для колонок табличного поля картинка задается
    // индексом картинки в массиве данных, который представляет
    // элемент управления колонки.
    BLOCK_START
        ( base64 | NUMBER )
    BLOCK_END
;
