#include <string>
#include <iostream>
#include "Aircraft.h"
#include "Staff.h"
#include "Passengers.h"

int main()
{
	setlocale(LC_CTYPE, "rus");
	std::string City[6] = {"Gorlovka","Donetsk","Kiev","Rostov","London","Moscow"};
	std::string Name[5] = {"Домодедово","Шереметьево","Пулково","Толмачёво","Сочи"};
	std::string Firm[4] = {"Boeing","Aircraft","S.A.S.","AASI"};
	int Capacity[6] = {100,200,300,400,500,550};
	std::string dateOfissue[4] = {"21.09.2015","15.12.2018","06.01.2012","09.10.2019"};
	int numberOfflights[10] = {1,2,3,4,5,6,7,8,9,10};
	Aircraft* mass[10];
	for (size_t i = 0; i < 10; i++)
	{
		mass[i] = new Aircraft(City[rand() % 6],Name[rand() % 5], Firm[rand() % 4], Capacity[rand() % 6], dateOfissue[rand() % 4], numberOfflights[i]);
		mass[i]->PrintingAircraft();
	}
	peopleAirport* mass2 [20];
	std::string fullName[10] = {"Васильянов А.И.","Петров И.Н.","Мирный Р.Г.","Шербун Р.А.","Ломин Н.С","Карягин В.Р.","Наумова Л.Е","Емельяненко А.П.","Черепцова Е.Н.","Всеволод Г.П"};
	int Age[10] = {40,30,32,36,37,50,42,46,31,38};
	int Phone[10] = {715,125,589,587,785,785,324,746,359,784};
	int Staffnumber[10] = {1,2,3,4,5,6,7,8,9,10};
	int Staffexperience[10] = {5,10,12,9,8,15,13,25,20,18};
	std::string Position[5] = { "Пилот","Диспетчер","Уборщик","Официант","Пилот" };
	int numberOfticket[10] = {154,856,897,435,691,358,125,785,785,324};
	int flightNumber[10] = {874,848,89,65,7458,1254,14,56,87,45};
	int passportID[10] = {4587,6589,1456,1237,7895,7845,7854,9861,8741,4587};
	for (size_t i = 0; i < 19; i++)
	{
		mass2[i] = new Staff(fullName[rand() % 10], Age[rand() % 10], Phone[rand() % 10], Staffnumber[rand() % 10], Staffexperience[rand() % 10], Position[rand() % 5], City[rand() % 6], Name[rand() % 5]);
		dynamic_cast<Staff*>(mass2[i])->displayInformation();
		mass2[i+1] = new Passengers(fullName[rand() % 10], Age[rand() % 10], Phone[rand() % 10], numberOfticket[rand() % 10], flightNumber[rand() % 10], passportID[rand() % 10]);
		dynamic_cast<Passengers*>(mass2[i+1])->displayInformation();
	}
	system("pause");
}