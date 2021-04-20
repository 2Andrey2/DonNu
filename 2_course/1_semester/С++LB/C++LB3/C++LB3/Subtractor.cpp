#include "Subtractor.h"

Subtractor::Subtractor(int size)
{
	masssize = size;
	massOret = new double[masssize] { 0.0 };
}

double Subtractor::calculate()
{
	double temp = 0;
	for (size_t i = 0; i < masssize; i++)
	{
		temp = temp - massOret[i];
	}
	return temp;
}
void Subtractor::shuffle() {
	/*for (size_t i = 0; i < sizeof(massOret); i++)
	{
		massOret[i] = massOret[rand() % sizeof(massOret)];
	}
	*/
	//По заданию
	double temp;
	int temp1 = 0;
	for (size_t i = 0; i < sizeof(massOret); i++)
	{
		if (massOret[i] < 0) {
			temp = massOret[temp1];
			massOret[temp1] = massOret[i];
			massOret[i] = temp;
		}
	}
}
void Subtractor::shuffle(size_t i, size_t j) {
	/*double temp = massOret[i];
	massOret[i] = massOret[j];
	massOret[j] = temp;*/
	// По заданию
	if (i < 0 && j > 0) {
		double temp = massOret[i];
		massOret[i] = massOret[j];
		massOret[j] = temp;
	}
}
