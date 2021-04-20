#include "Passengers.h"

Passengers::Passengers()
{
	std::string fullName = "";
	Age = 0;
	Phone = 0;
	numberOfticket = 0;
	flightNumber = 0;
	passportID = 0;
	std::cout << "Создан пустой класс Passengers" << std::endl;
}

Passengers::Passengers(std::string fullName1, int Age1, int Phone1, int numberOfticket1, int flightNumber1, int passportID1)
{
	fullName = fullName1;
	Age = Age1;
	Phone = Phone1;
	numberOfticket = numberOfticket1;
	flightNumber = flightNumber1;
	passportID = passportID1;
}

void Passengers::displayInformation()
{
	std::cout << "fullName: " << fullName << std::endl;
	std::cout << "Age: " << Age << std::endl;
	std::cout << "Phone: " << Phone << std::endl;
	std::cout << "numberOfticket: " << numberOfticket << std::endl;
	std::cout << "flightNumber: " << flightNumber << std::endl;
	std::cout << "passportID: " << passportID << std::endl << std::endl;
}
