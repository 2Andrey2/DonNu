#include "ZAD1.h"

void ZAD1::maimzad()
{
	DataManager<int> manager;
	manager.push(-9); // уже в наборе 1 элемент
	int a[60] = { 0 };
	manager.push(a, 60); // уже в наборе 61 элемент
	int x = manager.peek(); // узнаем последний элемент (без извлечения)
	for (int i = 1; i < 15; ++i)
	{
		manager.push(i); // здесь на четвертой итерации должна
	} // произойти выгрузка 64 элементов в файл dump.dat
	x = manager.pop(); // сейчас в наборе 11 элементов
	// после рор() будет 10
	DataManager<char> char_manager; // явная специализация шаблона для char
	char_manager.push('h');
	char_manager.push('e');
	char_manager.push('l');
	char_manager.push('l');
	char_manager.push('o');
	char ch = char_manager.popUpper('f'); // этот метод есть только для char
	std::cout << ch << std::endl;
}
