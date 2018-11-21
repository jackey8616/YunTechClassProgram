include HT66F50.inc

	; Program: ADC control
	;     Using chip HT66F50, fsys=4MHz

ds	.section	'data'
	LED EQU PB
	LED_C EQU PBC
	STACK_PSW DB ?    ; Temporary variable store Register STATUS
	STACK_ACC DB ?	  ; Temporary varilabe store Register ACC

cs	.section	at  000h	'code'
	ORG 00h
	JMP INIT
	ORG 1Ch
	JMP ADC_ISR

INIT:
	MOV A, 008h       ; Close ADC
	MOV CP0C, A       ; Close ADC
	MOV CP1C, A       ; Close ADC
	
	CLR LED_C
	
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
	MOV A, ADRH
	MOV LED, A
	
	SET START
	CLR START
	CALL REVERSE	
	RETI

END