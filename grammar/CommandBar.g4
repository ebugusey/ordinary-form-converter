grammar CommandBar;

import FormElement, Menu, CommandLink;

commandBar
:
    BLOCK_START
        COMMAND_BAR_GUID
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
