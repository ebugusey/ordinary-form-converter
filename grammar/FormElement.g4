grammar FormElement;

import GUIDsLexer, V8InternalsLexer, Common, Picture, Font;

decoration
:
    BLOCK_START
        NUMBER // 15
        VS NUMBER // Доступность
        VS color // ЦветФона
        VS color // ЦветТекста
        VS font // Шрифт
        VS NUMBER // ПрозрачныйФон
        VS color // ЦветРамки
        VS color // ЦветФонаПоля
        VS color // ЦветТекстаПоля
        VS color // ЦветФонаКнопки
        VS color // ЦветТекстаКнопки
        VS border // Рамка
        VS localized_string // Подсказка
        VS NUMBER VS NUMBER VS NUMBER // 0,0,100
        VS NUMBER // ? 0 - панель, 0 - кнопка, 1 - поле ввода, 2 - табличное поле
    BLOCK_END
;

events
:
    BLOCK_START
        NUMBER // количество элементов
        ( VS event )*
    BLOCK_END
;
event
:
    BLOCK_START
        NUMBER // идентификатор события
        VS custom_action
    BLOCK_END
;

custom_action
:
    CUSTOM_ACTION_GUID
    VS BLOCK_START
        NUMBER // 3
        VS STRING // имя обработчика
        VS BLOCK_START
            NUMBER // 1
            VS STRING // имя обработчика
            VS localized_string
            VS localized_string
            VS localized_string
            VS picture
            VS shortcut
        BLOCK_END
    BLOCK_END
;

form_element_extension
:
    BLOCK_START
        NUMBER // 14
        VS STRING // Имя
        VS NUMBER // ИсточникДействий
        VS NUMBER // ИзменяетДанные
        VS NUMBER // ПропускатьПриВводе
        VS NUMBER // ПервыйВГруппе
    BLOCK_END
;

panel_element_extension
:
    BLOCK_START
        NUMBER // 8
        VS NUMBER VS NUMBER // координаты левого верхнего угла
        VS NUMBER VS NUMBER // координаты правого нижнего угла
        VS NUMBER // Видимость
        VS element_link // верхняя граница
        VS element_link // нижняя граница
        VS element_link // левая граница
        VS element_link // правая граница
        VS element_link // пустая
        VS element_link // пустая
        VS linked_element_list // к верхней границе
        VS linked_element_list // к нижней границе
        VS linked_element_list // к левой границе
        VS linked_element_list // к правой границе
        VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,0,0
        VS NUMBER // ПорядокОбхода
        VS NUMBER // установлена ручная горизонтальная привязка
        VS NUMBER // установлена ручная вертикальная привязка
    BLOCK_END
;

element_link
:
    BLOCK_START
        NUMBER // 0
        VS element_link_item // Привязать к
        VS element_link_item // Сохранять пропорции до
    BLOCK_END
;
element_link_item
:
    BLOCK_START
        NUMBER // 2
        VS NUMBER // идентификатор элемента (-1 - не привязано, 0 - форма)
        VS NUMBER // граница (0 - Верхняя, 1 - Нижняя, 2 - Левая, 4 - Центр (по вертикали), 5 - Центр (по горизонтали))
        VS NUMBER // расстояние относительно другого элемента
    BLOCK_END
;

linked_element_list
:
    NUMBER // количество элементов
    ( VS linked_element )*
;
linked_element
:
    BLOCK_START
        NUMBER // 0
        VS NUMBER // идентификатор элемента
        VS NUMBER // граница (0 - Верхняя, 1 - Нижняя, 2 - Левая, 3 - Правая)
    BLOCK_END
;

element_ref
:
    BLOCK_START
        NUMBER // идентификатор элемента или реквизита
    BLOCK_END
;
