; --------------------------------------------------------
yulya segment para 'code'
assume cs:yulya, ds:yulya,es:yulya,ss:yulya
org 100h
begin: jmp main
;----------------------------------------------------------
; выделение и инициализация ячеек оперативной памяти
s db 'Количество клавиш мыши = $'
nr db ?
s0 db 13,10,'Установлен следующий тип мыши:',13,10,'$'
s1 db '1 - Bus Mouse',13,10,'$'
s2 db '2 - Serial Mouse',13,10,'$'
s3 db '3 - Inport Mouse',13,10,'$'
s4 db '4 - PS/2 Mouse',13,10,'$'
s5 db '5 - HP Mouse',13,10,'$'
X1 dw ?
Y1 dw ?
X dw ?
Y dw ?
saves dw ?
MN db 8
s_k db 5 DUP(?)
;------------Для вывода ---------------------
date dw ?
my_s db '+'
T_Th db ?
Th db ?
Hu db ?
Tens db ?
Ones db ?
;---------------------------------
; ---------------------------------------------------------
main proc near
; ******** код лабораторной работы **********************
; получение текущего видеорежима
mov ah,0fh
int 10h
mov nr,al ; nr - номер режима
; инициализация мыши
mov ax,0000h
int 33h
; вывод количества клавиш мыши
mov ah,09
lea dx,s
int 21h
mov ah,02
mov dl,bl
add dl,48
int 21h
; Получение информации о типе мыши ***************
mov ah,09
lea dx,s0
int 21h
mov ax,0024h
int 33h
; вывод информации о типе мыши ***************
cmp ch,1

jne @z2
; 1 тип
mov ah,09
lea dx,s1
int 21h
jmp @z100
@z2: cmp ch,2
jne @z3
; 2 тип
mov ah,09
lea dx,s2
int 21h
jmp @z100
@z3: cmp ch,3
jne @z4
; 3 тип
mov ah,09
lea dx,s3
int 21h
jmp @z100
@z4: cmp ch,4
jne @z5
; 4 тип
mov ah,09
lea dx,s4
int 21h
jmp @z100
@z5: cmp ch,5
jne @z100
; 5 тип
mov ah,09
lea dx,s5
int 21h
@z100:
; ожидание нажатия любой клавиши
mov ah,0 ; получаем номер клавиши
int 16h
; выключить курсор
mov ah,01
mov ch,20h
int 10h
; включить курсор мыши
mov ax,0001
int 33h
@save:
mov ax,X1
idiv mn
mov X,ax
mov ax,X
mov saves,ax
looping:
; получить координаты курсора мыши


mov ax,0003
int 33h
test bx,00000001b
jne @save
test bx,00000010b
jne @go_out
;cmp bx,1
;jnz looping
mov X1,cx
mov Y1,dx
; Делим на 8
mov ax,X1
idiv mn
mov X,ax
mov ax,Y1
idiv mn
mov Y,ax
call form_str
call viv_coord
jmp looping
;*******************************************************
@go_out:
mov X1,cx
mov ax,X1
idiv mn
mov X,ax
mov cx,X
;mov cx,saves
sub cx,saves
mov X,5
mov Y,cx
call form_str
call viv_coord
; ожидание нажатия любой клавиши
mov ah,0 ; получаем номер клавиши
int 16h
; восстановление текстового режима
mov ah,0
mov al,nr
int 10h
; ******************************************************
ret ; возврат в операционную систему
main endp
;********************************************
viv_coord proc near
push cs
pop es
mov ah,13h
lea bp,s_k
mov cx,5
mov dh,0
mov dl,0
mov al,0
mov bl,1Eh
int 10h
ret
viv_coord endp
; Формирование строки для вывода
form_str proc near
mov ax,X
cbw
mov bl,10
idiv bl
add al,30h ; десятки в виде символа
add ah,30h ; единицы в виде символа

mov bp,0
mov [s_k+bp],al
add bp,1
mov [s_k+bp],ah
; пробел
add bp,1
mov [s_k+bp],' '
; для Y
mov ax,Y
cbw
mov bl,10
idiv bl
add al,30h ; десятки в виде символа
add ah,30h ; единицы в виде символа
add bp,1
mov [s_k+bp],al
add bp,1
mov [s_k+bp],ah
ret
form_str endp
;???????????????????????????
vivod proc near
;--- Число отрицательное ?----------
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
;------- Получаем тысячи --------------------
mov ax,dx
cwd
mov bx,1000
idiv bx
mov Th,al
;------ Получаем сотни -----------------------
mov ax,dx
mov bl,100
idiv bl
mov Hu,al
;---- Получаем десятки и единицы ---------
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
mov dl,' '
int 21h
ret
vivod endp
yulya ends
end begin