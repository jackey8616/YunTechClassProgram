include HT66F50.inc

	; Program: Analog input as PWM output to LED
	;     Using chip HT66F50, fsys=4MHz

ds	.section	'data'
	COUNT DB ?        ; Nested counter
	COUNT1 DB ?       ; Nested counter
	ANALOG DB ?
	STACK_PSW DB ?    ; Temporary variable store Register STATUS
	STACK_ACC DB ?	  ; Temporary varilabe store Register ACC

cs	.section	at  000h	'code'
	ORG 00h
	JMP INIT
	ORG 1Ch
	JMP ADC_ISR

INIT:
	CLR ACERL
	SET ACERL.1
	MOV A, 008h       ; Close ADC
	MOV CP0C, A       ; Close ADC
	MOV CP1C, A       ; Close ADC
	
	MOV A, 00000001b
	MOV ADCR0, A
	
	MOV A, 00000010b
	MOV ADCR1, A
	
	MOV A, 00000010b
	MOV ACERL, A
	
	SET ADE
	SET EMI
	
	SET START
	CLR START
	
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
	MOV A,10101100b
	MOV TM0C1, A
	
	MOV A, LOW 200
	MOV TM0AL, A          ; Set TM0's ACC hight bit Register
	MOV A, HIGH 200
	MOV TM0AH, A          ; Set TM0's ACC low bit Register
	
	; TMPC0 Setup:
	;     T1ACP0 = 0
	;     T1BCP2 = 0
	;     T1BCP1 = 0  Not use any other TM output pin, set to 0
	;     T1BCP0 = 0
	;        -  not define
	;        -  not define
	;     T0CP1  = 0
	;     T0CP0  = 1  Set TP0_0(PA.0) as PWM output
	MOV A, 00000001b
	MOV TMPC0, A
	
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

	
ADC_ISR:
	CALL PROTECTOR
	
	MOV A, ADRL
	MOV TM0AL, A
	MOV A, ADRH
	MOV TM0AH, A
	
	SET START
	CLR START
	CALL REVERSE	
	RETI

END