#pragma once
#include "peopleAirport.h"

class Passengers:public peopleAirport
{
private:
	int numberOfticket;
	int flightNumber;
	int passportID;
public:
	Passengers();
	Passengers(std::string,int,int,int,int,int);
	void displayInformation();
};

