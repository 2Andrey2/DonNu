#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <ctime>
#include "House.h"
#include "Deck.h"
#include "Player.h"

class Game
{
public:
	Game(const std::vector<std::string>& names, const std::vector<int>& Rates);
	~Game();
	// проводит игру в Blackjack
	void Plау();
	void betAnnouncement_Game(GenericPlayer& aGenericPlayer);
	int isTheremoney;
private:
	Deck m_Deck;
	House m_House;
	Game* m_Game;
	std::vector<Player> m_Players;
};
