#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <ctime>
#include "Hand.h"

class GenericPlayer : public Hand
{
	friend std::ostream& operator<<(std::ostream& os, const GenericPlayer& aGenericPlayer);
public:
	GenericPlayer() {};
	GenericPlayer(const std::string& name, const int& Rates);
	virtual ~GenericPlayer();
	//Выдача ставок
	void betAnnouncement();
	//показывает.хочет ли игрок продолжать брать карты
	virtual bool IsHitting() const = 0;
	//возвращает значение.если игрок имеет перебор - 11 сумму очков.большую 21
	bool IsBusted() const;
	// объявляет.что игрок имеет перебор
	void Bust() const;
	// начисляет выиграш
	void Vin(int);
	// выводит деньги в наличии
	void Money();
	// Ситуация - у игрока "блэкджек"
	bool Blackjack_P = 0;
	// Деньги
	int Rate;
	// Карт на руках
	int cardsInhand = 0;
	// Проверяет возможность сплита у игрока
	bool Split(Hand& aHand);
	// Для работы сплита, запоминает имя изначального игрока
	std::string m_Name_Father1 = "";
	std::string m_Name;
protected:
	int Rate_now;
};


