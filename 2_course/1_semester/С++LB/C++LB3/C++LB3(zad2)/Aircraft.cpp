#include "Aircraft.h"

Aircraft::Aircraft()
{
	City = "";
	Name = "";
	Rating = 0;
	Firm = "";
	Capacity = 0;
	dateOfissue = "";
	readiness = 0;
	numberOfflights = 0;
	std::cout << "Создан пустой самолет" << std::endl;
}

Aircraft::Aircraft(std::string City1, std::string Name1, std::string Firm1, int Capacity1, std::string dateOfissue1, int numberOfflights1)
{
	City = City1;
	Name = Name1;
	Firm = Firm1;
	Capacity = Capacity1;
	dateOfissue = dateOfissue1;
	readiness = 0;
	numberOfflights = numberOfflights1;
}

void Aircraft::PrintingAircraft()
{
	std::cout << "City:" << City << std::endl;
	std::cout << "Name:" << Name << std::endl;
	std::cout << "Firm:" << Firm << std::endl;
	std::cout << "Capacity:" << Capacity << std::endl;
	std::cout << "dateOfissue:" << dateOfissue << std::endl;
	std::cout << "readiness:" << readiness << std::endl;
	std::cout << "numberOfflights:" << numberOfflights << std::endl << std::endl;
}
