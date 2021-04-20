#pragma once
#include "ExpressionEvaluator.h"
#include "IShuffle.h"

class Subtractor:public IShuffle, public ExpressionEvaluator
{
private:
public:
	void shuffle();
	void shuffle(size_t i, size_t j);
	Subtractor(int);
	double calculate();
};

