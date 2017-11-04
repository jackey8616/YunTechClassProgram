include HT66F50.inc

ds	.section	'data'

cs	.section	at  000h	'code'

MAIN:
	; Programe: HW01-1 Summation of 1 to 10,
	; Put result in 80h
INIT:
	CLR [80h]
	CLR [81h]		; Clear memory address may use.
	MOV A, 10		; Put max into A register.
	MOV [81h], A	; Put A into 81h for later value check if statement.
LOOP:
	MOV A, [81h]	; Put 81h value into A for ADD.
	ADDM A, [80h]	; Add 80h and A register and put result into 80h
	SDZ [81h]		; If 81h's value - 1 is not zero
	JMP LOOP		; 	Goto LOOP label
	JMP $			; else exit program.