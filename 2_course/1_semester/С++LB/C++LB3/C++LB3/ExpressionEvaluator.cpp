#include <string>
#include <iostream>
#include <ctime>
#include <iomanip>
#include <cstring>
#include <fstream>
#include "ExpressionEvaluator.h"

void ExpressionEvaluator::setOperands(double ops[], size_t n) {
	for (size_t i = 0; i < n; i++)
	{
		if (i > sizeof(ops)) { massOret[i] = 0; }
		else { massOret[i] = ops[i]; }
	}
}
ExpressionEvaluator::~ExpressionEvaluator() {
	delete(massOret);
}
ExpressionEvaluator::ExpressionEvaluator(int n)
{ 
	number = 0;
	masssize = 0;
	massOret = new double[n];
}
void ExpressionEvaluator::logToScreen()
{
	for (int i = 0; i < masssize; i++)
	{
		std::cout << massOret[i];
		std::cout << " || ";
	}
}
void ExpressionEvaluator::logToFile(const std::string& filename)
{
	std::ofstream fout;
	fout.open(filename);
	if (!fout.is_open())
	{ std::cout << "Îøèáêà" << std::endl; }
	else
	{
		for (size_t i = 0; i < masssize; i++)
		{
			fout.write((char*)&massOret[i], sizeof(ExpressionEvaluator));
		}
	}
	fout.close();
}
ExpressionEvaluator::ExpressionEvaluator()
{
	number = 0;
	masssize = 0;
}

