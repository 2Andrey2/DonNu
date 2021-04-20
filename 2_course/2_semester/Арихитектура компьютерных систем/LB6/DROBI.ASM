; - Y = ln ((1+x)/(1-x))/2
CODESG segment
	ASSUME cs:CODESG
	ASSUME ds:CODESG
	ASSUME es:CODESG
	ASSUME ss:CODESG
	org 100h

begin:jmp main
; выделение и инициализация ячеек оперативной памяти
XX dd 5.4
YY dd ?
DWA dd 1.1
CHETIRE dd 2.2
TIME1 dd ?
TIME2 dd ?
;------------------------------------------------------------
;******************************************************************************
	X 		dd ?
	y 		dd ?
	result 		dd -56.875
	floatpart	dd ?
	tmp 		dd ?
	intpart		dd ?
	numb 		dw ?
	lenintpart 	dw 5
	lenfloatpart	dw 3
	tmpint		dw ?
	d 		dd 10.0
	print_str 	db 20 dup('$')
	separator 	db '.'
	sign		db ' '

;******************************************************************************
MAIN proc
FINIT ; инициализация математического сопроцессора
FLD DWA 	; ST(0) = DWA = 1.1
FLD XX		; ST(0) = X = 5.4
FADD		; ST(0) = X+DWA = 1.1 + 5.1 = 6.5
FSTP TIME1	; TIME1 = X+DWA = 1.1 + 5.1 = 6.5
FLD DWA		; ST(0) = DWA = 1.1
FLD XX		; ST(0) = X = 5.4
FSUB		; ST(0) = DWA - X = 1.1 - 5.1 = -4.3
FSTP TIME2	; TIME1 = DWA - X = 1.1 - 5.1 = -4.3
FLD TIME1	; ST(0) = TIME1 = 6.5
FLD TIME2	; ST(0) = TIME2 = -4.3
FDIV		; ST(0) = TIME1/TIME2 = 6.5 / -4.3 = -1.4
FSTP TIME1	; TIME1 = TIME1/TIME2 = 6.5 / -4.3 = -1.4
FLD TIME1	; ST(0) = TIME1 = -1.4 ST(1) = Ln(2)
FLDLN2;		; ST(0) = Ln(2) = 
FYL2X;		; ST(0) = log2(5)*ln(2) = ln(5) = 0.8

FSTP TIME1	; TIME1 = log2(5)*ln(2) = ln(5) = 0.8
FLD TIME1	; ST(0) = TIME1 = 0.8
FLD CHETIRE	; ST(0) = CHETIRE = 2.2
FDIV		; ST(0) = TIME1/CHETIRE = 0.8/2.2 = 0.363
;------------------------------------------------------------------------------
;fld result        ; загружаем в ST(0)
fstp result		   ; выгружаем из ST(0) ячейку в result
call Out_DD_float
ret
;-------------------------------------
main endp

;*****************************************************************
;  Процедура вывода 4-байтового вещественного числа	     
;  Вход: переменная lenfloatpart (DW) = число знаков после точки
;        переменная result (DD) - число для вывода
;	 переменная  d (DD) - основание системы счисления
;  Выход: строка print_str (строка выводится на экран)
;  Исполузует: y(DD),intpart(DD),floatpart(DD),tmp(DD),
;              lenintpart(DW),separator(DB),tmpint(DW),
;              sign(DB), numb(DW)
;	{offset lenfloatpart = offset lenintpart + 2}
;	{offset sign         = offset separator  + 1}
;*****************************************************************

Out_DD_float proc near
;--------------------------------------
fld result	;загрузить в ST(0) переменную для вывода
lea si,result
add si,3
mov al,[si]
test al,80h
jz @positiv
	fchs
	mov sign,'-'
@positiv:
	fst tmp
	fld1
	fld tmp
	fprem
	fsub st(2),st
	mov cx,lenfloatpart
	mov lenfloatpart,cx
@floatpart_mul_10:
	fmul d
loop @floatpart_mul_10
	frndint
	fstp floatpart
	fstp tmp
	fstp intpart
;---------------------------------запись цифр в строку
mov cx,2
lea si,print_str
add si,lenintpart
add si,lenfloatpart
lea di,separator
lea bx,lenfloatpart
fld floatpart
@print_to_str:
	fst y
	push cx
	mov cx,[bx]
	@repeate_out_char:
		fld d
		fld y
		fprem
		fist numb
		fsub st(2),st
		fstp tmp
		fdiv
		fist tmpint
		fst y
		mov dx,numb
		mov ax,tmpint
		add dl,48
		mov [si],dl
		dec si
		cmp ax,0
	loopne @repeate_out_char
	fstp tmp
	mov al,[di]
	mov [si],al
	inc di
	dec si
	sub bx,2
	fld intpart
	pop cx
loop @print_to_str
fstp tmp
;------------------------------------Вывод строки на экран
inc si
mov dx,si
mov ah,09h
int 21h
ret
;--------------------------------------
Out_DD_float endp

;*****************************************************************************
codesg ends
end begin
