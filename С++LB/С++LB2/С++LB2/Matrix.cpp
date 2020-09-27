#include <iostream>
#include <ctime>
#include <iomanip>
#include <cstring>
#include "Matrix.h"

Matrix::Matrix(int str1, int stolb1)
{
	str = str1;
	stolb = stolb1;
	mass1 = new double* [str];
	longg = str * stolb;
	rez = new double[longg];
}

Matrix::~Matrix()
{
	for (int count = 0; count < str; count++)
		delete mass1[count];
	delete mass1;
	//delete rez; Спросить почему
}


void Matrix::initializeArray()
{
	for (int count = 0; count < str; count++)
		mass1[count] = new double[stolb];
	for (int count_row = 0; count_row < str; count_row++)
		for (int count_column = 0; count_column < stolb; count_column++)
			mass1[count_row][count_column] = sin(count_row - count_column) + cos(count_row + count_column);
}
void Matrix::printArray2D()
{
	for (int count_row = 0; count_row < str; count_row++)
	{
		for (int count_column = 0; count_column < stolb; count_column++)
			std::cout << std::setw(10) << std::setprecision(10) << mass1[count_row][count_column] << "     ";
		std::cout << std::endl;
	}
}
double* Matrix::makeArray1D()
{
	for (int i = 0; i < str; i++)
	{
		for (int j = 0; j < stolb; j++)
		{
			rez[longg] = mass1[i][j];
		}
	}
	return rez;
}
void Matrix::printArray1D()
{
	for (int i = 0; i < longg; i++)
	{
		std::cout << i[rez] << " ";
	}
	std::cout << std::endl;
}

void Matrix::setAt(int i, int j, double zen)
{
	mass1[i][j] = zen;
}
double Matrix::at(int i, int j)
{
	return mass1[i][j];
}
