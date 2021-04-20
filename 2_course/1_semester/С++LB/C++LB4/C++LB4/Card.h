// Blackjack
// Играет упрощенную версию игры Blackjack : от одного до семи игроков
#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <ctime>

class Card
{
public:
	enum rank {АСЕ = 1,TWO, THREE,FOUR,FIVE,SIX,SEVEN,EIGHT,NINE,TEN,JACK,QUEEN,KING};
	enum suit { CLUBS,DIAMONDS,HEARTS,SPADES };
	// перегружаем оператор«, чтобы можно было отправить объект
	// типа Card в стандартный поток вывода
	friend std::ostream& operator<<(std::ostream& os, const Card& aCard);
	Card(rank r = АСЕ,suit s = SPADES, bool ifu = true);
	// возвращает значение карты.от 1 до 11
	int GetValue() const;
	// переворачивает карту : карта.лежащая лицом вверх.
	// переворачивается лицом вниз и наоборот
	void Flip();
private:
	rank m_Rank;
	suit m_Suit;
	bool m_IsFaceUp;
};