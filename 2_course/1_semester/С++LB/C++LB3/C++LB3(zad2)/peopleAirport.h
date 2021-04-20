#pragma once
#include "IPeople.h"

class peopleAirport:public IPeople
{
protected:
	int Phone;
	virtual void displayInformation() = 0;
};

