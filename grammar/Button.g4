grammar Button;

import V8InternalsLexer, Common, Picture, FormElement, Menu;

button
:
    BLOCK_START
        '6ff79819-710e-4145-97cd-1618da79e3e2'
        VS NUMBER // идентификатор элемента
        VS button_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

button_value
:
    BLOCK_START
        NUMBER // 1
        VS BLOCK_START
            decoration
            VS NUMBER // 14
            VS localized_string // Заголовок
            VS NUMBER // ГоризонтальноеПоложение
            VS NUMBER // ВертикальноеПоложение?
            VS NUMBER // КнопкаПоУмолчанию
            VS NUMBER // ПоложениеКартинки
            VS NUMBER // РазмерКартинки
            VS picture // Картинка
            VS shortcut // СочетаниеКлавиш
            VS NUMBER // МногострочныйРежим
            VS NUMBER // РежимМеню
            ( VS menu )?
            VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,0,1
        BLOCK_END
        VS events
    BLOCK_END
;
