#include "Deck.h"

Deck::Deck()
{
	m_Cards.reserve(52);
	Populate();
}
Deck::~Deck()
{}
void Deck::Populate()
{
	//Clear();
	// создает стандартную колоду
	for (int s = Card::CLUBS; s <= Card::SPADES; ++s)
	{
		for (int r = Card::АСЕ; r <= Card::KING; ++r)
		{
			Add(new Card(static_cast<Card::rank>(r), static_cast<Card::suit>(s)));
		}
	}
}
void Deck::Shufflе()
{
	random_shuffle(m_Cards.begin(), m_Cards.end());
}
void Deck::Deal(Hand& aHand)
{
	if (!m_Cards.empty())
	{
		aHand.Add(m_Cards.back());
		m_Cards.pop_back();
	}
	else
	{
		std::cout << "Нет карт. Невозможно продолжить. ";
	}
}
void Deck::AdditionalCards(GenericPlayer& aGenericPlayer)
{
	std::cout << std::endl;
	// продолжает раздавать карты до тех пор.пока у игрока не случается
	// перебор или пока он хочет взять еще одну карту
	if (aGenericPlayer.GetTotal() == 21) { goto metka1; }
	while (!(aGenericPlayer.IsBusted()) && aGenericPlayer.IsHitting())
	{
		if (aGenericPlayer.cardsInhand != 6)
		{
			Deal(aGenericPlayer);
			std::cout << aGenericPlayer << std::endl;

			if (aGenericPlayer.IsBusted())
				aGenericPlayer.Bust();
			if (aGenericPlayer.GetTotal() == 21)
			{
				metka1:
				aGenericPlayer.Blackjack_P = true;
				std::cout <<"У вас Blackjack вы победили!" << std::endl;
				return;
			}
			aGenericPlayer.cardsInhand++;
		}
		else
		{
			std::cout << "Больше брать нельзя!";
			return;
		}
	}
}
