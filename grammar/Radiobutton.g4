grammar Radiobutton;

import GUIDsLexer, V8InternalsLexer, Common, FormElement, TypeDescription;

radiobutton
:
    BLOCK_START
        RADIOBUTTON_GUID
        VS NUMBER // идентификатор элемента
        VS radiobutton_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

radiobutton_value
:
    BLOCK_START
        NUMBER // 4
        VS type_description // Данные
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
            VS NUMBER // 3
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER // 0
        VS typed_value
        VS events
    BLOCK_END
;
