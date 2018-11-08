grammar Button;

import V8InternalsLexer, Common, Picture, FormElement, Menu;

button
:
    BLOCK_START
        BUTTON_GUID
        VS NUMBER // идентификатор элемента
        VS buttonValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

buttonValue
:
    BLOCK_START
        NUMBER // 1
        VS BLOCK_START
            decoration
            VS NUMBER // 14
            VS localizedString // Заголовок
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
