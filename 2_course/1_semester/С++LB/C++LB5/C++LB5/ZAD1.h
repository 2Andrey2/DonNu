#pragma once
#include <windows.h>
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
#include <cctype>
class ZAD1
{
public:
	void maimzad();
};
template <class T> // объ€вление параметра шаблона функции
class DataManager
{
private:
	std::vector<T> mass;
public:
	void push(T elem)
	{
		sizeCheck();
		mass.push_back(elem);
		locating();
	}
	void push(T elems[], size_t n)
	{
		sizeCheck();
		for (int i = 0; i < n; i++)
		{
			mass.push_back(elems[i]);
		}
		locating();
	}
	T peek()
	{
		return mass[0];
	}
	T pop()
	{
		return mass[mass.size() - 1];
	}
	void sizeCheck()
	{
		if (mass.size() == mass.max_size())
		{
			File();
		}
	}
	void File()
	{
		std::ofstream out;
		out.open("dump.dat", std::ios::app);
		if (out.is_open())
		{
			out << mass << std::endl;
		}
		std::cout << "«аписан промежуточный моссив" << std::endl;*/
	}
	void locating()
	{
		T temp;
		int size = mass.size();
		for (int i = 0; i < size - 1; i++) {
			for (int j = 0; j < size - i - 1; j++) {
				if (mass[j] > mass[j + 1]) {
					temp = mass[j];
					mass[j] = mass[j + 1];
					mass[j + 1] = temp;
				}
			}
		}
	}
};

template <> // объ€вление параметра шаблона функции
class DataManager<char>
{
private:
	char mass_p[11] = { ',',';',':','.','...', '?', '!', '-', '(', ')', '"' };
	std::vector<char> mass;
public:
	void push(char temp)
	{
		mass.push_back(temp);
		if (scan(mass[mass.size()]))
		{
			mass[mass.size()] = (char)"_";
		}
	}
	char popUpper(char element)
	{
		return std::tolower(element);
	}
	char popLower(char element)
	{
		return std::toupper(element);
	}
	bool scan(char item)
	{
		for (int i = 0; i < 11; i++)
		{
			if (item == mass_p[i])
			{
				return true;
			}
		}
		return false;
	}
};

