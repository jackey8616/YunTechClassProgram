include HT66F50.inc

ds    .section    'data'

; Declartion of DELAY_1ms Procedure
DEL1    DB    ?    ; Nested loop declare y
DEL2    DB    ?    ; Nested loop declare x
; Declartion of DELAY_1s Procedure
DEL3    DB    ?    ; Nested loop declare z
DEL4    DB    ?    ; Nested loop declare y
DEL5    DB    ?    ; Nested loop declare x
; Declartion of DELAY_1S_WITH_1mS Procedure
DEL6    DB    ?    ; Nested loop declare y
DEL7    DB    ?    ; Nested loop declare x

cs    .section    at  000h    'code'

MAIN:
    ; Program: Delay Procedure(1mS/1S).
    ;     Using chip HT66F50, fsys=4MHz
    ;     1 fec(fetch-and-execute-cycle) is 1 us    
    CALL DELAY_1mS
    CALL DELAY_1S
    CALL DELAY_1S_with_1mS
    JMP $

DELAY_1S_with_1mS    PROC
    ; This procedure contains two-layer nedted loop,
    ; execute 10 * 100 = 1000 times delay 1ms procedure = delay 1s
    MOV A, 10
    MOV DEL7, A                             ; Set outter factor for mutiple to 10
    DELAY_1S_with_1mS_OUTTER:
        MOV A, 100
        MOV DEL6, A                         ; Set inner factor for mutiple to 100
        DELAY_1S_with_1mS_INNER:
            CALL DELAY_1mS                  ; Call Delay 1ms
            SDZ DEL6                        ; If inner factor is not zero
            JMP DELAY_1S_with_1mS_INNER     ;    than back to inner loop
        SDZ DEL7                            ; If outter factor is not zero
        JMP DELAY_1S_with_1mS_OUTTER        ;     than back to outter loop
    RET
DELAY_1S_with_1mS    ENDP

DELAY_1S    PROC
    ; This procedure contains three nested loop,
    ; Also a dirty way to delay 1S.
    MOV A, 255
    MOV    DEL3, A    
    DELAY_1s_OUTTER:
        MOV A, 127
        MOV DEL4, A
        DELAY_1s_INNER:
            MOV A, 9
            MOV DEL5, A
            DELAY_1s_INNER2:
                SDZ DEL5
                JMP DELAY_1s_INNER2
            SDZ    DEL4
            JMP DELAY_1S_INNER
        SDZ    DEL3
        JMP    DELAY_1s_OUTTER
    RET
DELAY_1S    ENDP

DELAY_1mS    PROC
    ; this procedure contains a nested loop,
    ; count of each instruction base on value of x and y
    MOV    A, 2                     ; execute 1 fec
    ; MOV A, y
    MOV    DEL1, A                  ; execute 1 fec
    DELAY_1ms_OUTTER:
        MOV    A, 165               ; execute y fec
        ; MOV A, x
        MOV DEL2, A                 ; execute y fec
        DELAY_1ms_INNER:            ; execute (3x-1) * y fec
            SDZ DEL2                ;     execute 1*(x-1) + 2 fec
                                    ;       SDZ is a two-stage pipeline instruction cost one fec.
                                    ;       in normal situation it only execute decrease and if statement, cost one fec.
                                    ;       but once it match zero, it will cost two fec due to skipping instruction.
            JMP DELAY_1ms_INNER     ;     execute 2*(x-1) fec
        SDZ DEL1                    ; execute 1*(y-1) + 2 fec
        JMP DELAY_1ms_OUTTER        ; execute 2*(y-1) fec
    RET                             ; execute 2 fec
                                    ; Total: 1 + 1 + y + y + 3xy - y + y - 1 + 2 + 2y- 2
                                    ;        = 3xy + 4y + 1
                                    ; After calcaulation, if y = 2, x = 165 is close to 1000 which is 994 instructions.
DELAY_1mS    ENDP

    ; RET & SZ(SKIP) & JMP instruction cost 2 fec,
    ; because it will pop PC from stack and set to PC register
    ; so it cost 2 fec.