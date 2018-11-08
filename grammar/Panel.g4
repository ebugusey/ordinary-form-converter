grammar Panel;

import GUIDsLexer, V8InternalsLexer, FormElement, Checkbox, HTMLDocumentField, TextBox, Label, PictureBox, RadioButton, Splitter, SpreadsheetDocumentField;

mainPanel
:
    BLOCK_START
        PANEL_GUID
        VS panelValue
        VS panelChildElements
    BLOCK_END
;

panel
:
    BLOCK_START
        PANEL_GUID
        VS NUMBER // идентификатор элемента
        VS panelValue
        VS panelElementExtension
        VS formElementExtension
        VS panelChildElements
    BLOCK_END
;

panelValue
:
    BLOCK_START
        NUMBER // 1
        VS BLOCK_START
            decoration
            VS NUMBER // 25
            VS linkedElementList // к верхней границе
            VS linkedElementList // к нижней границе
            VS linkedElementList // к левой границе
            VS linkedElementList // к правой границе
            VS NUMBER VS NUMBER // 0,0
            VS pictureBlock // Картинка
            VS NUMBER // ОтображениеЗакладок
            VS NUMBER // РаспределятьПоСтраницам
            VS panelPageList
            VS NUMBER // АвтоПравила
            VS NUMBER // АвтоПорядокОбхода
            VS NUMBER // РежимПрокручиваемыхСтраниц
            VS alignmentLineList
            VS NUMBER // Исп. только видимую область
            // идентификатор элемента, для которого установлено свойство АктивизироватьПоУмолчанию,
            // для каждой страницы свой (4294967295 - не установлено)
            ( VS NUMBER )+
            VS NUMBER // ПоложениеКартинкиПанели
            VS NUMBER VS NUMBER // 64,0
            VS color // ЦветФона
            VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,57,0
        BLOCK_END
        VS events
    BLOCK_END
;

panelPageList
:
    BLOCK_START
        NUMBER // 1
        VS NUMBER // количество страниц
        ( VS panelPage )+
    BLOCK_END
;

panelPage
:
    BLOCK_START
        NUMBER // 4
        VS localizedString // Заголовок
        VS pictureBlock // КартинкаЗаголовка
        VS NUMBER // -1
        VS NUMBER // Видимость
        VS NUMBER // Доступность
        VS STRING // Имя
        VS NUMBER // Раскрыта
        VS color // пустой
        VS color // пустой
    BLOCK_END
;

alignmentLineList
:
    NUMBER
    VS alignmentLine
    VS alignmentLine
    VS alignmentLine
    VS alignmentLine
    ( VS alignmentLine )*
;
alignmentLine
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

panelChildElements
:
    BLOCK_START
        NUMBER
        ( VS panelChildElement )*
    BLOCK_END
;
panelChildElement
:
    panel
    | checkbox
    | htmlDocumentField
    | textBox
    | label
    | pictureBox
    | radioButton
    | splitter
    | spreadsheetDocumentField
;
