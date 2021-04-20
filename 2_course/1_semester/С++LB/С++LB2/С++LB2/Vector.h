#pragma once
class Vector
{
private:
	int longg;
	int str;
	int stolb;
	double** mass1;
	double* rez;
	int m_number;
public:
	Vector(int number = 0)
		: m_number(number)
	{
	}
	Vector(int, int, int);
	~Vector();
	void Error();
	void initializeArray();
	void printArray1D();
	void makeArray2D();
	void printArray2D();
	void operator[](int);
	Vector& operator++(); // версия префикс
	Vector& operator--(); // версия префикс
	Vector operator++(int); // версия постфикс
	Vector operator--(int); // версия постфикс
};

