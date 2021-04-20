#include "IFormattable.h"

std::string IFormattable::format()
{
	if (a[0] == "O") { a[0] = "Дама"; } else { a[0] = "O"; }
	if (a[0] == "A") { a[0] = "Туз"; } else { a[0] = "A"; }
	if (a[0] == "2") { a[0] = "Двойка"; } else { a[0] = "2"; }
	if (a[0] == "3") { a[0] = "Тройка"; } else { a[0] = "3"; }
	if (a[0] == "4") { a[0] = "Четверка"; } else { a[0] = "4"; }
	if (a[0] == "5") { a[0] = "Пятерка"; } else { a[0] = "5"; }
	if (a[0] == "6") { a[0] = "Шестерка"; } else { a[0] = "6"; }
	if (a[0] == "7") { a[0] = "Семерка"; } else { a[0] = "7"; }
	if (a[0] == "8") { a[0] = "Восьмерка"; } else { a[0] = "8"; }
	if (a[0] == "9") { a[0] = "Девятка"; } else { a[0] = "9"; }
	if (a[0] == "10") { a[0] = "Десятка"; } else { a[0] = "10"; }
	if (a[0] == "J") { a[0] = "Валет"; } else { a[0] = "J"; }
	if (a[0] == "K") { a[0] = "Король"; } else { a[0] = "K"; }
	return std::string();
}

void IFormattable::prettyPrint(const IFormattable& object)
{
	for (size_t i = 0; i < object.a->size(); i++)
	{
		a[i] = object.a[i];
	}
	format();
	for (size_t i = 0; i < a->size(); i++)
	{
		std::cout << a[i] << std::endl;
	}
}
