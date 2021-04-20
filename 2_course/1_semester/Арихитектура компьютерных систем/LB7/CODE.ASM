nata segment 'code'
assume cs:nata
org 100h
begin: jmp main
;--------------------------------- DATA
Gorod DB 15,'Горловка - Макеевка     ',11,'Макеевка - Донецк       ' ; 24 символов на маршрут
DB 99,'Шахтерск - Румянцево    ',71,'Горловка - Енакиево     '
DB 55,'Торез - Мирный          ',13,'Донецк - Ростов         '
DB 10,'Донецк - Москва         ',55,'Ясиноватая - Дебальцево '
DB 14,'Харцызск - Енакиево     ',39,'Торез - Дебальцево      '
Rezult DB 24 Dup(?),'$'
Buf DB 3,3 Dup(?)
Distance DB ?
Mes DB 'Поезда с таким номером не существует !$'
Eter DB 10,13,'$'
Podskaz DB 'Введи номер поезда:$'
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
lea di,gorod ; строка, где искать
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
mov cl,24
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