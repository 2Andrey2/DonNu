MINIMUM macro p
;///////////////////////////////
	xor cx, cx ;чистим регистр cx
j2:
	mov cl, p  ; заносим num в cl
	dec cl ; отнимаем 1 из cl
c0:    
	mov bx, cx ; заносим cx в bx
	mov al, massAndrey[bx] ; заносим mas[bx] (текущий элемент массива) в al
	cmp al, massAndrey[bx-1] ; сравниваем текущий элемент массива с предыдущим
	jg j1 ; если al (а значит mas[bx]) больше, то перехидим на метку j1
	loop c0 ; если нет то: if(cx>0) (cx=cx-1, goto c0);
	jmp j0 ; заканчиваем алгоритм ; Метка j1 меняет текущий и предыдущий элемент мессива
j1:
	mov ah, massAndrey[bx-1]; 
	mov massAndrey[bx], ah
	mov massAndrey[bx-01h], al
	jmp j2
	jmp c0
j0:   
endm
print macro text
	mov ah,09
	lea dx,text
	int 21h
endm
input macro
	mov ah,08
	int 21h
endm
;////////////////////////////////
Chinik segment para 'code'
	assume cs:Chinik,ds:Chinik,ss:Chinik,es:Chinik
	org 100h ; пропускаем первые 256 байт (.com)
begin: jmp main
;-------Данные -------------------
massAndrey db 10,15,45,67,89,44,7,34,37,12
	 db 17,19,23,27,46,83,18,11,3,16
	 db 4,55,2,98,93,91,81,61,62,57
	 db 42,33,1,27,22
sk 	db ?
pr 	db 10,13,'Среди скольких элементов искать минимум ?', 10,13,'$'
pr1 db 10,13,'Отсортированный массив:', 10,13,'$'
buf db 4,4 dup(?)
ps 	db 10,13,'$'
des db ?
ed 	db ?
min db ?
;---------------------------------
main proc near
;-------Команды программы --------
	 call skolko
	 call pechat
;************* Макровызов ********************************
	MINIMUM sk
	PRINT pr1
	call pechat
;****************************************************
	; ожидание нажатия на клавишу
	input
	ret
main endp
; ************** Читаем с экрана, сколько элементов взять из списка **********
skolko proc near
	 ; подсказка
	 PRINT pr
	 ; считываем с экрана число как строку
	 mov ah,0ah
	 lea dx,buf
	 int 21h
	 ; преобразуем строку в число
	 cmp buf+1,1 ; сколько символов ввели ?
	 jne @w1
	 ;один символ ввели
	 mov al,buf+2
	 sub al,30h
	 jmp @w2
	@w1: ; две цифры
	 mov al,buf+2
	 sub al,30h
	 mov bl,10
	 imul bl
	 mov bl,buf+3
	 sub bl,30h
	 add al,bl
	@w2: mov sk,al
	 ; перевод строки
	 print ps
	 ret
skolko endp
;************* Выводим элементы списка на экран ****************************
pechat proc near
	 mov cl,sk
	 mov bp,0
	@w3:
	 mov al,massAndrey+bp ; один элемент списка
	 cbw ; al --> ax
	 mov bl,10
	 idiv bl
	 mov des,al
	 mov ed,ah
	 ; выводим десятки
	 mov ah,02
	 mov dl,des
	 add dl,30h
	 int 21h
	 ; выводим единицы
	 mov ah,02
	 mov dl,ed
	 add dl,30h
	 int 21h
	 ; выводим пробел
	 mov ah,02
	 mov dl,' '
	 int 21h
	 add bp,1 ; переход к следующему элементу
	 loop @w3
	 mov ah,09
	 lea dx,ps
	 int 21h
	 ret
pechat endp
;***********************************************************
Chinik ends
 end begin 