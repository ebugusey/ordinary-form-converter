grammar CommandLink;

import V8InternalsLexer;

command_collection_link
:
    custom_command_collection_link
    | form_command_collection_link
    | tabular_section_command_collection_link
;

custom_command_collection_link
:
    GUID // идентификатор родительского меню
    VS NUMBER // числовой идентификатор пункта меню
;

command_bar_separator_command_link
:
    '9d0a2e40-b978-11d4-84b6-008048da06df'
    VS NUMBER // 0
;

unknown_command_link
:
    '357c6a54-357d-425d-a2bd-22f4f6e86c87'
    VS NUMBER // 0|2147483647
;

form_command_link
:
    '00000000-0000-0000-0000-000000000000'
    VS NUMBER // идентификатор команды формы
;

tabular_section_command_link
:
    '6b7291bf-bcd2-41af-bac7-414d47cc6e6a'
    VS NUMBER // идентификатор команды табличной части
;

form_command_collection_link
:
    'b78f2e80-ec68-11d4-9dcf-0050bae2bc79'
    VS NUMBER // 4 - форма | 55 - Действия (обработка)
;

tabular_section_command_collection_link
:
    '875faa24-ba4b-4731-9f11-7a7cea99ef16'
    VS NUMBER // 16 - История отборов (табличная часть обработки)
;
