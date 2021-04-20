#pragma once
#include "peopleAirport.h"
#include "IAirport.h"

class Staff:public peopleAirport, public IAirport
{
private:
	int number;
	int experience;
	std::string Position;
public:
	Staff();
	Staff(std::string, int, int, int, int, std::string, std::string, std::string);
	void displayInformation();
};

