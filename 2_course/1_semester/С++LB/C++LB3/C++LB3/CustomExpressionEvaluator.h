#pragma once
#include "ExpressionEvaluator.h"
#include "IShuffle.h"

class CustomExpressionEvaluator:public IShuffle, public ExpressionEvaluator
{
private:
public:
	void shuffle();
	void shuffle(size_t i, size_t j);
	double calculate();
	CustomExpressionEvaluator(int size) { masssize = size; massOret = new double[masssize] { 0.0 };};
};

