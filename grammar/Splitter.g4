grammar Splitter;

import GUIDsLexer, V8InternalsLexer, Common, FormElement;

splitter
:
    BLOCK_START
        SPLITTER_GUID
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
