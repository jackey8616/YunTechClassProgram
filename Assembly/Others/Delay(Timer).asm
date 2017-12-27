include HT66F50.inc

	; Program: Delay with Timer control LED ON/OFF in 0.5s
	;     Using chip HT66F50, fsys=4MHz, TM0(10 bit CTM)

ds	.section	'data'
	LED EQU PC        ; PC reference
	LED_C EQU PCC     ; PCC reference
	COUNT DB ?        ; Nested counter
	COUNT1 DB ?       ; Nested counter
	STACK_PSW DB ?    ; Temporary variable store Register STATUS
	STACK_ACC DB ?	  ; Temporary varilabe store Register ACC

cs	.section	at  000h	'code'
	ORG 00h
	JMP INIT
	ORG 14h           ; Timer0's Interupt Vector
	JMP TM0_ISR       ; Assign label.

INIT:
	CLR ACERL         ; Close Comparators
	MOV A, 008h       ; Close ADC
	MOV CP0C, A       ; Close ADC
	MOV CP1C, A       ; Close ADC
	
	CLR LED
	CLR LED_C
	MOV A, 5
	MOV COUNT, A
	MOV A, 4
	MOV COUNT1, A
	
	; TM0C0 Setup:
	;     T0PAU = 0        Counter Pause
	;     T0CK[2:0] = 000  fint = fsys / 4
	;     T0ON = 0         Counter Stop
	;     T0RP[2:0] = 000  Period = 1024 / fint HT66F20 Only
	MOV A, 00000000b
	MOV TM0C0, A
	; TM0C1 Setup:
	;     TM0[2:0] = 11    Timer/Counter mode
	;     T0IO[2:0] = 00   In timer/counter mode, no function
	;     T0OC = 0         TP0_0 and TP0_1's output control bit. not use
	;     T0POL = 0        TP0_0 and TP0_1's polarity control bit. not use
	;     T0DPX = 0        In time/counter mode, no function
	;     T0CCLR = 1       When Register ACC match then clear counter.
	MOV A,11000001b
	MOV TM0C1, A
	
	MOV A, LOW 1000
	MOV TM0AL, A          ; Set TM0's ACC hight bit Register
	MOV A, HIGH 1000
	MOV TM0AH, A          ; Set TM0's ACC low bit Register
	
	SET T0AE     ; Enable T0AF (Flag T0AE)
	SET MF0E     ; Enable Multi-Function (Flag MF0E)
	SET EMI      ; Enable Master Interrupt
	SET T0ON     ; Timer 0 Start
	
	JMP$
	
TM0_ISR:
	MOV STACK_ACC, A  ; Store Register ACC to temp variable.
	MOV A, STATUS
	MOV STACK_PSW, A  ; Store Register STATUS to temp variable;
	
	CLR T0AF          ; Clear Interrupt Flag T0AF, incase interrupt again.
	SDZ COUNT
		JMP TM0_ISR1
	SDZ COUNT1
		JMP TM0_ISR1
	CPL LED           ; Complement LED Output
	MOV A, 5
	MOV COUNT, A
	MOV A, 4
	MOV COUNT1, A
	
TM0_ISR1:
	MOV A, STACK_PSW  ; Put back Register STATUS from temp variable.
	MOV STATUS, A
	MOV A, STACK_ACC  ; Put back Register ACC from temp varialble;
	RETI
	END