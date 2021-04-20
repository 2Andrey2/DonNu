#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <ctime>
#include "GenericPlayer.h"

class Player : public GenericPlayer
{
public:
	Player() {};
	Player(const std::string& name, const int& Rates);
	virtual ~Player();
	//показывает.хочет ли игрок продолжать брать карты
	virtual bool IsHitting() const;
	// объ€вл€ет.что игрок победил
	void Win() const;
	// объ€вл€ет.что игрок проиграл
	void Lose() const;
	// объ€вл€ет ничью
	void Push() const;
	std::vector<Player>::iterator m_Name_Father;
};