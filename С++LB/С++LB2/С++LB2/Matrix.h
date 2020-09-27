#pragma once
class Matrix
{
private:
	int longg;
	int str;
	int stolb;
	double** mass1;
	double* rez;
public:
	Matrix(int,int);
	~Matrix();
	void initializeArray();
	void printArray2D();
	double* makeArray1D();
	void printArray1D();
	double at(int, int);
	void setAt(int,int, double);
};

