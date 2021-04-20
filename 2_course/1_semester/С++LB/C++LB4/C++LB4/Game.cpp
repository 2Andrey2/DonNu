#include "Game.h"

Game::Game(const std::vector<std::string>& names, const std::vector<int>& Rates)
{
	// создает вектор игроков из вектора с именами
	std::vector<std::string>::const_iterator pName;
	int i = 0;
	for (pName = names.begin(); pName != names.end(); ++pName, ++i)
	{
		m_Players.push_back(Player(*pName,Rates[i]));
	}
	// засевает генератор случайных чисел
	srand(static_cast<unsigned int>(time(0)));
	m_Deck.Populate();
	m_Deck.Populate();
	m_Deck.Populate();
	m_Deck.Populate();
	m_Deck.Shufflе();
}
Game::~Game()
{}
void Game::Plау()
{
	std::vector<Player>::iterator pPlayer;
	// Игроки делают ставки
	for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
	{
		m_Game->betAnnouncement_Game(*pPlayer);
	}
	// раздает каждому по две стартовые карты
	for (int i = 0; i < 2; ++i)
	{
		for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
		{
			m_Deck.Deal(*pPlayer);
			pPlayer->cardsInhand = pPlayer->cardsInhand + 1;
		}
		m_Deck.Deal(m_House);
		m_House.cardsInhand = m_House.cardsInhand + 1;
	}
	// прячет первую карту дилера
	m_House.FlipFirstCard();
	// открывает руки всех игроков
	for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer) {
		std::cout << *pPlayer << std::endl;
	}
	// Проверяет наличие возможности сплита
	std::vector<Player> temp1;
	std::vector<Player>::iterator temp1_it;
	std::vector<Player> temp2;
	std::vector<Player>::iterator temp2_it;
	int flag = 0;
	for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
	{
		if (pPlayer->Split(*pPlayer) == true)
		{
			flag = 1;
			temp1.push_back(*pPlayer);
		}
	}
	if (flag == 1)
	{
		for (temp1_it = temp1.begin(); temp1_it != temp1.end(); ++temp1_it)
		{
			temp1_it->m_Name = temp1_it->m_Name + " (Первая рука)";
			m_Players.push_back(Player(temp1_it->m_Name + " (Вторая рука)", temp1_it->Rate));
			std::cout << "Ставка на вторую руку" << std::endl;
			temp2_it = m_Players.end()-1;
			temp2_it->Rate = temp1_it->Rate;
			m_Game->betAnnouncement_Game(*temp2_it);
			temp1_it->m_Name_Father1 = temp2_it->m_Name;
			temp1_it->m_Name_Father = temp2_it;
		}
	}
	std::cout << m_House << std::endl;
	// раздает игрокам дополнительные карты
	for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
	{
		m_Deck.AdditionalCards(*pPlayer);
	}
	// показывает первую карту дилера
	m_House.FlipFirstCard();
	std::cout << std::endl << m_House;
	// раздает дилеру дополнительные карты
	m_Deck.AdditionalCards(m_House);

	std::string name;
	int Rate_split;
	if (m_House.IsBusted())
	{
		// все.кто остался в игре.побеждают
		for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
		{
			Rate_split = pPlayer->Rate;
			if (!(pPlayer->IsBusted()))
			{
				pPlayer->Win();
				if (pPlayer->Blackjack_P == true) { pPlayer->Vin(2); }
				else { pPlayer->Vin(0); }
			}
			if (pPlayer->m_Name_Father1 != "")
			{
				Rate_split = Rate_split - pPlayer->Rate;
				pPlayer->m_Name_Father->Rate = pPlayer->m_Name_Father->Rate + Rate_split;
				pPlayer->Rate = 0;

			}
		}
	}
	else
	{
		// сравнивает суммы очков всех оставшихся игроков с суммой очков дилера
		for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
		{
			if (!(pPlayer->IsBusted()))
			{
				Rate_split = pPlayer->Rate;
				if (pPlayer->GetTotal() > m_House.GetTotal())
				{
					pPlayer->Win();
					if (pPlayer->Blackjack_P == true && m_House.Blackjack_P != 1) { pPlayer->Vin(2); }
					else { pPlayer->Vin(0); }
				}
				else if (pPlayer->GetTotal() < m_House.GetTotal())
				{
					pPlayer->Lose();
				}
				else
				{
					pPlayer->Push();
					pPlayer->Vin(1);
				}
				if (pPlayer->m_Name_Father1 != "")
				{
					Rate_split = Rate_split - pPlayer->Rate;
					pPlayer->m_Name_Father->Rate = pPlayer->m_Name_Father->Rate + Rate_split;
					pPlayer->Rate = 0;

				}
			}
		}
	}
	// очищает руки всех игроков и обнуляет кол-во карт на руках
	m_House.cardsInhand = 0;
	for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
	{
		pPlayer->Clear();
		pPlayer->cardsInhand = 0;
	}
	m_House.Clear();
	// выводит кол-во денег у игроков
	for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
	{
		pPlayer->Money();
	}
	// Анализирует кто из игроков выбыл (закончились деньги)
	std::vector<int> mass;
	std::vector<int>::iterator mass_it;
	int i = 0;
	for (pPlayer = m_Players.begin(); pPlayer != m_Players.end(); ++pPlayer)
	{
		if (pPlayer->Rate <= 0)
		{
			mass.push_back(i);
			i++;
		}
	}
	// Непосредственно выкидывает игроков, завершает игру если все игроки без денег
	i = 0;
	for (mass_it = mass.begin(); mass_it != mass.end(); ++mass_it, ++i)
	{
		if (m_Players.size() == mass.size())
		{
			m_Players.clear();
			isTheremoney = 0;
			return;
		}
		else {
			m_Players.erase(m_Players.begin() + mass[i]);
		}
	}
	isTheremoney = 1;
}

void Game::betAnnouncement_Game(GenericPlayer& aGenericPlayer)
{
	aGenericPlayer.betAnnouncement();
}
