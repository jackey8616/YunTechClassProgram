include HT66F50.inc

ds    .section    'data'

; Declartion of DELAY_1ms Procedure
DEL1    DB    ?    ; Nested loop declare y
DEL2    DB    ?    ; Nested loop declare x
; Declartion of DELAY_1s_WITH_1ms Procedure
DEL6    DB    ?    ; Nested loop declare y
DEL7    DB    ?    ; Nested loop declare x

COUNT   DB    ?    ; Table element count

cs    .section    at  000h    'code'

INIT:
    CLR PDC        ; Clear PDC for later output.

MAIN:
    ; Program: HW02 Shows StudentID
    ;    description:
    ;        Shows student id, and each number delay with 1S
    ;     Using chip HT66F50, fsys=4MHz
    MOV A, OFFSET TABLE       ; Get table's first element's memory address
    MOV TBLP, A               ;  and put into TBLP register as anchor point
    MOV A, 9                  ; We have nine element's, so count is nine
    MOV COUNT, A

LOOP:
    TABRDL PD                 ; Read Low Point address's data and put into PD Port as Output.
    CALL DELAY_1S_with_1mS    ; Delay 1S
    INC TBLP                  ; TBLP = TBLP + 1, move to next anchor point
    SDZ COUNT                 ; if not execute nine times
    JMP LOOP                  ;  than goto loop
    JMP MAIN                  ; else goto main and keep loop.
    
    ORG LASTPAGE              ; Declare table's data into memory's lastpage.
TABLE:
    ; This is Com-Anode 7-Seg
    DC    10000011B    ; b
    DC    11111001B    ; 1
    DC    11000000B    ; 0
    DC    10010010B    ; 5
    DC    11111001B    ; 1
    DC    11111000B    ; 7
    DC    11000000B    ; 0
    DC    10110000B    ; 3
    DC    11111001B    ; 1
    
; Delay Procedure detail:
;     https://github.com/jackey8616/YunTechClassProgram/blob/master/Assembly/Others/DelayProc.asm
DELAY_1S_with_1mS    PROC
    MOV A, 10
    MOV DEL7, A
    DELAY_1S_with_1mS_OUTTER:
        MOV A, 100
        MOV DEL6, A
        DELAY_1S_with_1mS_INNER:
            CALL DELAY_1mS
            SDZ DEL6
            JMP DELAY_1S_with_1mS_INNER
        SDZ DEL7
        JMP DELAY_1S_with_1mS_OUTTER
    RET
DELAY_1S_with_1mS    ENDP

DELAY_1mS    PROC
    MOV    A, 2
    MOV    DEL1, A
    DELAY_1ms_OUTTER:
        MOV    A, 165
        MOV DEL2, A
        DELAY_1ms_INNER:
            SDZ DEL2
            JMP DELAY_1ms_INNER
        SDZ DEL1
        JMP DELAY_1ms_OUTTER
    RET
DELAY_1mS    ENDP