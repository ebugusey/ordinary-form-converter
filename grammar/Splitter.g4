grammar Splitter;

import V8InternalsLexer, Common, FormElement, InputField, Picture;

splitter
:
    BLOCK_START
        '36e52348-5d60-4770-8e89-a16ed50a2006'
        VS NUMBER // идентификатор элемента
        VS splitter_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

splitter_value
:
    BLOCK_START
        NUMBER // 0
        VS BLOCK_START
            decoration
            VS NUMBER // 2
            VS NUMBER // (0..2) Ориентация
            VS NUMBER // 0
        BLOCK_END
    BLOCK_END
;
