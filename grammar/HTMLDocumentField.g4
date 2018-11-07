grammar HTMLDocumentField;

import V8InternalsLexer, Common, FormElement, InputField, Picture;

html_document_field
:
    BLOCK_START
        'd92a805c-98ae-4750-9158-d9ce7cec2f20'
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
