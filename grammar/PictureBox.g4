grammar PictureBox;

import FormElement;

pictureBox
:
    BLOCK_START
        PICTURE_BOX_GUID
        VS NUMBER // идентификатор элемента
        VS pictureBoxValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

pictureBoxValue
:
    BLOCK_START
        NUMBER // 1
        VS BLOCK_START
            decoration
            VS NUMBER // 18
            VS NUMBER // (0..4) РазмерКартинки
            VS NUMBER // (0|1) Гиперссылка
            VS BLOCK_START
                NUMBER // 7
                VS NUMBER // (0..4) РазмерКартинки
                VS picture // Картинка
                VS picture // Картинка, не используется
                VS picture // Картинка, не используется
                VS NUMBER // 100
                VS NUMBER // 0
                VS NUMBER // 0
            BLOCK_END
            VS shortcut // СочетаниеКлавиш
            VS NUMBER // (0|1) Масштабировать
            VS NUMBER // (0|1) ИспользоватьКонтекстноеМеню
            VS NUMBER // (0|1) РазрешитьНачалоПеретаскивания
            VS NUMBER // (0|1) РазешитьПеретаскивание
            VS localizedString // ТекстНевыбраннойКартинки
            VS NUMBER // 0
            VS NUMBER // 1
        BLOCK_END
        VS events
    BLOCK_END
;
