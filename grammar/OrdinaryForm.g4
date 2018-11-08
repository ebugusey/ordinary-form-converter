grammar OrdinaryForm;

import V8InternalsLexer, TypeDescription, Common, FormElement, Panel;

start: ordinaryForm EOF ;

ordinaryForm
:
    BLOCK_START
        NUMBER // 27
        VS BLOCK_START
            NUMBER // 18
            VS ordinaryFormHeader
            VS mainPanel
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
        VS ordinaryFormAttributes
        VS formExtension
        VS events
        VS NUMBER // АвтоЗаголовок
        VS NUMBER // СостояниеОкна
        VS NUMBER // ПоложениеПрикрепленногоОкна
        VS NUMBER // СоединяемоеОкно
        VS NUMBER // ПоложениеОкна
        VS NUMBER // ИзменениеРазмера
        VS contextMenuList
        VS style
        VS pictureBlock
        VS NUMBER // СпособОтображенияОкна
        VS NUMBER // ИзменятьСпособОтображенияОкна
        VS NUMBER // ПоложениеОкна
        VS NUMBER // РежимРабочегоСтола
        VS NUMBER // РазрешитьЗакрытие
        VS NUMBER // ПроверятьЗаполнениеАвтоматически
    BLOCK_END
;

ordinaryFormHeader
:
    BLOCK_START
        localizedString // Заголовок
        VS NUMBER // свободный идентификатор элемента
        VS NUMBER // идентификатор элемента, для которого установлено свойство КнопкаПоУмолчанию (4294967295 - не установлено)
    BLOCK_END
;

ordinaryFormAttributes
:
    BLOCK_START
        elementRef // идентификатор основного реквизита формы
        VS NUMBER // свободный идентификатор реквизита
        VS attributeList
        VS attributeLinkList
    BLOCK_END
;

attributeList
:
    BLOCK_START
        NUMBER // количество реквизитов
        ( VS attribute )*
    BLOCK_END
;
attribute
:
    BLOCK_START
        elementRef // идентификатор
        VS NUMBER // связан с элементом
        VS NUMBER // проверка заполнения
        VS NUMBER // 1
        VS STRING // имя реквизита
        VS typeDescription // тип реквизита
    BLOCK_END
;

attributeLinkList
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS attributeLink )*
    BLOCK_END
;
attributeLink
:
    BLOCK_START
        NUMBER // идентификатор элемента формы
        VS BLOCK_START
            NUMBER // 1 - реквизит формы, 2 - реквизит реквизита
            VS elementRef // идентификатор реквизита формы
            (
                VS BLOCK_START
                    NUMBER // 0
                    VS GUID // uuid реквизита реквизита формы (например uuid табличной части)
                BLOCK_END
            )?
        BLOCK_END
    BLOCK_END
;

formExtension
:
    noMainAttributeFormExtension
    | externalDataProcessorExtension
;

noMainAttributeFormExtension
:
    BLOCK_START
        '00000000-0000-0000-0000-000000000000'
        VS NUMBER // 0
    BLOCK_END
;

externalDataProcessorExtension
:
    BLOCK_START
        '59d6c227-97d3-46f6-84a0-584c5a2807e1'
        VS NUMBER // 1
        VS BLOCK_START
            NUMBER // 2
            VS NUMBER // сохранять значения реквизитов
            VS savedValueList
            VS events
            VS NUMBER // ВосстанавливатьЗначенияПриОткрытии
        BLOCK_END
    BLOCK_END
;

savedValueList
:
    BLOCK_START
        NUMBER // 0
        VS NUMBER // количество значений
        ( VS savedValue )*
    BLOCK_END
;
savedValue
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
            ( VS elementRef )? // идентификатор реквизита (только для реквизитов формы)
        BLOCK_END
    BLOCK_END
;

contextMenuList
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS contextMenuLink )*
    BLOCK_END
;
contextMenuLink
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
