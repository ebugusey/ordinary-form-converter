grammar CommandBar;

import V8InternalsLexer, FormElement, Menu, CommandLink;

commandBar
:
    BLOCK_START
        'e69bf21d-97b2-4f37-86db-675aea9ec2cb'
        VS NUMBER // идентификатор элемента
        VS commandBarValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

commandBarValue
:
    BLOCK_START
        NUMBER // 2
        VS BLOCK_START
            decoration
            VS NUMBER // 9
            VS NUMBER // Ориентация
            VS NUMBER // АвтоЗаполнение
            VS NUMBER // ВыравниваниеКнопок
            VS NUMBER // Вспомогательная
            VS NUMBER // 1
            VS menu
            VS formCommandCollectionLink // 4
            VS commandBarSeparatorCommandLink
            VS NUMBER VS NUMBER // 0,0
        BLOCK_END
    BLOCK_END
;
