grammar Checkbox;

import FormElement;

checkbox
:
    BLOCK_START
        CHECKBOX_GUID
        VS NUMBER // идентификатор элемента
        VS checkbox_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

checkbox_value
:
    BLOCK_START
        NUMBER // 1
        VS BLOCK_START
            BLOCK_START
                decoration
                VS NUMBER // 6
                VS localized_string // Заголовок
                VS NUMBER // (0..1) ПоложениеЗаголовка
                VS NUMBER // (0..2) ГоризонтальноеПоложение
                VS NUMBER // (0..2) ВертикальноеПоложение
                VS NUMBER // 0
                VS NUMBER // 100
                VS NUMBER // 1
            BLOCK_END
            VS NUMBER // 4
            VS NUMBER // (0|1) ТриСостояния, только для тпа данных Число
            VS NUMBER // (0|1) ? изменяется при смене типа данных, число - 1, булево - 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
        BLOCK_END
        VS events
    BLOCK_END
;
