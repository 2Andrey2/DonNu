#pragma once

#include "ILoggable.h"

class ExpressionEvaluator:ILoggable
{
protected:
	int number; // Количество операндов
	double* massOret; // Массив операндов с динамической памятью (Выделяется в конструкторе)
	int masssize;
public:
	ExpressionEvaluator(); // Выделение памяти под 20
	ExpressionEvaluator(int); // Выделение памяти под n элементов
	virtual double calculate() = 0; // Чисто виртуальная функция/метод
	void logToScreen(); // Переопределение из абстракного класса
	void logToFile(const std::string& filename); // Переопределение из абстракного класса
	void setOperand(size_t pos, double value) { massOret[pos] = value; }; // Изменение одного объекта
	void setOperands(double ops[], size_t n); // Изменение группы объектов (реализация в cpp) 
	virtual ~ExpressionEvaluator(); // Деструктор виртуальный
};

