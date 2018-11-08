grammar Label;

import KeywordsLexer, V8InternalsLexer, Common, Picture, FormElement;

label
:
    BLOCK_START
        LABEL_GUID
        VS NUMBER // идентификатор элемента
        VS labelValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

labelValue
:
    BLOCK_START
        NUMBER // 3
        VS BLOCK_START
            decoration
            VS NUMBER // 11
            VS localizedString // Заголовок
            VS NUMBER // (0..2|4) ГоризонтальноеПоложение
            VS NUMBER // (0..2) ВертикальноеПоложение
            VS NUMBER // (0|1) Гиперссылка
            VS NUMBER // (0|1) ВыделятьОтрицательные
            VS NUMBER // 0
            VS shortcut
            VS NUMBER // (0..5) БегущаяСтрока
            VS localizedString // Формат
            VS NUMBER // 1
            VS pictureBlock
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
