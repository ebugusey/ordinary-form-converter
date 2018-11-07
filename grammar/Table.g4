grammar Table;

import V8InternalsLexer, TypeDescription, FormElement;

table
:
    BLOCK_START
        'ea83fe3a-ac3c-4cce-8045-3dddf35b28b1'
        VS NUMBER // идентификатор элемента
        VS table_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

table_value
:
    BLOCK_START
        NUMBER // 5
        VS type_description // ТипЗначения
        VS BLOCK_START
            decoration
            VS table_decoration_and_columns
        BLOCK_END
        VS
        (
            table_value_table_extension
            | table_tabular_section_extension
            | table_value_tree_extension
        )
        VS events
    BLOCK_END
;

table_decoration_and_columns
:
    BLOCK_START
        NUMBER // 18
        VS NUMBER // маска
        VS color // ЦветФонаШапки
        VS color // ЦветТекстаШапки
        VS color // ЦветФонаПодвала
        VS color // ЦветТекстаПодвала
        VS color // ЦветФонаВыделения
        VS color // ЦветТекстаВыделения
        VS color // ЦветФонаЧередованияСтрок
        VS NUMBER // ГоризонтальнаяПолосаПрокрутки
        VS NUMBER // ВертикальнаяПолосаПрокрутки
        VS NUMBER // ФиксацияСлева
        VS NUMBER // ФиксацияСправа
        VS NUMBER // РежимВводаСтрок
        VS NUMBER // РежимВыделенияСтроки
        VS NUMBER // РежимВыделения
        VS NUMBER // ВысотаШапки
        VS NUMBER // ВысотаПодвала
        VS font // ШрифтШапки
        VS font // ШрифтПодвала
        VS NUMBER // НачальноеОтображениеСписка
        VS NUMBER // 0
        VS NUMBER // ИзменятьСоставСтрок
        VS column_list
        VS NUMBER // Вывод
        VS NUMBER VS NUMBER VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,0,0,0,0
        VS NUMBER VS NUMBER VS NUMBER // 100,1,2
    BLOCK_END
;

table_value_table_extension
:
    BLOCK_START
        '342cf854-134c-42bb-8af9-a2103d5d9723'
        VS BLOCK_START
            NUMBER // 5
            VS NUMBER VS NUMBER // 0,0
            VS NUMBER // ИзменятьПорядокСтрок
        BLOCK_END
    BLOCK_END
;

table_tabular_section_extension
:
    BLOCK_START
        '51d1e122-c0f3-496f-901e-806df8206ba9'
        VS BLOCK_START
            NUMBER // 2
            VS NUMBER // ИзменятьПорядокСтрок
            VS BLOCK_START
                NUMBER // 0
                VS NUMBER // ПроверкаОтображенияНовойСтроки
            BLOCK_END
        BLOCK_END
    BLOCK_END
;

table_value_tree_extension
:
    BLOCK_START
        '9ab3fa70-d2e0-4e44-baac-730682272ed2'
        VS BLOCK_START
            NUMBER // 4
            VS NUMBER // Дерево
            VS NUMBER // ИзменятьПорядокСтрок
            VS events
        BLOCK_END
    BLOCK_END
;

column_list
:
    BLOCK_START
        NUMBER // количество колонок
        ( VS column )*
    BLOCK_END
;

column
:
    form_attribute_column
    | tabular_section_column
;

form_attribute_column
:
    BLOCK_START
        '737535a4-21e6-4971-8513-3e3173a9fedd'
        VS BLOCK_START
            NUMBER // 8
            VS column_value
        BLOCK_END
    BLOCK_END
;

tabular_section_column
:
    BLOCK_START
        'c2cf1953-2796-4fe2-b78c-ff84140b124e'
        VS BLOCK_START
            NUMBER // 1
            VS column_value
        BLOCK_END
    BLOCK_END
;

column_value
:
    BLOCK_START
        NUMBER // 8
        VS BLOCK_START
            NUMBER // 17
            VS localized_string // ТекстШапки
            VS localized_string // ТекстПодвала
            VS localized_string // ПодсказкаВШапке
            VS NUMBER // Ширина
            VS NUMBER // идентификатор колонки
            VS NUMBER // ? -2 - НомерСтроки, 0..? - колонки ТЧ, -1 - колонка ТЗ/ДЗ
            VS NUMBER VS NUMBER // -1,-1
            VS NUMBER // маска
            VS picture // КартинкаШапки
            VS picture // КартинкиСтрок
            VS picture // КартинкаПодвала
            VS NUMBER VS NUMBER // 16,16
            VS 'd2314b5d-8da4-4e0f-822b-45e7500eae09'
            VS color // ЦветФонаПоля
            VS color // ЦветТекстаПоля
            VS color // ЦветФонаШапки
            VS color // ЦветТекстаШапки
            VS color // ЦветФонаПодвала
            VS color // ЦветТекстаПодвала
            VS font // ШрифтТекста
            VS font // ШрифтШапки
            VS font // ШрифтПодвала
            VS NUMBER // РежимРедактирования
            VS NUMBER // Положение
            VS NUMBER // ГоризонтальноеПоложениеВШапке
            VS NUMBER // ГоризонтальноеПоложениеВКолонке
            VS NUMBER // ГоризонтальноеПоложениеВПодвале
            VS STRING // Имя
            VS empty_block
            VS NUMBER // Ширина / 7 и округлить в большую сторону до единиц
            VS NUMBER // ИзменениеРазмера
            VS localized_string // Формат
            VS type_description // ТипЗначения
            VS NUMBER // 0
            VS NUMBER // ВысотаЯчейки
            VS form_element_type_id
            ( VS column_control )?
            VS NUMBER VS NUMBER VS NUMBER // 0,0,0
        BLOCK_END
        VS tabular_section_data_source_block
    BLOCK_END
    VS
    (
        form_attribute_data_source_block
        | NUMBER // 0
    )
    VS NUMBER // ОтображатьИтогиВПодвале
;

tabular_section_data_source_block
:
    column_data_source // Данные
    VS column_data_source // ДанныеФлажка
    VS column_data_source // ДанныеКартинки, всегда -1, нельзя установить
;

column_data_source
:
    BLOCK_START
        NUMBER // -1 - не заполнено, 0 - реквизит, -2 - НомерСтроки
        ( VS GUID )? // uuid реквизита табличной части
    BLOCK_END
;

form_attribute_data_source_block
:
    STRING // Данные
    VS STRING // ДанныеФлажка
    VS STRING // ДанныеКартинки
;

form_element_type_id
:
    '381ed624-9217-4e63-85db-c4c3cb87daae' // поле ввода
    | '00000000-0000-0000-0000-000000000000' // нет элемента (например для стандартного реквизита НомерСтроки)
;

column_control
:
    BLOCK_START
        base64
        VS NUMBER // 0
    BLOCK_END
;
