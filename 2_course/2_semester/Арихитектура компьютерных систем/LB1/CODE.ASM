nata segment 'code'
assume cs:nata
org 100h
begin: jmp main
;--------------------------------- DATA
aircraft DB 15,'АТР         ',11,'British     ' ; 24 символов на маршрут
DB 99,'Airbus      ',71,'Fokker      '
DB 55,'Bell/Agusta ',13,'Lancair     '
DB 10,'Boeing      ',55,'Vickers     '
DB 14,'Bombardier  ',39,'Суперджет   '
Rezult DB 12 Dup(?),'$'
Buf DB 3,3 Dup(?)
Distance DB ?
Mes DB 'Самолета с такими характеристиками не существует !$'
Eter DB 10,13,'$'
Podskaz DB 'Введи скорость самолета:$'
;---------------------------------
main proc near
;------------------------------------- PROGRAM
; ------ Подсказка -------
mov ah,09
lea dx,podskaz
int 21h
; Ввод строки
mov ah,0ah
lea dx,Buf
int 21h
; Преобразование символов в число
; Получаем десятки из буфера
mov bl,buf+2
sub bl,30h
mov al,10
imul bl ; в al - десятки
; Получаем единицы из буфера
mov bl,buf+3
sub bl,30h
; Складываем ------
add al,bl
mov distance,al ; сохраняем в distance
; -------- Переход на новую строку ---
mov ah,09h
lea dx,eter
int 21h
; --- сканирование таблицы городов ----
cld ; искать слева направо

mov cx,240 ; сколько байт сканировать
lea di,aircraft ; строка, где искать
mov al,distance ; что искать
repne scasb ; поиск
je @m2
; ------- Сообщение об отсутствии города
mov ah,09h
lea dx,Mes
int 21h
jmp @m3 ; выходим из программы
; -------- переписываем в результат
@m2:
cld
mov si,di
lea di,rezult
mov cl,12
rep movsb
; ----- Вывод результата ----
mov ah,09h
lea dx,rezult
int 21h
;-------------------------------------
@m3: mov ah,08
int 21h
ret
main endp
nata ends
end begin