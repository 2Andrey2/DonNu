MINIMUM macro mas,num
	xor cx, cx ;чистим регистр cx
j2:
	mov cl, num  ; заносим num в cl
	dec   cl ; отнимаем 1 из cl
c0:    
	mov bx, cx ; заносим cx в bx
	mov al, mas[bx] ; заносим mas[bx] (текущий элемент массива) в al
	cmp al, mas[bx-1] ; сравниваем текущий элемент массива с предыдущим
	jg j1 ; если al (а значит mas[bx]) больше, то перехидим на метку j1
	loop c0 ; если нет то: if(cx>0) (cx=cx-1, goto c0);
	jmp j0 ; заканчиваем алгоритм ; Метка j1 меняет текущий и предыдущий элемент мессива
j1:    
	mov ah, mas[bx-1]; 
	mov mas[bx], ah
	mov mas[bx-01h], al
	jmp j2
	jmp c0
j0:    
endm

Chinik segment para 'code'
assume cs:Chinik,ds:Chinik,ss:Chinik,es:Chinik
org 100h ; пропускаем первые 256 байт (.com)
begin: jmp main
;-------Данные -------------------
SPISOK 	db 10,15,45,67,89,44,7,34,37,12
 	db 17,19,23,27,46,83,18,11,3,16
 	db 4,55,2,98,93,91,81,61,62,57
 	db 42,33,1,27,22
sk db 30
pr db 10,13,'Скотлько элементов сортировать?', 10,13,'$'
buf db 4,4 dup(?)
ps db 10,13,'$'
des db ?
ed db ?
otv db 10,13,'Отсортированные = $'
min db ?
;---------------------------------
main proc near
;-------Команды программы --------
 call pechat
;************* Макровызов ********************************
 MINIMUM SPISOK, sk
;****************************************************
 call otvet
 ret
main endp
;************* Выводим элементы списка на экран ****************************
pechat proc near
 mov cl,sk
 mov bp,0
@w3:
 mov al,SPISOK+bp ; один элемент списка
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
otvet proc near
 mov ah,09
 lea dx,otv
 int 21h
 ; вывод числа по одной цифре
 mov al,min
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
 ; перевод строки
 mov ah,09
 lea dx,ps
 int 21h
 ; ожидание нажатия на клавишу
 mov ah,08
 int 21h

 ret
otvet endp
Chinik ends
 end begin 