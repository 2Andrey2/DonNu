#include "CustomExpressionEvaluator.h"

double CustomExpressionEvaluator::calculate()
{
	double temp = massOret[0];
	for (int i = 1; i < masssize; i++)
	{
		if (i == 1)
		{
			temp = temp / massOret[i];
		}
		else
		{
			temp = temp + massOret[i];
		}
	}
	return temp;
}
void CustomExpressionEvaluator::shuffle() {
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
void CustomExpressionEvaluator::shuffle(size_t i, size_t j) {
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
