grammar OrdinaryForm;

import V8InternalsLexer, TypeDescription, Common, FormElement, Panel;

start: ordinary_form EOF ;

ordinary_form
:
    BLOCK_START
        NUMBER // 27
        VS BLOCK_START
            NUMBER // 18
            VS ordinary_form_header
            VS main_panel
            VS NUMBER // Ширина
            VS NUMBER // Высота
            VS NUMBER // ПоведениеКлавишиEnter
            VS NUMBER // ИспользоватьСетку
            VS NUMBER // ИспользоватьВыравнивающиеЛинии
            VS NUMBER // ГоризонтальныйШагСетки
            VS NUMBER // ВертикальныйШагСетки
            VS NUMBER // ревизия формы
            VS NUMBER // Ширина
            VS NUMBER // Высота
            VS NUMBER // 96
        BLOCK_END
        VS ordinary_form_attributes
        VS form_extension
        VS events
        VS NUMBER // АвтоЗаголовок
        VS NUMBER // СостояниеОкна
        VS NUMBER // ПоложениеПрикрепленногоОкна
        VS NUMBER // СоединяемоеОкно
        VS NUMBER // ПоложениеОкна
        VS NUMBER // ИзменениеРазмера
        VS context_menu_list
        VS style
        VS picture_block
        VS NUMBER // СпособОтображенияОкна
        VS NUMBER // ИзменятьСпособОтображенияОкна
        VS NUMBER // ПоложениеОкна
        VS NUMBER // РежимРабочегоСтола
        VS NUMBER // РазрешитьЗакрытие
        VS NUMBER // ПроверятьЗаполнениеАвтоматически
    BLOCK_END
;

ordinary_form_header
:
    BLOCK_START
        localized_string // Заголовок
        VS NUMBER // свободный идентификатор элемента
        VS NUMBER // идентификатор элемента, для которого установлено свойство КнопкаПоУмолчанию (4294967295 - не установлено)
    BLOCK_END
;

ordinary_form_attributes
:
    BLOCK_START
        element_ref // идентификатор основного реквизита формы
        VS NUMBER // свободный идентификатор реквизита
        VS attribute_list
        VS attribute_link_list
    BLOCK_END
;

attribute_list
:
    BLOCK_START
        NUMBER // количество реквизитов
        ( VS attribute )*
    BLOCK_END
;
attribute
:
    BLOCK_START
        element_ref // идентификатор
        VS NUMBER // связан с элементом
        VS NUMBER // проверка заполнения
        VS NUMBER // 1
        VS STRING // имя реквизита
        VS type_description // тип реквизита
    BLOCK_END
;

attribute_link_list
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS attribute_link )*
    BLOCK_END
;
attribute_link
:
    BLOCK_START
        NUMBER // идентификатор элемента формы
        VS BLOCK_START
            NUMBER // 1 - реквизит формы, 2 - реквизит реквизита
            VS element_ref // идентификатор реквизита формы
            (
                VS BLOCK_START
                    NUMBER // 0
                    VS GUID // uuid реквизита реквизита формы (например uuid табличной части)
                BLOCK_END
            )?
        BLOCK_END
    BLOCK_END
;

form_extension
:
    no_main_attribute_form_extension
    | external_data_processor_extension
;

no_main_attribute_form_extension
:
    BLOCK_START
        '00000000-0000-0000-0000-000000000000'
        VS NUMBER // 0
    BLOCK_END
;

external_data_processor_extension
:
    BLOCK_START
        '59d6c227-97d3-46f6-84a0-584c5a2807e1'
        VS NUMBER // 1
        VS BLOCK_START
            NUMBER // 2
            VS NUMBER // сохранять значения реквизитов
            VS saved_value_list
            VS events
            VS NUMBER // ВосстанавливатьЗначенияПриОткрытии
        BLOCK_END
    BLOCK_END
;

saved_value_list
:
    BLOCK_START
        NUMBER // 0
        VS NUMBER // количество значений
        ( VS saved_value )*
    BLOCK_END
;
saved_value
:
    BLOCK_START
        STRING // #
        VS '91f722a0-4cc1-11d6-a3c9-0050bae0a776'
        VS BLOCK_START
            NUMBER // 3
            // uuid реквизита или объекта, если сохраняется реквизит формы,
            // для внешней обработки это
            // /MetaDataObject/ExternalDataProcessor/InternalInfo/xr:ObjectId
            VS GUID
            VS STRING // имя реквизита
            VS NUMBER // это реквизит формы
            ( VS element_ref )? // идентификатор реквизита (только для реквизитов формы)
        BLOCK_END
    BLOCK_END
;

context_menu_list
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS context_menu_link )*
    BLOCK_END
;
context_menu_link
:
    NUMBER // идентификатор элемента формы (0 - форма)
    VS NUMBER // 4294967295
    VS '357c6a54-357d-425d-a2bd-22f4f6e86c87' //
    VS NUMBER // 2147483647
    VS NUMBER // 0
;

style
:
    BLOCK_START
        NUMBER // 0
        ( VS GUID )? // uuid стиля, если стиль указан
    BLOCK_END
;
