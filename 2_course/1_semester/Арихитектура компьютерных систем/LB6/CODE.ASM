Chinik segment para 'code'
assume cs:Chinik,ds:Chinik,ss:Chinik,es:Chinik
org 100h ; �ய�᪠�� ���� 256 ���� (.com)
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
;-------����� -------------------
temp dw ?
A DT 09C25CF009B000F4A0CFAh ; 9C 25 CF 00 9B 00 0F 4A 0C FA
str2 db 10,13,'��室��� ��ப� � �����筮� 156 37 207 0 155 0 15 74 12 250 ',10,13,'$'
str1 db '��ப� १���� A = $'
str0 db '��室��� ��ப�: S  = $'
;---------------------------------
main proc near
mov ah,09h
lea dx,str0
int 21h
;-------- �뢮� ��室���� ������� ------------------------
	mov cx,10
	mov si,9
m1000: push cx
	mov bl,byte ptr A+si ; ��६ ���� ���� ��� �뢮��
;------------------------------------------
	mov cx,8
m2000: shl bl,1
	jc edin1
	; �뢮��� ����
	mov ah,02
	mov dl,'0'
	int 21h

	jmp dalshe1
edin1:
	; �뢮��� �������
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
;********************* ����� �뢮�� �᫠ � ����筮� ���� ************
mov ah,09h
lea dx,str2
int 21h
mov ah,09h
lea dx,str1
int 21h
;-------������� �ணࠬ�� --------

	mov bp,0 ; ����� ���� �� ����� --> 0
	mov cx,10 ; 横� �� �������� ���⮢
; ***** ��砫� ���譥�� 横�� ��� ��।������ ����⥫��� �ᥫ******************
m1: mov al,byte ptr [A+bp] ;����㦠�� � al bp-�� ����
	test al,10000000b ; �஢��塞 ���訩 ࠧ��
	je m3 ; �᫨ ��!=0, � �� ����⥫쭮� �᫮
	mov temp,cx
	mov ah,0
	mov date,ax
	call disp
	mov cx,temp
m3:	add bp,1 ; ���室�� � ᫥���饬� �����
	loop m1 ; ����� 横�� �� �������� ���⮢
; ****** ����� ���譥�� 横���

	mov bp,0 ; ����� ���� �� ����� --> 0
	mov cx,10 ; 横� �� �������� ���⮢
; ***** ��砫� ���譥�� 横�� �� ��।������ �㫥� ******************
m4: push cx ; ��࠭塞 � �⥪� ���稪 横��
	mov al,byte ptr [A+bp] ;����㦠�� � al bp-�� ����
	; **** ����७��� 横� �� 8 ��⠬
	mov cx,8 ; 横� �� �������� ��⮢ � ����
m5: test al,00000001b ; �஢��塞 �㫥��� ��� ����
	je m6 ; �᫨ ��=0, � �த������ 横�
	jmp finish
m6: 
	shr al,1 ; ᤢ����� al ��ࠢ� �� ���� ���
	loop m5 ; ����� 横�� �� �������� ��⮢ � ����
	; ����� ����७���� 横�� �� ��⠬
	mov date,0
	mov temp,cx
	call disp
	mov cx,temp
	finish:
	add bp,1 ; ���室�� � ᫥���饬� �����
	pop cx ; ��������� �� �⥪� ���稪 横��
	loop m4 ; ����� 横�� �� �������� ���⮢
; ****** ����� ���譥�� 横��� �� ��।������ �㫥�
	
	mov bp,0 ; ����� ���� �� ����� --> 0
	mov cx,10 ; 横� �� �������� ���⮢
; ***** ��砫� ���譥�� 横�� �� ������⥫��� �ᥫ ******************
m7: mov al,byte ptr [A+bp] ;����㦠�� � al bp-�� ����
	cmp al,0
	je m8
	test al,10000000b ; �஢��塞 ���訩 ࠧ��
	js m8 ; �᫨ ��=0, � �� ������⥫쭮� �᫮
	mov temp,cx
	mov ah,0
	mov date,ax
	call disp
	mov cx,temp
m8:	add bp,1 ; ���室�� � ᫥���饬� �����
	loop m7 ; ����� 横�� �� �������� ���⮢
; ****** ����� ���譥�� 横��� �� ������⥫��� �ᥫ
	
	
	mov ah,08 ; ����প� �� ������ ������
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
;--- ����砥� ����⪨ ����� ---------------
@m1: mov ax,date
@m2: cwd
mov bx,10000
idiv bx
mov T_Th,al
;------- ����砥� ����� ------------------------------
mov ax,dx
cwd
mov bx,1000
idiv bx
mov Th,al
;------ ����砥� �⭨ ---------------
mov ax,dx
mov bl,100
idiv bl
mov Hu,al
;---- ����砥� ����⪨ � ������� ----------------------
mov al,ah
cbw
mov bl,10
idiv bl
mov Tens,al
mov Ones,ah
;--- �뢮��� ���� -----------------------
cmp my_s,'+'
je @m500
mov ah,02h
mov dl,my_s
int 21h
;---------- �뢮��� ���� -----------------
@m500: cmp T_TH,0 ; �஢�ઠ �� ����
je @m200

mov ah,02h ; �뢮��� �� ��࠭, �᫨ �� ����
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