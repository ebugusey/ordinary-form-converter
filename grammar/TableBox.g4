grammar TableBox;

import TypeDescription, FormElement;

tableBox
:
    BLOCK_START
        TABLE_BOX_GUID
        VS NUMBER // идентификатор элемента
        VS tableBoxValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

tableBoxValue
:
    BLOCK_START
        NUMBER // 5
        VS typeDescription // ТипЗначения
        VS BLOCK_START
            decoration
            VS tableBoxDecorationAndColumns
        BLOCK_END
        VS
        (
            tableBoxValueTableExtension
            | tableBoxTabularSectionExtension
            | tableBoxValueTreeExtension
        )
        VS events
    BLOCK_END
;

tableBoxDecorationAndColumns
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
        VS columnList
        VS NUMBER // Вывод
        VS NUMBER VS NUMBER VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,0,0,0,0
        VS NUMBER VS NUMBER VS NUMBER // 100,1,2
    BLOCK_END
;

tableBoxValueTableExtension
:
    BLOCK_START
        TABLE_BOX_VALUE_TABLE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 5
            VS NUMBER VS NUMBER // 0,0
            VS NUMBER // ИзменятьПорядокСтрок
        BLOCK_END
    BLOCK_END
;

tableBoxTabularSectionExtension
:
    BLOCK_START
        TABLE_BOX_TABULAR_SECTION_EXTENSION_GUID
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

tableBoxValueTreeExtension
:
    BLOCK_START
        TABLE_BOX_VALUE_TREE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 4
            VS NUMBER // Дерево
            VS NUMBER // ИзменятьПорядокСтрок
            VS events
        BLOCK_END
    BLOCK_END
;

columnList
:
    BLOCK_START
        NUMBER // количество колонок
        ( VS column )*
    BLOCK_END
;

column
:
    formAttributeColumn
    | tabularSectionColumn
;

formAttributeColumn
:
    BLOCK_START
        TABLE_BOX_FORM_ATTRIBUTE_COLUMN_GUID
        VS BLOCK_START
            NUMBER // 8
            VS columnValue
        BLOCK_END
    BLOCK_END
;

tabularSectionColumn
:
    BLOCK_START
        TABLE_BOX_TABULAR_SECTION_COLUMN_GUID
        VS BLOCK_START
            NUMBER // 1
            VS columnValue
        BLOCK_END
    BLOCK_END
;

columnValue
:
    BLOCK_START
        NUMBER // 8
        VS BLOCK_START
            NUMBER // 17
            VS localizedString // ТекстШапки
            VS localizedString // ТекстПодвала
            VS localizedString // ПодсказкаВШапке
            VS NUMBER // Ширина
            VS NUMBER // идентификатор колонки
            VS NUMBER // ? -2 - НомерСтроки, 0..? - колонки ТЧ, -1 - колонка ТЗ/ДЗ
            VS NUMBER VS NUMBER // -1,-1
            VS NUMBER // маска
            VS picture // КартинкаШапки
            VS picture // КартинкиСтрок
            VS picture // КартинкаПодвала
            VS NUMBER VS NUMBER // 16,16
            VS TABLE_BOX_COLUMN_VALUE_GUID
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
            VS emptyBlock
            VS NUMBER // Ширина / 7 и округлить в большую сторону до единиц
            VS NUMBER // ИзменениеРазмера
            VS localizedString // Формат
            VS typeDescription // ТипЗначения
            VS NUMBER // 0
            VS NUMBER // ВысотаЯчейки
            VS formElementTypeId
            ( VS columnControl )?
            VS NUMBER VS NUMBER VS NUMBER // 0,0,0
        BLOCK_END
        VS tabularSectionDataSourceBlock
    BLOCK_END
    VS
    (
        formAttributeDataSourceBlock
        | NUMBER // 0
    )
    VS NUMBER // ОтображатьИтогиВПодвале
;

tabularSectionDataSourceBlock
:
    columnDataSource // Данные
    VS columnDataSource // ДанныеФлажка
    VS columnDataSource // ДанныеКартинки, всегда -1, нельзя установить
;

columnDataSource
:
    BLOCK_START
        NUMBER // -1 - не заполнено, 0 - реквизит, -2 - НомерСтроки
        ( VS GUID )? // uuid реквизита табличной части
    BLOCK_END
;

formAttributeDataSourceBlock
:
    STRING // Данные
    VS STRING // ДанныеФлажка
    VS STRING // ДанныеКартинки
;

formElementTypeId
:
    INPUT_FIELD_GUID // поле ввода
    | EMPTY_GUID // нет элемента (например для стандартного реквизита НомерСтроки)
;

columnControl
:
    BLOCK_START
        base64
        VS NUMBER // 0
    BLOCK_END
;
