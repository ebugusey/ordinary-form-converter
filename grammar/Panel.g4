grammar Panel;

import GUIDsLexer, V8InternalsLexer, FormElement, InputField, Picture;

main_panel
:
    BLOCK_START
        PANEL_GUID
        VS panel_value
        VS panel_child_elements
    BLOCK_END
;

panel
:
    BLOCK_START
        PANEL_GUID
        VS NUMBER // идентификатор элемента
        VS panel_value
        VS panel_element_extension
        VS form_element_extension
        VS panel_child_elements
    BLOCK_END
;

panel_value
:
    BLOCK_START
        NUMBER // 1
        VS BLOCK_START
            decoration
            VS NUMBER // 25
            VS linked_element_list // к верхней границе
            VS linked_element_list // к нижней границе
            VS linked_element_list // к левой границе
            VS linked_element_list // к правой границе
            VS NUMBER VS NUMBER // 0,0
            VS picture_block // Картинка
            VS NUMBER // ОтображениеЗакладок
            VS NUMBER // РаспределятьПоСтраницам
            VS panel_page_list
            VS NUMBER // АвтоПравила
            VS NUMBER // АвтоПорядокОбхода
            VS NUMBER // РежимПрокручиваемыхСтраниц
            VS alignment_line_list
            VS NUMBER // Исп. только видимую область
            VS NUMBER // идентификатор элемента для которого установлено свойство АктивизироватьПоУмолчанию, для каждой страницы свой (4294967295 - свойство не установлено)
            VS NUMBER // ПоложениеКартинкиПанели
            VS NUMBER VS NUMBER // 64,0
            VS color // ЦветФона
            VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,57,0
        BLOCK_END
        VS events
    BLOCK_END
;

panel_page_list
:
    BLOCK_START
        NUMBER // 1
        VS NUMBER // количество страниц
        ( VS panel_page )+
    BLOCK_END
;

panel_page
:
    BLOCK_START
        NUMBER // 4
        VS localized_string // Заголовок
        VS picture_block // КартинкаЗаголовка
        VS NUMBER // -1
        VS NUMBER // Видимость
        VS NUMBER // Доступность
        VS STRING // Имя
        VS NUMBER // Раскрыта
        VS color // пустой
        VS color // пустой
    BLOCK_END
;

alignment_line_list
:
    NUMBER
    VS alignment_line
    VS alignment_line
    VS alignment_line
    VS alignment_line
    ( VS alignment_line )*
;
alignment_line
:
    BLOCK_START
        NUMBER // 2
        VS NUMBER // координата
        VS NUMBER // ориентация (0 - горизонтальная, 1 - вертикальная)
        VS NUMBER // 1
        VS NUMBER // краевая выравнивающая линия (0 - не краевая, 1 - левая, 2 - верхняя, 3 - правая, 4 - нижняя)
        VS NUMBER // индекс страницы (2147483647 - сквозная)
        VS NUMBER // 0
        VS NUMBER // координата относительно противоположной стороны (только для правой и нижней)
        VS NUMBER // 0
    BLOCK_END
;

panel_child_elements
:
    BLOCK_START
        NUMBER
        ( VS panel_child_element )*
    BLOCK_END
;
panel_child_element
:
    input_field
    | panel
;
