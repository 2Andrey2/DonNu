#include "Card.h"
#include <windows.h>

Card::Card(rank r, suit s, bool ifu) : m_Rank(r), m_Suit(s), m_IsFaceUp(ifu)
{}
int Card::GetValue() const
{
	// если карта перевернута лицом вниз.ее значение равно О
	int value = 0;
	if (m_IsFaceUp)
	{
		// значение - это число.указанное на карте
		value = m_Rank;
		// значение равно 10 для открытых карт
		if (value > 10)
		{
			value = 10;
		}
	}
	return value;
}
void Card::Flip()
{
	m_IsFaceUp = !(m_IsFaceUp);
}

std::ostream& operator<<(std::ostream& os, const Card& aCard)
{
	SetConsoleCP(866);
	SetConsoleOutputCP(866);
	const std::string RANKS[] = { "О", "А", "2", "З", "4", "5", "6", "7", "8", "9",
	"10", "J", "О", "К" };
	int SUIТS[] = { 3, 4, 5, 6 };
	if (aCard.m_IsFaceUp)
	{
		os << RANKS[aCard.m_Rank] << (char)SUIТS[aCard.m_Suit];
	}
	else
	{
		os << "ХХ";
	}
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	return os;
}
