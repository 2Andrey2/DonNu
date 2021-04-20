#pragma once
#include <windows.h>
#include "Game.h"

class IFormattable
{
public:
	std::string a[];
	virtual std::string format();
	virtual void prettyPrint(const IFormattable& object);
};