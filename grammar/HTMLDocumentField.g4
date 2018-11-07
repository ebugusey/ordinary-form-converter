grammar HTMLDocumentField;

import FormElement;

html_document_field
:
    BLOCK_START
        HTML_DOCUMENT_GUID
        VS NUMBER // идентификатор элемента
        VS html_document_field_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

html_document_field_value
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
