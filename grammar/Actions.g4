grammar Actions;

import V8InternalsLexer, Common, Picture;

custom_action
:
    'e1692cc2-605b-4535-84dd-28440238746c'
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
