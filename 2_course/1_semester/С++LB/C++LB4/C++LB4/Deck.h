#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <ctime>
#include "Hand.h"
#include "Card.h"
#include "GenericPlayer.h"

class Deck : public Hand
{
public:
	Deck();
	virtual ~Deck();
	// создает стандартную колоду из 52 карт
	void Populate();
	// тасует карты
	void Shufflе();
	// раздает одну карту в руку
	void Deal(Hand& aHand);
	// дает дополнительные карты игроку
	void AdditionalCards(GenericPlayer& aGenericPlayer);
};
