grammar InputField;

import GUIDsLexer, V8InternalsLexer, TypeDescription, FormElement, Picture;

input_field
:
    BLOCK_START
        INPUT_FIELD_GUID
        VS NUMBER // идентификатор элемента
        VS input_field_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

input_field_value
:
    BLOCK_START
        NUMBER // 9
        VS type_description // ТипЗначения
        VS BLOCK_START
            BLOCK_START
                decoration
                VS NUMBER // 30
                VS NUMBER // 0
                VS NUMBER // 0|2
                VS NUMBER // АвтоПереносСтрок
                VS NUMBER // 0|1
                VS NUMBER // КнопкаСпискаВыбора
                VS NUMBER // КнопкаВыбора
                VS NUMBER // КнопкаОчистки
                VS NUMBER // КнопкаРегулирования
                VS NUMBER // КнопкаОткрытия
                VS NUMBER // ФиксДробнаяЧасть
                VS NUMBER // НЕ РедактированиеТекста
                VS NUMBER // ТолькоПросмотр
                VS NUMBER // 0..255
                VS NUMBER // 0..inf
                VS NUMBER // 0..inf
                VS NUMBER // ГоризонтальноеПоложение
                VS NUMBER // ВертикальноеПоложение
                VS typed_value // Неопределено
                VS typed_value // Неопределено
                VS STRING // Маска
                VS NUMBER // 0
                VS NUMBER // 1
                VS NUMBER // 0
                VS NUMBER // 0
                VS NUMBER // 0|1
                VS NUMBER // ВыделятьОтрицательные
                VS picture // Картинка
                VS picture // КартинкаКнопкиВыбора
                VS NUMBER // 0
                VS NUMBER // ВысотаСпискаВыбора
                VS NUMBER // ШиринаСпискаВыбора
                VS shortcut // СочетаниеКлавиш
                VS localized_string // Формат
                VS NUMBER // АвтоОтметкаНезаполненного
                VS NUMBER // АвтоВыборНезаполненного
                VS NUMBER // РежимВыбораНезаполненного
                VS NUMBER // 0|1
                VS NUMBER // 0
                VS NUMBER // 0
                VS NUMBER // 0
                VS NUMBER // 16777215
                VS NUMBER // 1
            BLOCK_END
        BLOCK_END
        VS input_field_extension_list
        VS events
        VS NUMBER // НЕ РедактированиеТекста
        VS NUMBER // ВыбиратьТип
        VS NUMBER // 0
        VS data_link // связь по типу
        VS NUMBER // РежимВыбораИзСписка
    BLOCK_END
;

input_field_extension_list
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS input_field_extension )*
    BLOCK_END
;

input_field_extension
:
    input_field_simple_extension
    | input_field_catalogref_extension
    | input_field_chartype_extension
    | input_field_document_extension
    | input_field_enum_extension
    | input_field_multitype_extension
;

input_field_simple_extension
:
    BLOCK_START
        SIMPLE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 4
            VS typed_value // МинимальноеЗначение
            VS typed_value // МаксимальноеЗначение
            VS NUMBER // МногострочныйРежим
            VS STRING // Маска
            VS NUMBER // РежимПароля
            VS NUMBER // РасширенноеРедактирование
        BLOCK_END
    BLOCK_END
;

input_field_catalogref_extension
:
    BLOCK_START
        CATALOGREF_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 5
            VS NUMBER // БыстрыйВыбор
            VS NUMBER // ВыборГруппИЭлементов
            VS EMPTY_GUID
            VS data_link // связь по владельцу
        BLOCK_END
    BLOCK_END
;

input_field_chartype_extension
:
    BLOCK_START
        CHARTYPE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 0
            VS NUMBER // БыстрыйВыбор
            VS NUMBER // ВыборГруппИЭлементов
            VS EMPTY_GUID
            VS data_link // связь по владельцу
        BLOCK_END
    BLOCK_END
;

input_field_document_extension
:
    BLOCK_START
        DOCUMENT_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 3
            VS EMPTY_GUID
        BLOCK_END
    BLOCK_END
;

input_field_enum_extension
:
    BLOCK_START
        ENUM_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 1
            VS NUMBER // БыстрыйВыбор
            VS EMPTY_GUID
        BLOCK_END
    BLOCK_END
;

input_field_multitype_extension
:
    BLOCK_START
        MULTITYPE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 0
        BLOCK_END
    BLOCK_END
;

data_link
:
    BLOCK_START
        NUMBER // 1
        VS NUMBER // 0..1 количество элементов?
        ( VS data_link_item )?
    BLOCK_END
;
data_link_item
:
    BLOCK_START
        NUMBER // 0
        VS DATA_LINK_GUID
        VS data_path
    BLOCK_END
;

data_path
:
    attribute_data_path
    | column_data_path
;

attribute_data_path
:
    BLOCK_START
        NUMBER // 2
        VS NUMBER // 1
        VS element_ref // идентификатор реквизита
    BLOCK_END
;

column_data_path
:
    BLOCK_START
        NUMBER // 2
        VS NUMBER // 4
        VS element_ref // {-2}
        VS element_ref // идентификатор элемента формы
        VS element_ref // {0}
        VS element_ref // идентификатор колонки * 3
    BLOCK_END
;
