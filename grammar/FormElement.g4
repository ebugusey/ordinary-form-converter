grammar FormElement;

import Common, Picture, Font, Actions;

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
        VS localizedString // Подсказка
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
        VS customAction
    BLOCK_END
;

formElementExtension
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

panelElementExtension
:
    BLOCK_START
        NUMBER // 8
        VS NUMBER VS NUMBER // координаты левого верхнего угла
        VS NUMBER VS NUMBER // координаты правого нижнего угла
        VS NUMBER // Видимость
        VS elementLink // верхняя граница
        VS elementLink // нижняя граница
        VS elementLink // левая граница
        VS elementLink // правая граница
        VS elementLink // пустая
        VS elementLink // пустая
        VS linkedElementList // к верхней границе
        VS linkedElementList // к нижней границе
        VS linkedElementList // к левой границе
        VS linkedElementList // к правой границе
        VS NUMBER VS NUMBER VS NUMBER VS NUMBER // 0,0,0,0
        VS NUMBER // ПорядокОбхода
        VS NUMBER // установлена ручная горизонтальная привязка
        VS NUMBER // установлена ручная вертикальная привязка
    BLOCK_END
;

elementLink
:
    BLOCK_START
        NUMBER // 0
        VS elementLinkItem // Привязать к
        VS elementLinkItem // Сохранять пропорции до
    BLOCK_END
;
elementLinkItem
:
    BLOCK_START
        NUMBER // 2
        VS NUMBER // идентификатор элемента (-1 - не привязано, 0 - форма)
        VS NUMBER // граница (0 - Верхняя, 1 - Нижняя, 2 - Левая, 4 - Центр (по вертикали), 5 - Центр (по горизонтали))
        VS NUMBER // расстояние относительно другого элемента
    BLOCK_END
;

linkedElementList
:
    NUMBER // количество элементов
    ( VS linkedElement )*
;
linkedElement
:
    BLOCK_START
        NUMBER // 0
        VS NUMBER // идентификатор элемента
        VS NUMBER // граница (0 - Верхняя, 1 - Нижняя, 2 - Левая, 3 - Правая)
    BLOCK_END
;

elementRef
:
    BLOCK_START
        NUMBER // идентификатор элемента или реквизита
    BLOCK_END
;
