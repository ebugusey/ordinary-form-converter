grammar RadioButton;

import FormElement, TypeDescription;

start: radioButton EOF ;

radioButton
:
    BLOCK_START
        RADIOBUTTON_GUID
        VS NUMBER // идентификатор элемента
        VS radioButtonValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

radioButtonValue
:
    BLOCK_START
        NUMBER // 4
        VS typeDescription // Данные
        VS BLOCK_START
            BLOCK_START
                decoration
                VS NUMBER // 6
                VS localizedString // Заголовок
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
        VS typedValue
        VS events
    BLOCK_END
;
