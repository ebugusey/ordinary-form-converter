grammar Label;

import FormElement;

label
:
    BLOCK_START
        LABEL_GUID
        VS NUMBER // идентификатор элемента
        VS label_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

label_value
:
    BLOCK_START
        NUMBER // 3
        VS BLOCK_START
            decoration
            VS NUMBER // 11
            VS localized_string // Заголовок
            VS NUMBER // (0..2|4) ГоризонтальноеПоложение
            VS NUMBER // (0..2) ВертикальноеПоложение
            VS NUMBER // (0|1) Гиперссылка
            VS NUMBER // (0|1) ВыделятьОтрицательные
            VS NUMBER // 0
            VS shortcut
            VS NUMBER // (0..5) БегущаяСтрока
            VS localized_string // Формат
            VS NUMBER // 1
            VS picture_block
            VS NUMBER // 4
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
        BLOCK_END
        VS events
    BLOCK_END
;
