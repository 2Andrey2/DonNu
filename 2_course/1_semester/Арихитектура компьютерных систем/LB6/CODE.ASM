Chinik segment para 'code'
assume cs:Chinik,ds:Chinik,ss:Chinik,es:Chinik
org 100h ; пропускаем первые 256 байт (.com)
begin: jmp main
;---------------------------------
date dw ?
my_s db '+'
T_Th db ?
Th db ?
Hu db ?
Tens db ?
Ones db ?
;---------------------------------
;-------Данные -------------------
temp dw ?
A DT 09C25CF009B000F4A0CFAh ; 9C 25 CF 00 9B 00 0F 4A 0C FA
str2 db 10,13,'Исходная строка в десятичном 156 37 207 0 155 0 15 74 12 250 ',10,13,'$'
str1 db 'Строка результат A = $'
str0 db 'Исходная строка: S  = $'
;---------------------------------
main proc near
mov ah,09h
lea dx,str0
int 21h
;-------- Вывод исходного данного ------------------------
	mov cx,10
	mov si,9
m1000: push cx
	mov bl,byte ptr A+si ; берем один байт для вывода
;------------------------------------------
	mov cx,8
m2000: shl bl,1
	jc edin1
	; выводим ноль
	mov ah,02
	mov dl,'0'
	int 21h

	jmp dalshe1
edin1:
	; выводим единицу
	mov ah,02
	mov dl,'1'
	int 21h

dalshe1:
	loop m2000
;------------------------------------------
	mov ah,02
	mov dl,' '
	int 21h

	sub si,1
	pop cx
	loop m1000
;********************* конец вывода числа в двоичном виде ************
mov ah,09h
lea dx,str2
int 21h
mov ah,09h
lea dx,str1
int 21h
;-------Команды программы --------

	mov bp,0 ; номер байта из десяти --> 0
	mov cx,10 ; цикл по количеству байтов
; ***** Начало внешнего цикла для определения отрицательных чисел******************
m1: mov al,byte ptr [A+bp] ;загружаем в al bp-тый байт
	test al,10000000b ; проверяем старший разряд
	je m3 ; если он!=0, то это отрицательное число
	mov temp,cx
	mov ah,0
	mov date,ax
	call disp
	mov cx,temp
m3:	add bp,1 ; переходим к следующему байту
	loop m1 ; конец цикла по количеству байтов
; ****** конец внешнего циклав

	mov bp,0 ; номер байта из десяти --> 0
	mov cx,10 ; цикл по количеству байтов
; ***** Начало внешнего цикла по определению нулей ******************
m4: push cx ; сохраняем в стеке счетчик цикла
	mov al,byte ptr [A+bp] ;загружаем в al bp-тый байт
	; **** внутренний цикл по 8 битам
	mov cx,8 ; цикл по количеству битов в байте
m5: test al,00000001b ; проверяем нулевой бит байта
	je m6 ; если он=0, то продолжаем цикл
	jmp finish
m6: 
	shr al,1 ; сдвигаем al вправо на один бит
	loop m5 ; конец цикла по количеству битов в байте
	; конец внутреннего цикла по битам
	mov date,0
	mov temp,cx
	call disp
	mov cx,temp
	finish:
	add bp,1 ; переходим к следующему байту
	pop cx ; извлекаем из стека счетчик цикла
	loop m4 ; конец цикла по количеству байтов
; ****** конец внешнего циклав по определению нулей
	
	mov bp,0 ; номер байта из десяти --> 0
	mov cx,10 ; цикл по количеству байтов
; ***** Начало внешнего цикла по положительных чисел ******************
m7: mov al,byte ptr [A+bp] ;загружаем в al bp-тый байт
	cmp al,0
	je m8
	test al,10000000b ; проверяем старший разряд
	js m8 ; если он=0, то это положительное число
	mov temp,cx
	mov ah,0
	mov date,ax
	call disp
	mov cx,temp
m8:	add bp,1 ; переходим к следующему байту
	loop m7 ; конец цикла по количеству байтов
; ****** конец внешнего циклав по положительных чисел
	
	
	mov ah,08 ; задержка до нажатия клавиши
int 21h
ret
main endp
;///////////////////////////////////////
DISP proc near
mov ax,date
and ax,1000000000000000b
mov cl,15
shr ax,cl
cmp ax,1
jne @m1
mov ax,date
neg ax
mov my_s,'-'
jmp @m2
;--- Получаем десятки тысяч ---------------
@m1: mov ax,date
@m2: cwd
mov bx,10000
idiv bx
mov T_Th,al
;------- Получаем тысячи ------------------------------
mov ax,dx
cwd
mov bx,1000
idiv bx
mov Th,al
;------ Получаем сотни ---------------
mov ax,dx
mov bl,100
idiv bl
mov Hu,al
;---- Получаем десятки и единицы ----------------------
mov al,ah
cbw
mov bl,10
idiv bl
mov Tens,al
mov Ones,ah
;--- Выводим знак -----------------------
cmp my_s,'+'
je @m500
mov ah,02h
mov dl,my_s
int 21h
;---------- Выводим цифры -----------------
@m500: cmp T_TH,0 ; проверка на ноль
je @m200

mov ah,02h ; выводим на экран, если не ноль
mov dl,T_Th
add dl,48
int 21h
@m200: cmp T_Th,0
jne @m300
cmp Th,0
je @m400
@m300: mov ah,02h
mov dl,Th
add dl,48
int 21h
@m400: cmp T_TH,0
jne @m600
cmp Th,0
jne @m600

cmp hu,0
je @m700
@m600: mov ah,02h
mov dl,Hu
add dl,48
int 21h
@m700: cmp T_TH,0
jne @m900
cmp Th,0
jne @m900
cmp Hu,0
jne @m900
cmp Tens,0
je @m950
@m900: mov ah,02h
mov dl,Tens
add dl,48
int 21h
@m950: mov ah,02h
mov dl,Ones
add dl,48
int 21h
mov ah,02h
mov dl,0
int 21h
mov ah,02h

mov dl,0
int 21h
;-------------------------------------
mov ah,08
int 21h
ret
DISP endp

Chinik ends
end begin