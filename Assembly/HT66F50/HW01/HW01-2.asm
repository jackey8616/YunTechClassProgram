include HT66F50.inc

ds	.section	'data'

cs	.section	at  000h	'code'

MAIN:
	; Programe: HW01-2 Summation of 1 to 100,
	; Put result high bit into 81h, low bit into 80h.
INIT:
					; Clear memory address may use.
	CLR [80h]		; Low bit
	CLR [81h]		; High bit
	CLR [82h]		; Counter
	MOV A, 100		; Put max into A register.
	MOV [82h], A	; Put A into 82h for later value check if statement.
LOOP:
	MOV A, [82h]	; Put 82h value into A for ADD.
	ADDM A, [80h]	; Add 80h and A register and put result into 80h
	SZ C			; If C is zero than skip next line.
	INC [81h]		; 	increase high bit because C flag register detect carry.
	SDZ [82h]		; If 82h's value minus 1 is not zero
	JMP LOOP		; 	Goto LOOP label
	JMP $			; else exit program.
	
	; Answer should be [80h] = BA, [81h] = 13
	; 1 + 2 + 3 + ... + 100 = 5050(Dec) = 13BA(Hex)