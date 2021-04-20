#pragma once
#include "ExpressionEvaluator.h"
#include "IShuffle.h"

class Summator:public IShuffle,public ExpressionEvaluator
{
private:
public:
	void shuffle();
	void shuffle(size_t i, size_t j);
	double calculate();
	Summator(int);
};

