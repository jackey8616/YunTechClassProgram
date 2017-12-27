include HT66F50.inc

	; Program: Delay with Timer control LED ON/OFF in 0.5s With PWM breathing LED.
	;     Using chip HT66F50, fsys=4MHz

ds	.section	'data'
	COUNT DB ?        ; Nested counter
	COUNT1 DB ?       ; Nested counter
	PWM_ROLL DB ?
	STACK_PSW DB ?    ; Temporary variable store Register STATUS
	STACK_ACC DB ?	  ; Temporary varilabe store Register ACC

cs	.section	at  000h	'code'
	ORG 00h
	JMP INIT
	ORG 14h           ; Timer2's Interupt Vector
	JMP TM2_ISR       ; Assign label.

INIT:
	CLR ACERL         ; Close Comparators
	MOV A, 008h       ; Close ADC
	MOV CP0C, A       ; Close ADC
	MOV CP1C, A       ; Close ADC
	
	CLR PWM_ROLL
	SET PWM_ROLL.0
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
	MOV A, 00000000b
	MOV TM2C0, A
	; TM0C1 Setup:
	;     T0M[2:0] = 10    PWM mode
	;     T0IO[2:0] = 10   PWM Output
	;     T0OC = 1         PWM initial high
	;     T0POL = 1        PWM output pin(TP0_1 = PA.0) complement then output
	;     T0DPX = 0        T0RP control period, TM0A control duty
	;     T0CCLR = 0       When Register ACC match or overflow then keep count
	MOV A,10101100b
	MOV TM0C1, A
	MOV A, 11000001b
	MOV TM2C1, A
	
	MOV A, LOW 200
	MOV TM0AL, A          ; Set TM0's ACC hight bit Register
	MOV A, HIGH 200
	MOV TM0AH, A          ; Set TM0's ACC low bit Register
	
	MOV A, LOW 1000
	MOV TM2AL, A
	MOV A, HIGH 1000
	MOV TM2AH, A
	
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
	
	;SET T0AE     ; Enable T0AF (Flag T0AE)
	SET T2AE
	SET MF0E     ; Enable Multi-Function (Flag MF0E)
	SET EMI      ; Enable Master Interrupt
	
	SET T2ON	 ; Timer 2 Start
	SET T0ON     ; Timer 0 Start

MAIN:
	JMP$
	
TM2_ISR:
	MOV STACK_ACC, A  ; Store Register ACC to temp variable.
	MOV A, STATUS
	MOV STACK_PSW, A  ; Store Register STATUS to temp variable;
	
	CLR T2AF          ; Clear Interrupt Flag T0AF, incase interrupt again.
	SDZ COUNT
		JMP TM2_ISR1
	SDZ COUNT1
		JMP TM2_ISR1
	
	MOV A, 5
	MOV COUNT, A
	MOV A, 4
	MOV COUNT1, A
	
	CALL ROLLING
	
TM2_ISR1:
	MOV A, STACK_PSW  ; Put back Register STATUS from temp variable.
	MOV STATUS, A
	MOV A, STACK_ACC  ; Put back Register ACC from temp varialble;
	RETI

ROLLING PROC
	SZ PWM_ROLL.0
		JMP PWM400
	SZ PWM_ROLL.6
		JMP PWM400
	SZ PWM_ROLL.1
		JMP PWM600
	SZ PWM_ROLL.5
		JMP PWM600
	SZ PWM_ROLL.2
		JMP PWM800
	SZ PWM_ROLL.4
		JMP PWM800
	SZ PWM_ROLL.3
		JMP PWM1000
	CLR PWM_ROLL
	SET PWM_ROLL.0
	RET
		
	PWM400:
		MOV A, LOW 400
		MOV TM0AL, A
		MOV A, HIGH 400
		MOV TM0AH, A
		RL PWM_ROLL
		RET
	PWM600:
		MOV A, LOW 600
		MOV TM0AL, A
		MOV A, HIGH 600
		MOV TM0AH, A
		RL PWM_ROLL
		RET
	PWM800:
		MOV A, LOW 800
		MOV TM0AL, A
		MOV A, HIGH 800
		MOV TM0AH, A
		RL PWM_ROLL
		RET
	PWM1000:
		MOV A, LOW 1000
		MOV TM0AL, A
		MOV A, HIGH 1000
		MOV TM0AH, A
		RL PWM_ROLL
		RET
ROLLING ENDP

END