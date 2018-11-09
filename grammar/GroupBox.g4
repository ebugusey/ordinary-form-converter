grammar GroupBox;

import FormElement;

start: groupBox EOF ;

groupBox
:
    BLOCK_START
        GROUP_BOX_GUID
        VS NUMBER // идентификатор элемента
        VS groupBoxValue
        VS panelElementExtension
        VS formElementExtension
        VS emptyList
    BLOCK_END
;

groupBoxValue
:
    BLOCK_START
        NUMBER // 0
        VS BLOCK_START
            decoration
            VS NUMBER // 8
            VS localizedString // Заголовок
            VS groupBoxBorder // Рамка
            VS NUMBER // 0
        BLOCK_END
    BLOCK_END
;

groupBoxBorder
:
    BLOCK_START
        borderValue
        ( VS GROUP_BOX_BORDER_GUID )?
    BLOCK_END
;
