#pragma once
#include <String>

class ILoggable
{
	virtual void logToScreen() = 0; // Чисто виртуальная функция/метод
	virtual void logToFile(const std::string& filename) = 0; // Чисто виртуальная функция/метод
};

