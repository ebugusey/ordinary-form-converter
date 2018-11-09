grammar HTMLDocumentField;

import FormElement;

start: htmlDocumentField EOF ;

htmlDocumentField
:
    BLOCK_START
        HTML_DOCUMENT_GUID
        VS NUMBER // идентификатор элемента
        VS htmlDocumentFieldValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

htmlDocumentFieldValue
:
    BLOCK_START
        NUMBER // 5
        VS NUMBER // 0
        VS events
        VS color
        VS border
        VS NUMBER // (1..2) Режим
        VS NUMBER // (0..2) Вывод
    BLOCK_END
;
