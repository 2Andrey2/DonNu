#include "House.h"

House::House(const std::string& name, int Rate) : GenericPlayer(name,Rate)
{}
House::~House()
{}
bool House::IsHitting() const
{
	return (GetTotal() <= 16);
}
void House::FlipFirstCard()
{
	if (!(m_Cards.empty())) {
		m_Cards[0]->Flip();
	}
	else
	{
		std::cout << "Нечего переворачивать!\n";
	}
}
