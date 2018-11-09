grammar TextBox;

import TypeDescription, FormElement;

textBox
:
    BLOCK_START
        INPUT_FIELD_GUID
        VS NUMBER // идентификатор элемента
        VS textBoxValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

textBoxValue
:
    BLOCK_START
        NUMBER // 9
        VS typeDescription // ТипЗначения
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
                VS typedValue // Неопределено
                VS typedValue // Неопределено
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
                VS localizedString // Формат
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
        VS textBoxExtensionList
        VS events
        VS NUMBER // НЕ РедактированиеТекста
        VS NUMBER // ВыбиратьТип
        VS NUMBER // 0
        VS dataLink // связь по типу
        VS NUMBER // РежимВыбораИзСписка
    BLOCK_END
;

textBoxExtensionList
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS textBoxExtension )*
    BLOCK_END
;

textBoxExtension
:
    textBoxSimpleExtension
    | textBoxValueListExtension
    | textBoxCatalogRefExtension
    | textBoxCharTypeExtension
    | textBoxDocumentExtension
    | textBoxEnumExtension
    | textBoxMultiTypeExtension
;

textBoxSimpleExtension
:
    BLOCK_START
        SIMPLE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 4
            VS typedValue // МинимальноеЗначение
            VS typedValue // МаксимальноеЗначение
            VS NUMBER // МногострочныйРежим
            VS STRING // Маска
            VS NUMBER // РежимПароля
            VS NUMBER // РасширенноеРедактирование
        BLOCK_END
    BLOCK_END
;

textBoxValueListExtension
:
    BLOCK_START
        '83a29520-06e8-4348-989c-abe69e8e33e2'
        VS BLOCK_START
            NUMBER // 0
            VS typeDescription // ТипЗначенияСписка
        BLOCK_END
    BLOCK_END
;

textBoxCatalogRefExtension
:
    BLOCK_START
        CATALOGREF_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 5
            VS NUMBER // БыстрыйВыбор
            VS NUMBER // ВыборГруппИЭлементов
            VS EMPTY_GUID
            VS dataLink // связь по владельцу
        BLOCK_END
    BLOCK_END
;

textBoxCharTypeExtension
:
    BLOCK_START
        CHARTYPE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 0
            VS NUMBER // БыстрыйВыбор
            VS NUMBER // ВыборГруппИЭлементов
            VS EMPTY_GUID
            VS dataLink // связь по владельцу
        BLOCK_END
    BLOCK_END
;

textBoxDocumentExtension
:
    BLOCK_START
        DOCUMENT_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 3
            VS EMPTY_GUID
        BLOCK_END
    BLOCK_END
;

textBoxEnumExtension
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

textBoxMultiTypeExtension
:
    BLOCK_START
        MULTITYPE_EXTENSION_GUID
        VS BLOCK_START
            NUMBER // 0
        BLOCK_END
    BLOCK_END
;

dataLink
:
    BLOCK_START
        NUMBER // 1
        VS NUMBER // 0..1 количество элементов?
        ( VS dataLinkItem )?
    BLOCK_END
;
dataLinkItem
:
    BLOCK_START
        NUMBER // 0
        VS DATA_LINK_GUID
        VS dataPath
    BLOCK_END
;

dataPath
:
    attributeDataPath
    | columnDataPath
;

attributeDataPath
:
    BLOCK_START
        NUMBER // 2
        VS NUMBER // 1
        VS elementRef // идентификатор реквизита
    BLOCK_END
;

columnDataPath
:
    BLOCK_START
        NUMBER // 2
        VS NUMBER // 4
        VS elementRef // {-2}
        VS elementRef // идентификатор элемента формы
        VS elementRef // {0}
        VS elementRef // идентификатор колонки * 3
    BLOCK_END
;
