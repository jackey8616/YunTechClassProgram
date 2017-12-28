include HT66F50.inc

	; Program: External interrupt control two-seg-led counter.
	;     Using chip HT66F50, fsys=4MHz

ds	.section	'data'
	COUNT DB ?        ; Nested counter
	COUNT1 DB ?       ; Nested counter
	DIGIT_LOW DB ?
	DIGIT_HIGH DB ?
	COUNT_LOW DB ?
	COUNT_HIGH DB ?
	STACK_PSW DB ?    ; Temporary variable store Register STATUS
	STACK_ACC DB ?	  ; Temporary varilabe store Register ACC

cs	.section	at  000h	'code'
	ORG 00h
	JMP INIT
	ORG 04h
	JMP INT0_ISR
	ORG 14h           ; Timer2's Interupt Vector
	JMP TM0_ISR       ; Assign label.

INIT:
	CLR ACERL
	MOV A, 008h       ; Close ADC
	MOV CP0C, A       ; Close ADC
	MOV CP1C, A       ; Close ADC
	
	MOV A, 10
	MOV COUNT, A
	MOV A, 100
	MOV COUNT1, A
	MOV A, 11111100b
	MOV COUNT_LOW, A
	MOV A, 11111111b
	MOV COUNT_HIGH, A
	MOV A, 05D
	MOV DIGIT_LOW, A
	MOV A, 09D
	MOV DIGIT_HIGH, A
	
	MOV A, 00000010b
	MOV INTEG, A
	
	; TM0C0 Setup:
	;     T0PAU = 0        Counter Pause
	;     T0CK[2:0] = 000  fint = fsys / 4
	;     T0ON = 0         Counter Stop
	;     T0RP[2:0] = 000  Period = 1024 / fint HT66F20 Only
	MOV A, 00000000b
	MOV TM0C0, A
	; TM0C1 Setup:
	;     T0M[2:0] = 10    PWM mode
	;     T0IO[2:0] = 10   PWM Output
	;     T0OC = 1         PWM initial high
	;     T0POL = 1        PWM output pin(TP0_1 = PA.0) complement then output
	;     T0DPX = 0        T0RP control period, TM0A control duty
	;     T0CCLR = 0       When Register ACC match or overflow then keep count
	MOV A,11000001b
	MOV TM0C1, A
	
	MOV A, LOW 1000
	MOV TM0AL, A          ; Set TM0's ACC hight bit Register
	MOV A, HIGH 1000
	MOV TM0AH, A          ; Set TM0's ACC low bit Register
	
	SET INT0E
	SET T0AE     ; Enable T0AF (Flag T0AE)
	SET MF0E     ; Enable Multi-Function (Flag MF0E)
	SET EMI      ; Enable Master Interrupt
	SET T0ON     ; Timer 0 Start

MAIN:
	JMP$
	
PROTECTOR PROC
	MOV STACK_ACC, A  ; Store Register ACC to temp variable.
	MOV A, STATUS
	MOV STACK_PSW, A  ; Store Register STATUS to temp variable;
	RET
PROTECTOR ENDP

REVERSE PROC
	MOV A, STACK_PSW  ; Put back Register STATUS from temp variable.
	MOV STATUS, A
	MOV A, STACK_ACC  ; Put back Register ACC from temp varialble;
	RET
REVERSE ENDP

INT0_ISR:
	CALL PROTECTOR
	SZ T0ON
		JMP ENABLE_COUNT
	DISABLE_COUNT:
		CLR T0ON
	ENABLE_COUNT:
		SET T0ON
	CALL REVERSE

TM0_ISR:
	CALL PROTECTOR
	CLR T0AF          ; Clear Interrupt Flag T0AF, incase interrupt again.
	SDZ COUNT
		JMP TM0_ISR1
	SDZ COUNT1
		JMP TM0_ISR1
	
	MOV A, 10
	MOV COUNT, A
	MOV A, 100
	MOV COUNT1, A
	
	CALL COUNTER
	CALL OUTPUT_SEG
	
	TM0_ISR1:
		CALL REVERSE
		RETI
		
COUNTER PROC
	SZ C
		JMP HIGH_INC
	INC COUNT_LOW
	INC DIGIT_LOW
	RET
			
	HIGH_INC:
		MOV A, 11110111h
		MOV COUNT_LOW, A
		MOV A, 0
		MOV DIGIT_LOW, A
		
		SZ C
			JMP RESET_DIGITS
		INC COUNT_HIGH
		INC DIGIT_HIGH
		RET
			
	RESET_DIGITS:
		MOV A, 11110111h
		MOV COUNT_HIGH, A
		MOV A, 0
		MOV DIGIT_HIGH, A
	RET
COUNTER ENDP

OUTPUT_SEG PROC
	MOV A, COUNT_LOW
	MOV TBLP, A
	TABRDL PD
	MOV A, COUNT_HIGH
	MOV TBLP, A
	TABRDL PC
	RET
OUTPUT_SEG ENDP

ORG LASTPAGE
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
END