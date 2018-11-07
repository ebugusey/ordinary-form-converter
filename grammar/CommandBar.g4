grammar CommandBar;

import V8InternalsLexer, FormElement, Menu, CommandLink;

command_bar
:
    BLOCK_START
        'e69bf21d-97b2-4f37-86db-675aea9ec2cb'
        VS NUMBER // идентификатор элемента
        VS command_bar_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

command_bar_value
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
            VS form_command_collection_link // 4
            VS command_bar_separator_command_link
            VS NUMBER VS NUMBER // 0,0
        BLOCK_END
    BLOCK_END
;
