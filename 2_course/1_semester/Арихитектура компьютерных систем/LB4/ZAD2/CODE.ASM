; Определение значений 9-го и 10-го битов слова
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
A1 dw 1000
A2 dw -10
Y1 dw ?
Y2 dw ?

A dw 300
B dw 200
Z dw ?
Z1 dw ?
Z2 dw ?
Z3 dw ?
X dw 100
rez dw ?
adres dw ?
Y dw ?
;------------------------------------------
;------------------------------------------
main proc near

NEG A
mov ax,A
sub ax,B
mov Z1,ax
NEG A
; Вычисления для Z1 = -A-B
mov ax,A
add ax,B
mov Z2,ax
; Вычисления для Z2 = A+B
mov ax,A
sub ax,B
mov Z3,ax
; Вычисления для Z3 = A-B
push Z3
push Z2
push Z1
call myproc1 ; в верхушке стека адрес возврата,под ним z1,z2,z3
pop ax ; достаем ответ из стека (стек теперь пустой)
mov ax,Y
mov date,ax
call disp

mov ax,A1
cwd
div A2
add ax,10
mov Y1,ax
call myproc2 ; положили в стек адрес возврата
pop Y2

mov ax,Y2
mov date,ax
call disp
ret
main endp
;------------------------------------------
;------------------------------------------
myproc1 proc near
pop adres ; достаем из стека адрес возврата в ячейку adres
; -- команды задания
pop Z1
pop Z2
pop Z3
cmp Z1,0
jnz m1
cmp z2,0
jnz m1
cmp z3,0
jnz m1
mov Y,1
jmp konec1
m1:
mov Y,0
jmp konec1
konec1: push Y ; кладем в стек Y (ответ)
; -- конец задания
push adres ; возвращаем на верхушку стека адрес возврата
ret
myproc1 endp
;------------------------------------------

;------------------------------------------
myproc2 proc near
pop adres ; достали адрес возврата из стека в ячейку adres
pop Y1
cmp Y1,0
jg metka1
mov Y2,0DFh ; по заданию флаг DF, но я незнаю как его считать
jmp konec2
metka1:
mov Y2,0FDh; по заданию флаг FD, но я незнаю как его считать
metka2:
jmp konec2
konec2:
push Y2
push adres
ret
myproc2 endp
;------------------------------------------
;------------------------------------------
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
mov dl,10
int 21h
mov ah,02h

mov dl,13
int 21h
;-------------------------------------
mov ah,08
int 21h
ret
DISP endp

Chinik ends
end begin