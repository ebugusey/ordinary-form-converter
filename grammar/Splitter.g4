grammar Splitter;

import GUIDsLexer, V8InternalsLexer, Common, FormElement;

splitter
:
    BLOCK_START
        SPLITTER_GUID
        VS NUMBER // идентификатор элемента
        VS splitterValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

splitterValue
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
