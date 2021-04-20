#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <ctime>
#include "Card.h"

class Hand
{
public:
	Hand();
	virtual ~Hand();
	//добавляет карту в руку
	void Add(Card* pCard);
	//очищает руку от карт
	void Clear();
	//получает сумму очков карт в руке.присваивая тузу
	//значение 1 или 11 в зависимости от ситуации
	int GetTotal() const;
	std::vector<Card*> m_Cards;
};