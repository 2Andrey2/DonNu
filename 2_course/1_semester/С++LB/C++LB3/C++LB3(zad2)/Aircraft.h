#pragma once
#include <string>
#include "IAirport.h"

class Aircraft:IAirport
{
protected:
	std::string Firm;
	int Capacity;
	std::string dateOfissue;
	int readiness;
	int numberOfflights;
public:
	Aircraft();
	Aircraft(std::string,std::string,std::string,int, std::string,int);
	void PrintingAircraft();
};

