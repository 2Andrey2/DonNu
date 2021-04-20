CODESG SEGMENT PARA 'code'
ASSUME CS:CODESG, DS:CODESG, SS:CODESG, ES:CODESG
ORG 100H
BEGIN: JMP MAIN

;---------------------------------
date dw ?
my_s db '+'
T_Th db ?
Th db ?
Hu db ?
Tens db ?
Ones db ?
;---------------------------------

a DW 123
b DW 23
c DW 300
d DW 12
e DW 8
f DW 1982
g DW 982
h DW 45
i DW 155
k DW 2
temp1 DW ?
temp2 DW ?
temp3 DW ?

MAIN PROC NEAR
;add sub mul div

mov ax,a
sub ax,b
add ax,c
mov temp1,ax
;Верх дроби
mov ax,d
add ax,e
mov temp2,ax
;Низ дроби
mov ax,temp1
cwd
idiv temp2
mov temp1,ax
;Поделили первую дробь
mov ax,f
sub ax,g
mov temp2,ax
;Верх второй дроби
mov ax,h
add ax,i
mov temp3,ax
;Низ второй дроби
mov ax,temp2
cwd
idiv temp3
mul k
mov temp2,ax
;Посчитали вторую часть уравненияя
mov ax,temp1
sub ax,temp2
mov date,ax
call DISP

ret
RET
 
MAIN ENDP

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

CODESG ENDS
END BEGIN