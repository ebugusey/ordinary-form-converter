grammar Picture;

import Common;

pictureBlock
:
    BLOCK_START
        NUMBER // 7
        VS NUMBER // РазмерКартинки
        VS picture // Картинка
        VS emptyPicture // пустая
        VS emptyPicture // пустая
        VS NUMBER // 100
        VS NUMBER // 0 - для панели, 2 - для страницы
        VS NUMBER // 0
    BLOCK_END
;

picture
:
    emptyPicture
    | libraryPicture
    | absolutePicture
;

emptyPicture
:
    BLOCK_START
        NUMBER // 4
        VS NUMBER // ВидКартинки
        VS libraryPictureEmptyLink
        VS STRING // ""
        VS NUMBER VS NUMBER // координаты прозрачного пикселя
        VS NUMBER // установлена прозрачность
        VS NUMBER // 0
        VS STRING // ""
    BLOCK_END
;

libraryPicture
:
    BLOCK_START
        NUMBER // 4
        VS NUMBER // ВидКартинки
        VS libraryPictureLink
        VS STRING // ""
        VS NUMBER VS NUMBER // координаты прозрачного пикселя
        VS NUMBER // установлена прозрачность
        VS NUMBER // 0
        VS STRING // ""
    BLOCK_END
;

absolutePicture
:
    BLOCK_START
        NUMBER // 4
        VS NUMBER // ВидКартинки
        VS libraryPictureEmptyLink
        VS STRING // ""
        VS NUMBER VS NUMBER // координаты прозрачного пикселя
        VS NUMBER // установлена прозрачность
        VS absolutePictureData
        VS NUMBER // 0
        VS STRING // ""
    BLOCK_END
;

libraryPictureLink
:
    // Указатель на картинку из БиблиотекаКартинок.
    // Картинка из библиотеки может быть задана как числом,
    // так и GUID-ом.
    BLOCK_START
        NUMBER // 0 - указан GUID
        ( VS GUID )? // uuid картинки из библиотеки или конфигурации
    BLOCK_END
;
libraryPictureEmptyLink
:
    BLOCK_START
        NUMBER // 0
    BLOCK_END
;

absolutePictureData
:
    // Обычно это двоичные данные.
    // Но для колонок табличного поля картинка задается
    // индексом картинки в массиве данных, который представляет
    // элемент управления колонки.
    BLOCK_START
        ( base64 | NUMBER )
    BLOCK_END
;
