#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <ctime>
#include "GenericPlayer.h"

class House : public GenericPlayer
{
public:
	House() {};
	House(const std::string& name, int);
		virtual ~House();
	// показывает.хочет ли игрок продолжать брать карты
		virtual bool IsHitting() const;
	// переворачивает первую карту
	void FlipFirstCard();
	// Карт на руках
	int cardsInhand = 0;
	// Ситуация - у банка "блэкджек"
	bool Blackjack_P = 0;
};

