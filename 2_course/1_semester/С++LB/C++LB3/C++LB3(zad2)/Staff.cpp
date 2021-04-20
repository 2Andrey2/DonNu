#include "Staff.h"

Staff::Staff()
{
	std::string fullName = "";
	Age = 0;
	Phone = 0;
	number = 0;
	experience = 0;
	std::string Position = "";
	std::cout << "Создан пустой класс Staff" << std::endl;
}

Staff::Staff(std::string fullName1, int Age1, int Phone1, int number1, int experience1, std::string Position1, std::string City1, std::string Name1)
{
	fullName = fullName1;
	Age = Age1;
	Phone = Phone1;
	number = number1;
	experience = experience1;
	Position = Position1;
	City = City1;
	Name = Name1;
}

void Staff::displayInformation()
{
	std::cout << "fullName: " << fullName << std::endl;
	std::cout << "Age: " << Age << std::endl;
	std::cout << "Phone: " << Phone << std::endl;
	std::cout << "number: " << number << std::endl;
	std::cout << "experience: " << experience << std::endl;
	std::cout << "City: " << City << std::endl;
	std::cout << "Name: " << Name << std::endl;
	std::cout << "Position: " << Position << std::endl << std::endl;
}
