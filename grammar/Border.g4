grammar Border;

import Common;

border
:
    BLOCK_START
        borderValue
        ( VS BORDER_GUID )?
    BLOCK_END
;

borderValue
:
    NUMBER // 3
    VS NUMBER // Вид
    VS BLOCK_START
        NUMBER
        ( VS GUID )?
    BLOCK_END
    VS NUMBER // ТипРамки
    VS NUMBER // Толщина
    VS NUMBER
;
