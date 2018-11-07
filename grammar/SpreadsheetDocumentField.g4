grammar SpreadsheetDocumentField;

import GUIDsLexer, V8InternalsLexer, Common, FormElement;

spreadsheet_document_field
:
    BLOCK_START
        SPREADSHEET_DOCUMENT_GUID
        VS NUMBER // идентификатор элемента
        VS spreadsheet_document_field_value
        VS panel_element_extension
        VS form_element_extension
        VS empty_list
    BLOCK_END
;

spreadsheet_document_field_value
:
    BLOCK_START
        NUMBER // 18
        VS NUMBER VS NUMBER // координаты левого верхнего угла
        VS NUMBER VS NUMBER // координаты правого нижнего угла
        VS NUMBER // 5
        VS NUMBER // 5
        VS NUMBER // 1
        VS NUMBER // (0|1) Доступность
        VS color
        VS border
        VS any_block
        VS NUMBER // (0|1) СохранятьПозицию
        VS NUMBER // (0|1) СохранятьПозициюФиксации
        VS BLOCK_START
            NUMBER // 3
            VS NUMBER VS NUMBER // 0..inf, зависит от СохранятьПозицию
            VS NUMBER // 100
            VS NUMBER // (0|1) ОтображатьСетку
            VS NUMBER // (0|1) ОтображатьЗаголовки
            VS NUMBER // 0
            VS NUMBER VS NUMBER // (0|1), (0|1) ОтображатьГруппы
            VS NUMBER // 0
            VS NUMBER // (0|1) ЧерноБелыйПросмотр
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER VS NUMBER // 0..inf, зависит от СохранятьПозицию
            VS NUMBER // 0
            VS NUMBER // 0
            VS STRING // "ru"
            VS NUMBER // 0
            VS NUMBER // 1
            VS BLOCK_START
                NUMBER // 3
                VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0..inf, зависит от СохранятьПозицию
                VS any_guid
            BLOCK_END
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
            VS NUMBER // 0
        BLOCK_END
        VS NUMBER // (0|1) ГоризонтальнаяПолосаПрокрутки?
        VS NUMBER // (0|1) ВертикальнаяПолосаПрокрутки?
        VS events
        VS NUMBER // (0|1) ТолькоПросмотр?
        VS NUMBER // (0|1) Защита
        VS NUMBER // (0|1) ТолькоПросмотр?
        VS NUMBER // (0|1) ОтображатьСетку
        VS NUMBER // (0|1) ОтображатьЗаголовки
        VS NUMBER // (0|1) ОтображатьГруппы
        VS NUMBER // (0|1) ЧерноБелыйПросмотр
        VS NUMBER // (0|1) РазрешитьНачалоПеретаскивания
        VS NUMBER // (0|1) РазрешитьПеретаскивание
        VS NUMBER // (0..1) ОтображатьВыделение
        VS NUMBER // (0..2) Вывод
        VS NUMBER // 0
        VS NUMBER // 0
        VS NUMBER // (0|1) ГоризонтальнаяПолосаПрокрутки?
        VS NUMBER // (0|1) ВертикальнаяПолосаПрокрутки?
    BLOCK_END
;
