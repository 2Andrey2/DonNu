#include "GenericPlayer.h"

GenericPlayer::GenericPlayer(const std::string& name, const int& Rates)
{
    m_Name = name;
    Rate = Rates;
}
GenericPlayer::~GenericPlayer()
{}
void GenericPlayer::betAnnouncement()
{
    int Rate1;
    std::cout << m_Name << " Ваша ставка: ";
    do {
        std::cin >> Rate1;
        if (Rate - Rate1 < 0) { std::cout << "У вас недостаточно денег!" << std::endl; }
    } while (Rate - Rate1 < 0);
    Rate = Rate - Rate1;
    Rate_now = Rate1;
    std::cout << "У " << m_Name << " осталось: " << Rate << std::endl;
}
bool GenericPlayer::IsBusted() const
{
    //return(GetTotal() > 21);
    try
    {
        int a = GetTotal();
        if (a > 21)
        {
            throw 1;
        }
        return false;
    }
    catch (int a)
    {
        return true;
    }
}
void GenericPlayer::Bust() const
{
	std::cout << m_Name << " Перебор.\n";
}

void GenericPlayer::Vin(int i)
{
    if (i == 0) { Rate = Rate + Rate_now * 2; }
    if (i == 1) { Rate = Rate + Rate_now ; }
    if (i == 2) { Rate = Rate + Rate_now * 3; }
}

void GenericPlayer::Money()
{
    std::cout << "У " << m_Name << ": " << Rate <<std::endl;
}

bool GenericPlayer::Split(Hand& aHand)
{
    std::vector<Card*>::const_iterator iter;
    std::vector<int> mass(aHand.m_Cards.size());
    int i = 0;
    for (iter = aHand.m_Cards.begin(); iter != aHand.m_Cards.end(); ++iter)
    {
         mass[i] = (*iter)->GetValue();
         i++;
    }
    int temp;
    for (int j = 0; j < 2; ++j)
    {
        temp = mass[j];
        for (int z = j + 1; z < 2; ++z)
        {
            if (temp == mass[z])
            {
                std::cout << "Есть возможность разделить руку (Сплит)? Вы хотите это сделать (Y/N)";
                std::string s;
                std::cin >> s;
                if (s == "y" || s == "Y")
                {
                    return true;
                }
                std::cout << "Рука разделена";
                return false;
            }
        }
    }
    return false;
}

std::ostream& operator<<(std::ostream& os, const GenericPlayer& aGenericPlayer)
{
    os << aGenericPlayer.m_Name << ":\t";

    std::vector<Card*>::const_iterator pCard;
    if (!aGenericPlayer.m_Cards.empty())
    {
        for (pCard = aGenericPlayer.m_Cards.begin();
            pCard != aGenericPlayer.m_Cards.end(); ++pCard)
            os << *(*pCard) << "\t";

        if (aGenericPlayer.GetTotal() != 0)
            std::cout << "(" << aGenericPlayer.GetTotal() << ")";
    }
    else
    {
        os << "<пусто>";
    }
    return os;
}