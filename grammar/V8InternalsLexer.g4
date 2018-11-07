lexer grammar V8InternalsLexer;

BASE64: '#base64:' BASE64_CHAR+ ;

NUMBER: MINUS? INT FRAC? EXP? ;
STRING: QUOTE_CHAR CHAR* QUOTE_CHAR ;

// EMPTY_GUID: '00000000-0000-0000-0000-000000000000' -> type(GUID) ;
GUID
:
	HEXTET HEXTET '-'
	HEXTET '-'
	HEXTET '-'
	HEXTET '-'
	HEXTET HEXTET HEXTET
;

BLOCK_START: '{' ;
BLOCK_END: '}' ;

VS: ',' ;

WS: [ \t\r\n] -> skip ;

// Не должно быть чисел начинающихся с нуля.
fragment INT: ZERO | DIGIT1_9 DIGIT* ;

fragment FRAC: DOT DIGIT+ ;
fragment EXP: E DIGIT+ ;

fragment ZERO: '0' ;
fragment DIGIT: [0-9] ;
fragment DIGIT1_9: [1-9] ;
fragment HEX: [0-9a-f] ;

fragment HEXTET: HEX HEX HEX HEX ;

fragment MINUS: '-' ;

fragment E: 'e' ;
fragment DOT: '.' ;

fragment QUOTE_CHAR: '"' ;
fragment CHAR: UNESCAPED | ESCAPE_SEQ ;

fragment ESCAPE_SEQ: QUOTE_CHAR QUOTE_CHAR ;
fragment UNESCAPED: ~'"' ;

fragment BASE64_CHAR: [A-Za-z0-9+/=] ;
